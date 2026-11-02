using System;
using System.Collections.Generic;

namespace PerkShopFramework;

internal static class PerSaveState
{
	private const string Prefix = "psfw.";

	private static Dictionary<string, string> Data(PlayerStore store)
	{
		if (store.modData != null)
		{
			return store.modData;
		}
		store.modData = new Dictionary<string, string>();
		return store.modData;
	}

	internal static string? GetString(PlayerStore store, string key)
	{
		try
		{
			string text = default(string);
			return Data(store).TryGetValue("psfw." + key, out text) ? text : null;
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("读取存档状态失败：" + key + "，" + ex.Message);
			return null;
		}
	}

	internal static int GetInt(PlayerStore store, string key, int fallback = 0)
	{
		int result = default(int);
		if (!int.TryParse(GetString(store, key), out result))
		{
			return fallback;
		}
		return result;
	}

	internal static long GetLong(PlayerStore store, string key, long fallback = 0L)
	{
		long result = default(long);
		if (!long.TryParse(GetString(store, key), out result))
		{
			return fallback;
		}
		return result;
	}

	internal static void SetString(PlayerStore store, string key, string value)
	{
		try
		{
			Data(store)["psfw." + key] = value ?? string.Empty;
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("写入存档状态失败：" + key + "，" + ex.Message);
		}
	}

	internal static void SetInt(PlayerStore store, string key, int value)
	{
		SetString(store, key, value.ToString());
	}

	internal static void SetLong(PlayerStore store, string key, long value)
	{
		SetString(store, key, value.ToString());
	}

	internal static void Remove(PlayerStore store, string key)
	{
		try
		{
			Data(store).Remove("psfw." + key);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("删除存档状态失败：" + key + "，" + ex.Message);
		}
	}

	internal static void RemoveByPrefix(PlayerStore store, string keyPrefix)
	{
		try
		{
			Dictionary<string, string> val = Data(store);
			List<string> val2 = new List<string>();
			foreach (KeyValuePair<string, string> current in val)
			{
				if (current.Key.StartsWith("psfw." + keyPrefix, (StringComparison)4))
				{
					val2.Add(current.Key);
				}
			}
			for (int i = 0; i < val2.Count; i++)
			{
				val.Remove(val2[i]);
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("按前缀删除存档状态失败：" + keyPrefix + "，" + ex.Message);
		}
	}
}
