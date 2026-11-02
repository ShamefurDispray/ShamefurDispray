using System;
using HarmonyLib;
using Il2Cpp;

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
