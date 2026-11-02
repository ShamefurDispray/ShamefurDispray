using System;
using HarmonyLib;

namespace PerkShopFramework;

[HarmonyPatch(typeof(GraphUtils), "EmporiumTryAdd", new System.Type[]
{
	typeof(GraphNodeStorage),
	typeof(GameItem)
})]
internal static class PurchasedGraphEmporiumTryAddPatch
{
	[HarmonyPrefix]
	private static bool Prefix(GameItem item)
	{
		return !PurchasedNativeInitialItemReplay.ShouldBlock(item);
	}
}
