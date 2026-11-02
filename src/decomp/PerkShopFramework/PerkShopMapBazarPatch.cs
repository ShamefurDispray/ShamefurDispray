using System;
using HarmonyLib;
using Il2Cpp;

namespace PerkShopFramework;

[HarmonyPatch(typeof(MapUIManager), "Bazar")]
internal static class PerkShopMapBazarPatch
{
	private static void Postfix()
	{
		try
		{
			PerkShopMod.Instance?.EnsureCommissaryButton(CommissaryUIManager.Instance);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("Bazar 补丁失败：" + (object)ex);
		}
	}
}
