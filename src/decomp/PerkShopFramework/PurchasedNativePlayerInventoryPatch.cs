using HarmonyLib;
using Il2Cpp;

namespace PerkShopFramework;

[HarmonyPatch(typeof(EmporiumEntry), "TryAddToPlayerInv")]
internal static class PurchasedNativePlayerInventoryPatch
{
	[HarmonyPrefix]
	private static bool Prefix(GameItem gameItem)
	{
		return !PurchasedNativeInitialItemReplay.ShouldBlock(gameItem);
	}
}
