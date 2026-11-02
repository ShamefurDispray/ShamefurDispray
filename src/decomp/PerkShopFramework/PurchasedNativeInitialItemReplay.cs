using System;
using System.Collections.Generic;
using Il2Cpp;

namespace PerkShopFramework;

internal static class PurchasedNativeInitialItemReplay
{
	private static readonly HashSet<string> BaseInitialItemIds;

	private static bool _active;

	internal static void Begin()
	{
		_active = true;
	}

	internal static void End()
	{
		_active = false;
	}

	internal static bool ShouldBlock(GameItem? item)
	{
		if (!_active || item == null)
		{
			return false;
		}
		try
		{
			string text = (item.identifier ?? string.Empty).TrimEnd('\0');
			return BaseInitialItemIds.Contains(text);
		}
		catch
		{
			return false;
		}
	}

	static PurchasedNativeInitialItemReplay()
	{
		HashSet<string> obj = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		obj.Add("storage_bay");
		obj.Add("processed_meat");
		obj.Add("processed_juice");
		obj.Add("toothpaste");
		obj.Add("toilet_paper");
		obj.Add("sign_food");
		obj.Add("sign_household");
		obj.Add("dossier");
		obj.Add("mentor_contract");
		obj.Add("trashcan");
		BaseInitialItemIds = obj;
	}
}
