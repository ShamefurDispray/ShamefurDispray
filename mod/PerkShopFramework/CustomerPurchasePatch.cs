using System;
using HarmonyLib;

namespace PerkShopFramework;

[HarmonyPatch(typeof(StoreClient), "OnItemBought", new System.Type[]
{
	typeof(GameItem),
	typeof(int)
})]
internal static class CustomerPurchasePatch
{
	private static void Postfix(GameItem item, int cost)
	{
		try
		{
			PerkShopMod.AddSaleVolume(item, cost);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("CustomerPurchasePatch 失败：" + (object)ex);
		}
	}
}
