using System;
using HarmonyLib;
using Il2Cpp;

namespace PerkShopFramework;

[HarmonyPatch(typeof(PlayerStore), "EndNight")]
internal static class PerkShopEndNightPatch
{
	[HarmonyPostfix]
	private static void Postfix()
	{
		try
		{
			PerkShopMod.Instance?.HandleEndNight();
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("EndNight 补丁失败：" + (object)ex);
		}
	}
}
