using System;
using HarmonyLib;

namespace PerkShopFramework;

[HarmonyPatch(typeof(PlayerStore), "LoadGame")]
internal static class PerkShopLoadGamePatch
{
	[HarmonyPostfix]
	private static void Postfix()
	{
		try
		{
			PerkShopMod.Instance?.InvalidateLoadedState();
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("LoadGame 补丁失败：" + (object)ex);
		}
	}
}
