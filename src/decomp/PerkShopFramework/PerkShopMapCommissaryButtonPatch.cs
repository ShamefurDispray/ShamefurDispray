using System;
using HarmonyLib;
using Il2Cpp;

namespace PerkShopFramework;

[HarmonyPatch(typeof(MapUIManager), "CommissaryTradeButton")]
internal static class PerkShopMapCommissaryButtonPatch
{
	private static void Postfix()
	{
		try
		{
			PerkShopMod.Instance?.EnsureCommissaryButton(CommissaryUIManager.Instance);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("CommissaryTradeButton 补丁失败：" + (object)ex);
		}
	}
}
