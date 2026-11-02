using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace PerkShopFramework;

internal static class PurchasedPerkProviderRegistry
{
	private static readonly object Gate = new object();

	private static readonly Dictionary<string, PurchasedPerkProviderBinding> Bindings = new Dictionary<string, PurchasedPerkProviderBinding>((IEqualityComparer<string>)(object)StringComparer.Ordinal);

	private static readonly Dictionary<string, MethodInfo> ExternalNotifiers = new Dictionary<string, MethodInfo>((IEqualityComparer<string>)(object)StringComparer.Ordinal);

	private static string _primaryExternalNotifierAssembly = string.Empty;

	private static bool _scanned;

	private static int _scannedAssemblyCount = -1;

	private static readonly Dictionary<string, bool> NativeContentPathCache = new Dictionary<string, bool>((IEqualityComparer<string>)(object)StringComparer.Ordinal);

	internal static PurchasedPerkProviderBinding Resolve(string id)
	{
		EnsureScanned();
		lock (Gate)
		{
			PurchasedPerkProviderBinding result = default(PurchasedPerkProviderBinding);
			if (Bindings.TryGetValue(id, out result))
			{
				return result;
			}
		}
		return new PurchasedPerkProviderBinding(InferAssemblyName(id), null, null, ProviderBehavior.NativeUnified);
	}

	internal static bool TryInvokeExternalNotifier(string assemblyName)
	{
		EnsureScanned();
		if (string.IsNullOrEmpty(assemblyName))
		{
			return false;
		}
		MethodInfo val = default(MethodInfo);
		lock (Gate)
		{
			ExternalNotifiers.TryGetValue(assemblyName, out val);
		}
		if (val == (MethodInfo)null)
		{
			return false;
		}
		((MethodBase)val).Invoke((object)null, (object[])null);
		return true;
	}

	internal static bool IsExternalNotifierAssembly(string assemblyName)
	{
		if (string.IsNullOrEmpty(assemblyName))
		{
			return false;
		}
		EnsureScanned();
		lock (Gate)
		{
			return ExternalNotifiers.ContainsKey(assemblyName);
		}
	}

	private static void EnsureScanned()
	{
		if (_scanned && AppDomain.CurrentDomain.GetAssemblies().Length <= _scannedAssemblyCount)
		{
			return;
		}
		lock (Gate)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			if (_scanned && assemblies.Length <= _scannedAssemblyCount)
			{
				return;
			}
			_scanned = true;
			_scannedAssemblyCount = assemblies.Length;
			NativeContentPathCache.Clear();
			try
			{
				foreach (Assembly assembly in assemblies)
				{
					string text = SafeAssemblyName(assembly);
					if (string.IsNullOrEmpty(text) || ShouldSkipAssembly(text))
					{
						continue;
					}
					System.Type[] scannableTypes = GetScannableTypes(assembly);
					if (scannableTypes.Length == 0)
					{
						continue;
					}
					BindExternalNotifier(text, scannableTypes);
					foreach (System.Type type in scannableTypes)
					{
						if (type == (System.Type)null)
						{
							continue;
						}
						List<string> val = ExtractPerkIds(type);
						AddInstancePerkIds(type, val);
						if (val.Count == 0)
						{
							continue;
						}
						ProviderBehavior behavior = ResolveBehavior(text, type);
						MethodInfo method = FindProviderMethod(type, behavior);
						PurchasedPerkProviderBinding purchasedPerkProviderBinding = new PurchasedPerkProviderBinding(text, type, method, behavior);
						lock (Gate)
						{
							for (int k = 0; k < val.Count; k++)
							{
								Bindings[NormalizeId(val[k])] = purchasedPerkProviderBinding;
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				PerkShopLog.Warning("Provider 注册失败：" + ex.Message);
			}
		}
	}

	private static ProviderBehavior ResolveBehavior(string assemblyName, System.Type type)
	{
		if (assemblyName == "FutureTech")
		{
			return ProviderBehavior.FutureTech;
		}
		if (SelfDrivesOnNativeContentPath(assemblyName))
		{
			return ProviderBehavior.NativeUnified;
		}
		if (IsExternalNotifierAssembly(assemblyName))
		{
			return ProviderBehavior.ExternalNotifier;
		}
		if (FindZeroArgMethod(type, "OnNewGame") != (MethodInfo)null || FindZeroArgMethod(type, "TryGrant") != (MethodInfo)null)
		{
			return ProviderBehavior.Direct;
		}
		return ProviderBehavior.ActiveOnly;
	}

	private static bool SelfDrivesOnNativeContentPath(string assemblyName)
	{
		lock (Gate)
		{
			bool result = default(bool);
			if (NativeContentPathCache.TryGetValue(assemblyName, out result))
			{
				return result;
			}
		}
		bool flag = false;
		try
		{
			System.Collections.Generic.IEnumerator<MethodBase> enumerator = Harmony.GetAllPatchedMethods().GetEnumerator();
			try
			{
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					MethodBase current = enumerator.Current;
					System.Type declaringType = ((MemberInfo)current).DeclaringType;
					if (declaringType == (System.Type)null || !string.Equals(((MemberInfo)declaringType).Name, "StartingPerkContent", (StringComparison)4))
					{
						continue;
					}
					Patches patchInfo = Harmony.GetPatchInfo(current);
					if (patchInfo != null)
					{
						flag = OwnedBy((System.Collections.Generic.IEnumerable<Patch>?)patchInfo.Prefixes, assemblyName) || OwnedBy((System.Collections.Generic.IEnumerable<Patch>?)patchInfo.Postfixes, assemblyName) || OwnedBy((System.Collections.Generic.IEnumerable<Patch>?)patchInfo.Finalizers, assemblyName);
						if (flag)
						{
							break;
						}
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("原生特性内容挂点探测失败：" + ex.Message);
		}
		lock (Gate)
		{
			NativeContentPathCache[assemblyName] = flag;
			return flag;
		}
	}

	private static bool OwnedBy(System.Collections.Generic.IEnumerable<Patch>? patches, string assemblyName)
	{
		if (patches == null)
		{
			return false;
		}
		System.Collections.Generic.IEnumerator<Patch> enumerator = patches.GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				MethodInfo patchMethod = enumerator.Current.PatchMethod;
				object obj;
				if (patchMethod == null)
				{
					obj = null;
				}
				else
				{
					System.Type declaringType = ((MemberInfo)patchMethod).DeclaringType;
					obj = ((declaringType != null) ? declaringType.Assembly.GetName().Name : null);
				}
				if (string.Equals((string)obj, assemblyName, (StringComparison)4))
				{
					return true;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return false;
	}

	private static MethodInfo? FindProviderMethod(System.Type type, ProviderBehavior behavior)
	{
		if (behavior == ProviderBehavior.Direct)
		{
			return FindZeroArgMethod(type, "OnNewGame") ?? FindZeroArgMethod(type, "TryGrant") ?? FindZeroArgMethod(type, "GiveStartingGoods") ?? FindZeroArgMethod(type, "GiveToBackpack");
		}
		return null;
	}

	private static MethodInfo? FindZeroArgMethod(System.Type type, string name)
	{
		string name2 = name;
		try
		{
			return Enumerable.FirstOrDefault<MethodInfo>((System.Collections.Generic.IEnumerable<MethodInfo>)type.GetMethods((BindingFlags)60), (Func<MethodInfo, bool>)((MethodInfo method) => ((MemberInfo)method).Name == name2 && ((MethodBase)method).GetParameters().Length == 0));
		}
		catch
		{
			return null;
		}
	}

	private static void AddInstancePerkIds(System.Type type, List<string> ids)
	{
		if (type.IsAbstract || ((MemberInfo)type).Name.IndexOf("Perk", (StringComparison)5) < 0)
		{
			return;
		}
		object obj = null;
		try
		{
			obj = Activator.CreateInstance(type, true);
		}
		catch
		{
			return;
		}
		if (obj == null)
		{
			return;
		}
		try
		{
			string text = null;
			System.Type type2 = type;
			while (type2 != (System.Type)null)
			{
				PropertyInfo[] properties = type2.GetProperties((BindingFlags)54);
				for (int i = 0; i < properties.Length; i++)
				{
					if (string.Equals(((MemberInfo)properties[i]).Name, "Id", (StringComparison)4))
					{
						text = properties[i].GetValue(obj) as string;
						break;
					}
				}
				if (text != null)
				{
					break;
				}
				FieldInfo[] fields = type2.GetFields((BindingFlags)54);
				for (int j = 0; j < fields.Length; j++)
				{
					if (string.Equals(((MemberInfo)fields[j]).Name, "Id", (StringComparison)4))
					{
						text = fields[j].GetValue(obj) as string;
						break;
					}
				}
				if (text != null)
				{
					break;
				}
				type2 = type2.BaseType;
			}
			text = (text ?? string.Empty).TrimEnd('\0');
			if (!string.IsNullOrEmpty(text) && !ids.Contains(text))
			{
				ids.Add(text);
			}
		}
		catch
		{
		}
	}

	private static List<string> ExtractPerkIds(System.Type type)
	{
		List<string> val = new List<string>();
		try
		{
			FieldInfo[] fields = type.GetFields((BindingFlags)58);
			foreach (FieldInfo val2 in fields)
			{
				if (val2.IsLiteral && !(val2.FieldType != typeof(string)) && (((MemberInfo)val2).Name == "Id" || ((MemberInfo)val2).Name == "PERK_ID" || ((MemberInfo)val2).Name.IndexOf("PerkId", (StringComparison)5) >= 0))
				{
					string text = val2.GetRawConstantValue() as string;
					if (!string.IsNullOrEmpty(text))
					{
						val.Add(text);
					}
				}
			}
		}
		catch
		{
		}
		return val;
	}

	private static string InferAssemblyName(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return "Assembly-CSharp";
		}
		if (id.StartsWith("xiaowo_trade_", (StringComparison)4))
		{
			return "XIAOWOTradePerks";
		}
		if (id.StartsWith("dspf_", (StringComparison)4))
		{
			return "FutureTech";
		}
		if (id.StartsWith("moddesign_", (StringComparison)4))
		{
			return "WineAppraisalMaster";
		}
		if (id.StartsWith("ratlin_", (StringComparison)4))
		{
			return "Ratlin";
		}
		if (id.StartsWith("vain_", (StringComparison)4))
		{
			return "VainPerson";
		}
		if (!string.IsNullOrEmpty(_primaryExternalNotifierAssembly) && HasNonAscii(id))
		{
			return _primaryExternalNotifierAssembly;
		}
		return "Assembly-CSharp";
	}

	private static bool HasNonAscii(string value)
	{
		for (int i = 0; i < value.Length; i++)
		{
			if (value[i] > '\u007f')
			{
				return true;
			}
		}
		return false;
	}

	private static System.Type[] GetScannableTypes(Assembly assembly)
	{
		try
		{
			return assembly.GetTypes();
		}
		catch (ReflectionTypeLoadException val)
		{
			return Enumerable.ToArray<System.Type>(Enumerable.Where<System.Type>((System.Collections.Generic.IEnumerable<System.Type>)val.Types, (Func<System.Type, bool>)((System.Type type) => type != (System.Type)null)));
		}
		catch
		{
			return System.Type.EmptyTypes;
		}
	}

	private static void BindExternalNotifier(string assemblyName, System.Type[] types)
	{
		lock (Gate)
		{
			if (ExternalNotifiers.ContainsKey(assemblyName))
			{
				return;
			}
		}
		foreach (System.Type type in types)
		{
			if (type == (System.Type)null || !string.Equals(((MemberInfo)type).Name, "CustomStartingPerks", (StringComparison)4))
			{
				continue;
			}
			MethodInfo val = FindZeroArgMethod(type, "NotifyNewGame");
			if (val == (MethodInfo)null || !((MethodBase)val).IsStatic)
			{
				continue;
			}
			lock (Gate)
			{
				ExternalNotifiers[assemblyName] = val;
				if (string.IsNullOrEmpty(_primaryExternalNotifierAssembly))
				{
					_primaryExternalNotifierAssembly = assemblyName;
				}
			}
			PerkShopLog.Msg(string.Concat(new string[5]
			{
				"已绑定外部特性 Notifier：",
				assemblyName,
				" → ",
				((MemberInfo)val).DeclaringType?.FullName ?? ((MemberInfo)type).Name,
				".NotifyNewGame"
			}));
			break;
		}
	}

	private static string SafeAssemblyName(Assembly assembly)
	{
		try
		{
			return assembly.GetName().Name ?? string.Empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static bool ShouldSkipAssembly(string name)
	{
		if (!name.StartsWith("System", (StringComparison)5) && !name.StartsWith("Microsoft", (StringComparison)5) && !name.StartsWith("Unity", (StringComparison)5) && !name.StartsWith("Il2Cpp", (StringComparison)5) && !name.Equals("mscorlib", (StringComparison)5) && !name.Equals("netstandard", (StringComparison)5) && !name.Equals("0Harmony", (StringComparison)5) && !name.Equals("MelonLoader", (StringComparison)5))
		{
			return name.Equals("Assembly-CSharp", (StringComparison)5);
		}
		return true;
	}

	private static string NormalizeId(string? id)
	{
		return (id ?? string.Empty).TrimEnd('\0');
	}
}
