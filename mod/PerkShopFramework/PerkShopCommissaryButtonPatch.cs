using System;
using HarmonyLib;

namespace PerkShopFramework;

[HarmonyPatch(typeof(CommissaryUIManager), "OpenUI")]
internal static class PerkShopCommissaryButtonPatch
{
	private static void Postfix(CommissaryUIManager __instance)
	{
		try
		{
			PerkShopMod.Instance?.EnsureCommissaryButton(__instance);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("Commissary OpenUI 补丁失败：" + (object)ex);
		}
	}
}
