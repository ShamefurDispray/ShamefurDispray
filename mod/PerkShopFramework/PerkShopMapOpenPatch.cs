using System;
using HarmonyLib;

namespace PerkShopFramework;

/// <summary>
/// The MelonLoader build patched MapUIManager.Bazar to clone a map button.
/// That method no longer exists: the map is now the transit UI, which lists
/// AfterhourLocation entries, so the shop registers itself as a location and
/// this hook only re-checks that the registration is in place when the map opens.
/// </summary>
[HarmonyPatch(typeof(MapUIManager), "OpenUI")]
internal static class PerkShopMapOpenPatch
{
	private static void Postfix()
	{
		try
		{
			PerkShopMod.Instance?.EnsureNativeButton(MapUIManager.Instance);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("OpenUI 补丁失败：" + (object)ex);
		}
	}
}
