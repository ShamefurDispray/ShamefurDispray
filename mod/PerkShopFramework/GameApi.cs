using System;
using System.Collections.Generic;
using HarmonyLib;

namespace PerkShopFramework;

/// <summary>
/// Accessors for game members that the MelonLoader build could read directly but
/// that are private in the Mono build shipped with this version of the game.
/// </summary>
internal static class GameApi
{
	private static readonly AccessTools.FieldRef<CommissaryUIManager, List<CommissaryElement>> CommissaryElementsRef = AccessTools.FieldRefAccess<CommissaryUIManager, List<CommissaryElement>>("commissaryElements");

	internal static List<CommissaryElement> CommissaryElements(CommissaryUIManager manager)
	{
		if (manager == null)
		{
			return null;
		}
		try
		{
			return CommissaryElementsRef(manager);
		}
		catch (Exception ex)
		{
			PerkShopLog.Warning("Could not read CommissaryUIManager.commissaryElements: " + ex.Message);
			return null;
		}
	}
}
