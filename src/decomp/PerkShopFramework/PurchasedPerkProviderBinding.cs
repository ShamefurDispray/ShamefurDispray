using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Il2Cpp;

namespace PerkShopFramework;

internal sealed class PurchasedPerkProviderBinding
{
	[field: CompilerGenerated]
	internal string AssemblyName
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	internal System.Type? ProviderType
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	internal MethodInfo? Method
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	internal ProviderBehavior Behavior
	{
		[CompilerGenerated]
		get;
	}

	internal PurchasedPerkProviderBinding(string assemblyName, System.Type? providerType, MethodInfo? method, ProviderBehavior behavior)
	{
		AssemblyName = assemblyName;
		ProviderType = providerType;
		Method = method;
		Behavior = behavior;
	}

	internal void ApplyBeforeInitial(PlayerStore store, StartingPerk perk, string id)
	{
		switch (Behavior)
		{
		case ProviderBehavior.ExternalNotifier:
			if (!PurchasedPerkProviderRegistry.TryInvokeExternalNotifier(AssemblyName))
			{
				PerkShopLog.Warning("外部特性 Notifier 未找到，已继续通过生命周期补丁重放。" + AssemblyName);
			}
			break;
		case ProviderBehavior.Direct:
			InvokeDirect();
			break;
		}
	}

	internal void ApplyAfterInitial(PlayerStore store, StartingPerk perk, string id)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (Behavior == ProviderBehavior.FutureTech && (PerkShopMod.Instance == null || !PerkShopMod.Instance.TryGrantFutureTechStarterItems()))
		{
			throw new InvalidOperationException("FutureTech provider failed.");
		}
		if (string.Equals(id, "xiaowo_trade_precision_bay_expansion", (StringComparison)4))
		{
			TryEnableXiaowoPrecisionBay();
		}
	}

	private static void TryEnableXiaowoPrecisionBay()
	{
		try
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				System.Type type = assemblies[i].GetType("XIAOWOTradePerks.PrecisionBayMode", false);
				if (type == (System.Type)null)
				{
					continue;
				}
				MethodInfo method = type.GetMethod("SetForCurrentSave", (BindingFlags)56, (Binder)null, new System.Type[2]
				{
					typeof(bool),
					typeof(bool)
				}, (ParameterModifier[])null);
				if (!(method == (MethodInfo)null))
				{
					object obj = ((MethodBase)method).Invoke((object)null, new object[2] { true, false });
					if (obj is bool && !(bool)obj)
					{
						PerkShopLog.Warning("XIAOWO 精工扩舱状态启用失败。");
					}
				}
				break;
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("XIAOWO 精工扩舱入口调用失败：" + ex.Message);
		}
	}

	private void InvokeDirect()
	{
		if (Method == (MethodInfo)null)
		{
			StartingPerkContent.HandleNewGamePerk();
			return;
		}
		object obj = null;
		if (!((MethodBase)Method).IsStatic)
		{
			obj = Activator.CreateInstance(ProviderType, true);
		}
		((MethodBase)Method).Invoke(obj, (object[])null);
	}
}
