using System;
using HarmonyLib;
using Il2Cpp;

namespace PerkShopFramework;

[HarmonyPatch(typeof(GraphUtils), "TryAcceptAll", new System.Type[]
{
	typeof(GraphNodeStorage),
	typeof(GameItem),
	typeof(int)
})]
internal static class PurchasedGraphTryAcceptAllPatch
{
	[HarmonyPrefix]
	private static bool Prefix(GameItem item)
	{
		return !PurchasedNativeInitialItemReplay.ShouldBlock(item);
	}
}
