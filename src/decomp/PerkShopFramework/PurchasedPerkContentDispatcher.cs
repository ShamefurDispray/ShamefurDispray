using System;
using System.Collections.Generic;
using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace PerkShopFramework;

internal static class PurchasedPerkContentDispatcher
{
	private const string PendingPrefix = "PendingContent.";

	private const string AppliedPrefix = "AppliedContent.";

	private static readonly object Gate = new object();

	private static readonly Queue<string> Pending = new Queue<string>();

	private static readonly HashSet<string> PendingSet = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.Ordinal);

	private static int _queuedFrame = -1;

	internal static void Queue(PlayerStore store, StartingPerk perk)
	{
		try
		{
			string text = NormalizeId((perk != null) ? perk.id : null);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			lock (Gate)
			{
				if (PendingSet.Add(text))
				{
					Pending.Enqueue(text);
				}
				_queuedFrame = Time.frameCount;
				PerSaveState.SetInt(store, "PendingContent." + text, 1);
				PerkShopLog.Msg("已排队购买天赋内容：" + text);
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("排队购买天赋内容失败：" + (object)ex);
		}
	}

	internal static void ResetStateForLoad()
	{
		lock (Gate)
		{
			Pending.Clear();
			PendingSet.Clear();
			_queuedFrame = -1;
		}
		PerkShopMod.Instance?.SetApplyingPurchasedContent(value: false);
	}

	internal static void Tick()
	{
		if (Pending.Count == 0 || _queuedFrame < 0 || Time.frameCount - _queuedFrame < 2 || !PerkShopMod.CanApplyPurchasedContent())
		{
			return;
		}
		PlayerStore currentStoreForDispatcher = PerkShopMod.GetCurrentStoreForDispatcher();
		if (currentStoreForDispatcher == null || currentStoreForDispatcher.startingPerks == null)
		{
			return;
		}
		string text;
		lock (Gate)
		{
			if (Pending.Count == 0)
			{
				return;
			}
			text = Pending.Peek();
		}
		StartingPerk val = FindPerk(currentStoreForDispatcher, text);
		if (val == null)
		{
			lock (Gate)
			{
				Pending.Dequeue();
				PendingSet.Remove(text);
				PerSaveState.SetInt(currentStoreForDispatcher, "PendingContent." + text, 0);
			}
			PerkShopLog.Warning("待处理天赋不在 startingPerks 中，已移除队列：" + text);
		}
		else if (ApplyOne(currentStoreForDispatcher, val, text))
		{
			lock (Gate)
			{
				Pending.Dequeue();
				PendingSet.Remove(text);
				PerSaveState.SetInt(currentStoreForDispatcher, "PendingContent." + text, 0);
				PerSaveState.SetInt(currentStoreForDispatcher, "AppliedContent." + text, 1);
				_queuedFrame = Time.frameCount;
			}
			PerkShopMod.Instance?.MarkSavePending();
			PerkShopLog.Msg("已应用购买天赋内容：" + text);
		}
	}

	private static bool ApplyOne(PlayerStore store, StartingPerk perk, string id)
	{
		List<StartingPerk> startingPerks = store.startingPerks;
		if (startingPerks == null)
		{
			return false;
		}
		NewGameData instance = NewGameData.Instance;
		List<StartingPerk> startingPerks2 = ((instance != null) ? instance.startingPerks : null);
		List<StartingPerk> val = new List<StartingPerk>();
		val.Add(perk);
		store.startingPerks = val;
		if ((Object)(object)instance != (Object)null)
		{
			instance.startingPerks = val;
		}
		PerkShopMod.Instance?.SetApplyingPurchasedContent(value: true);
		try
		{
			PurchasedPerkProviderBinding purchasedPerkProviderBinding = PurchasedPerkProviderRegistry.Resolve(id);
			purchasedPerkProviderBinding.ApplyBeforeInitial(store, perk, id);
			RunInitialItemPostfixReplay(purchasedPerkProviderBinding.AssemblyName);
			StartingPerkContent.HandleNewGamePerk();
			purchasedPerkProviderBinding.ApplyAfterInitial(store, perk, id);
			if (string.Equals(id, "sawyer_crew", (StringComparison)4))
			{
				PerkShopMod.Instance?.ScheduleSawyerAfterPurchase(store);
			}
			return true;
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("应用购买天赋内容失败：" + id + "，" + (object)ex);
			return false;
		}
		finally
		{
			PerkShopMod.Instance?.SetApplyingPurchasedContent(value: false);
			store.startingPerks = startingPerks;
			if ((Object)(object)instance != (Object)null)
			{
				instance.startingPerks = startingPerks2;
			}
		}
	}

	private static void RunInitialItemPostfixReplay(string assemblyName)
	{
		PurchasedPerkLifecycleReplay.ApplyHandleInitialItemPostfixes(assemblyName);
	}

	private static StartingPerk? FindPerk(PlayerStore store, string id)
	{
		try
		{
			List<StartingPerk> startingPerks = store.startingPerks;
			if (startingPerks == null)
			{
				return null;
			}
			for (int i = 0; i < startingPerks.Count; i++)
			{
				StartingPerk val = startingPerks[i];
				if (val != null && string.Equals(NormalizeId(val.id), id, (StringComparison)4))
				{
					return val;
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static string NormalizeId(string? id)
	{
		return (id ?? string.Empty).TrimEnd('\0');
	}
}
