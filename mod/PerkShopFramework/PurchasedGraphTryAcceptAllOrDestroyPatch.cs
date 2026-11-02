using System;
using HarmonyLib;

namespace PerkShopFramework;

[HarmonyPatch(typeof(GraphUtils), "TryAcceptAllOrDestroy", new System.Type[]
{
	typeof(GraphNodeStorage),
	typeof(GameItem),
	typeof(string)
})]
internal static class PurchasedGraphTryAcceptAllOrDestroyPatch
{
	[HarmonyPrefix]
	private static bool Prefix(GameItem item)
	{
		return !PurchasedNativeInitialItemReplay.ShouldBlock(item);
	}
}
