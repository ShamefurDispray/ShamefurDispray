using System;
using HarmonyLib;
using Il2Cpp;

namespace PerkShopFramework;

[HarmonyPatch(typeof(CommissaryUIManager), "CloseUI")]
internal static class PerkShopCommissaryClosePatch
{
	private static void Postfix()
	{
		try
		{
			PerkShopMod.Instance?.OnCommissaryClosed();
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("Commissary CloseUI 补丁失败：" + (object)ex);
		}
	}
}
