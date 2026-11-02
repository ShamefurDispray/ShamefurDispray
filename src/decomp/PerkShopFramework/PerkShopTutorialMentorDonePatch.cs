using System;
using HarmonyLib;
using Il2Cpp;

namespace PerkShopFramework;

[HarmonyPatch(typeof(TutorialUIManager), "OnMentorDone")]
internal static class PerkShopTutorialMentorDonePatch
{
	[HarmonyPostfix]
	private static void Postfix()
	{
		try
		{
			PerkShopMod.Instance?.OnNativeTutorialMentorDone();
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("TutorialUIManager.OnMentorDone 补丁失败：" + (object)ex);
		}
	}
}
