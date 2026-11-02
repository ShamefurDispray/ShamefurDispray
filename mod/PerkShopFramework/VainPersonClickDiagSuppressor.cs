using HarmonyLib;

namespace PerkShopFramework;

internal static class VainPersonClickDiagSuppressor
{
	[HarmonyPrefix]
	private static bool Prefix()
	{
		return false;
	}
}
