using System;
using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.EventSystems;

namespace PerkShopFramework;

[HarmonyPatch(typeof(StartingPerkElement), "OnPointerClick", new System.Type[] { typeof(PointerEventData) })]
internal static class StartingPerkClickFixPatch
{
	[HarmonyPrefix]
	[HarmonyPriority(800)]
	private static void Prefix()
	{
		try
		{
			if (!((Object)(object)PerkUIController.Instance == (Object)null))
			{
				NewGameData instance = NewGameData.Instance;
				if ((Object)(object)instance != (Object)null && !instance.isInMainMenu)
				{
					instance.isInMainMenu = true;
				}
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("StartingPerk click fix failed: " + ex.Message);
		}
	}
}
