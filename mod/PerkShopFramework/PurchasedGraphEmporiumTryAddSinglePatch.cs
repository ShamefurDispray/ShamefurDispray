using System;
using HarmonyLib;

namespace PerkShopFramework;

[HarmonyPatch(typeof(GraphUtils), "EmporiumTryAdd", new System.Type[] { typeof(GameItem) })]
internal static class PurchasedGraphEmporiumTryAddSinglePatch
{
	[HarmonyPrefix]
	private static bool Prefix(GameItem item)
	{
		return !PurchasedNativeInitialItemReplay.ShouldBlock(item);
	}
}
