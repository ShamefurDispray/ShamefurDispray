using System;
using HarmonyLib;

namespace PerkShopFramework;

[HarmonyPatch(typeof(PlayerStore), "BeginDay")]
internal static class PerkShopBeginDayPatch
{
	[HarmonyPostfix]
	private static void Postfix()
	{
		try
		{
			PerkShopMod.Instance?.HandleBeginDay();
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("BeginDay 补丁失败：" + (object)ex);
		}
	}
}
