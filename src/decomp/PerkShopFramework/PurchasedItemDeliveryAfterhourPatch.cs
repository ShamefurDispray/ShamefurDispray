using System;
using HarmonyLib;
using Il2Cpp;

namespace PerkShopFramework;

[HarmonyPatch(typeof(EmporiumEntry), "TryAddToAfterhourInv")]
internal static class PurchasedItemDeliveryAfterhourPatch
{
	[HarmonyPrefix]
	private static bool Prefix(GameItem gameItem)
	{
		try
		{
			PerkShopMod instance = PerkShopMod.Instance;
			if (instance == null || !instance.IsApplyingPurchasedContent)
			{
				return true;
			}
			return !instance.RoutePurchasedItemToPlayerOrCounter(gameItem);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("TryAddToAfterhourInv 补丁失败：" + (object)ex);
			return true;
		}
	}
}
