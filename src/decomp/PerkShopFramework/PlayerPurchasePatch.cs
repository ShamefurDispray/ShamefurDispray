using System;
using HarmonyLib;
using Il2Cpp;

namespace PerkShopFramework;

[HarmonyPatch(typeof(PlayerStore), "OnItemBought", new System.Type[]
{
	typeof(GameItem),
	typeof(int)
})]
internal static class PlayerPurchasePatch
{
	private static void Postfix(GameItem gameItem, int cost)
	{
		try
		{
			PerkShopMod.AddPurchaseVolume(gameItem, cost);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("PlayerPurchasePatch 失败：" + (object)ex);
		}
	}
}
