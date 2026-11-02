using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace PerkShopFramework;

internal static class PurchasedPerkLifecycleReplay
{
	private static readonly HashSet<string> TargetTypes;

	private static readonly HashSet<string> TargetMethods;

	internal static void Apply(PlayerStore store, string assemblyName)
	{
		if (store == null || string.IsNullOrEmpty(assemblyName))
		{
			return;
		}
		System.Collections.Generic.IEnumerator<MethodBase> enumerator = Harmony.GetAllPatchedMethods().GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				MethodBase current = enumerator.Current;
				if (IsTarget(current))
				{
					Patches patchInfo = Harmony.GetPatchInfo(current);
					if (patchInfo != null)
					{
						InvokePatches((System.Collections.Generic.IEnumerable<Patch>?)patchInfo.Prefixes, current, store, assemblyName);
						InvokePatches((System.Collections.Generic.IEnumerable<Patch>?)patchInfo.Postfixes, current, store, assemblyName);
					}
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
	}

	internal static void ApplyHandleInitialItemPostfixes(string assemblyName)
	{
		if (string.IsNullOrEmpty(assemblyName))
		{
			return;
		}
		MethodInfo val = AccessTools.Method(typeof(NewGameData), "HandleInitialItem", System.Type.EmptyTypes);
		if (!(val == (MethodInfo)null))
		{
			Patches patchInfo = Harmony.GetPatchInfo((MethodBase)(object)val);
			if (patchInfo != null)
			{
				InvokePatches((System.Collections.Generic.IEnumerable<Patch>?)patchInfo.Prefixes, (MethodBase)(object)val, null, assemblyName);
				InvokePatches((System.Collections.Generic.IEnumerable<Patch>?)patchInfo.Postfixes, (MethodBase)(object)val, null, assemblyName);
			}
		}
	}

	private static bool IsTarget(MethodBase method)
	{
		string text = ((MemberInfo)method).DeclaringType?.Name ?? string.Empty;
		if (TargetTypes.Contains(text))
		{
			return TargetMethods.Contains(((MemberInfo)method).Name);
		}
		return false;
	}

	private static void InvokePatches(System.Collections.Generic.IEnumerable<Patch>? patches, MethodBase targetMethod, PlayerStore store, string assemblyName)
	{
		if (patches == null)
		{
			return;
		}
		System.Collections.Generic.IEnumerator<Patch> enumerator = patches.GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				MethodInfo patchMethod = enumerator.Current.PatchMethod;
				if (patchMethod == (MethodInfo)null)
				{
					continue;
				}
				System.Type declaringType = ((MemberInfo)patchMethod).DeclaringType;
				string text = ((declaringType != null) ? declaringType.Assembly.GetName().Name : null) ?? string.Empty;
				if (!string.Equals(text, assemblyName, (StringComparison)4))
				{
					continue;
				}
				if (string.Equals(((MemberInfo)targetMethod).Name, "NewGame", (StringComparison)4))
				{
					System.Type declaringType2 = ((MemberInfo)patchMethod).DeclaringType;
					if (string.Equals((declaringType2 != null) ? ((MemberInfo)declaringType2).Name : null, "Patches", (StringComparison)4) && PurchasedPerkProviderRegistry.IsExternalNotifierAssembly(text))
					{
						continue;
					}
				}
				InvokePatch(patchMethod, targetMethod, store);
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
	}

	private static void InvokePatch(MethodInfo patchMethod, MethodBase targetMethod, PlayerStore store)
	{
		try
		{
			object obj = null;
			if (!((MethodBase)patchMethod).IsStatic)
			{
				obj = Activator.CreateInstance(((MemberInfo)patchMethod).DeclaringType, true);
			}
			((MethodBase)patchMethod).Invoke(obj, BuildArguments(patchMethod, targetMethod, store));
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning(string.Concat(new string[6]
			{
				"生命周期补丁重放失败：",
				((MemberInfo)patchMethod).DeclaringType?.FullName ?? ((MemberInfo)patchMethod).Name,
				".",
				((MemberInfo)patchMethod).Name,
				"，",
				ex.Message
			}));
		}
	}

	private static object?[] BuildArguments(MethodInfo patchMethod, MethodBase targetMethod, PlayerStore store)
	{
		ParameterInfo[] parameters = ((MethodBase)patchMethod).GetParameters();
		object[] array = new object[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo obj = parameters[i];
			System.Type parameterType = obj.ParameterType;
			System.Type type = (parameterType.IsByRef ? parameterType.GetElementType() : parameterType);
			string text = obj.Name ?? string.Empty;
			if (string.Equals(text, "__instance", (StringComparison)4))
			{
				array[i] = ResolveInstance(type, store);
			}
			else if (string.Equals(text, "__originalMethod", (StringComparison)4))
			{
				array[i] = targetMethod;
			}
			else if (type == typeof(PlayerStore))
			{
				array[i] = store;
			}
			else if (type == typeof(GameMaster))
			{
				array[i] = null;
			}
			else if (type == typeof(NewGameData))
			{
				array[i] = NewGameData.Instance;
			}
			else
			{
				array[i] = CreateDefault(type);
			}
		}
		return array;
	}

	private static object? ResolveInstance(System.Type type, PlayerStore store)
	{
		if (type == typeof(PlayerStore))
		{
			return store;
		}
		if (type == typeof(GameMaster))
		{
			return null;
		}
		if (type == typeof(NewGameData))
		{
			return NewGameData.Instance;
		}
		return CreateDefault(type);
	}

	private static object? CreateDefault(System.Type type)
	{
		if (type == typeof(void))
		{
			return null;
		}
		if (type.IsValueType)
		{
			return Activator.CreateInstance(type);
		}
		return null;
	}

	static PurchasedPerkLifecycleReplay()
	{
		HashSet<string> obj = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		obj.Add("GameMaster");
		TargetTypes = obj;
		HashSet<string> obj2 = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		obj2.Add("StartNewGame");
		obj2.Add("NewGame");
		obj2.Add("InitialSave");
		obj2.Add("HandleSkipIntro");
		TargetMethods = obj2;
	}
}
