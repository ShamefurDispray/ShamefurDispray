using System;
using Il2Cpp;
using UnityEngine;

namespace PerkShopFramework;

internal static class PurchasedContentInventoryGrantRedirectPatch
{
	private static bool Prefix(string identifier)
	{
		PerkShopMod instance = PerkShopMod.Instance;
		if (instance == null || !instance.IsApplyingPurchasedContent || string.IsNullOrEmpty(identifier))
		{
			return true;
		}
		try
		{
			EmporiumEntry instance2 = EmporiumEntry.Instance;
			if ((Object)(object)instance2 == (Object)null || instance2.invElement == null)
			{
				return true;
			}
			GameItem val = DirectoryMaster.Item(identifier, true);
			if (val == null)
			{
				return true;
			}
			val.DisableTag("TAG_NOT_PURCHASED", true);
			val.DisableTag("not_purchased", true);
			return !instance.RoutePurchasedItemToPlayerOrCounter(val);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("特性 mod 发放入口重定向失败：" + identifier + "：" + ex.Message);
			return true;
		}
	}
}
