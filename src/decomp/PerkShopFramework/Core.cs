using System;
using MelonLoader;

namespace PerkShopFramework;

public sealed class Core : MelonMod
{
	public override void OnInitializeMelon()
	{
		PerkShopLog.Initialize(((MelonBase)this).LoggerInstance);
		try
		{
			PerkShopLog.Msg("开始初始化。");
			PerkShopMod.Initialize(((MelonBase)this).HarmonyInstance);
			PerkShopLog.Msg("初始化完成。");
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("初始化失败：" + (object)ex);
		}
	}

	public override void OnUpdate()
	{
		try
		{
			PerkShopMod.Update();
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("OnUpdate 失败：" + (object)ex);
		}
	}

	public override void OnDeinitializeMelon()
	{
		try
		{
			PerkShopMod.Shutdown();
			PerkShopLog.Msg("已卸载。");
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("卸载失败：" + (object)ex);
		}
	}
}
