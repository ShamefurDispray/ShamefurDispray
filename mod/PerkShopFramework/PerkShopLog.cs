using System;

namespace PerkShopFramework;

internal static class PerkShopLog
{
	private static ModLog? _modLog;

	internal static void Initialize(ModLog? modLog)
	{
		_modLog = modLog;
	}

	internal static void Msg(string message)
	{
		Write("Msg", message);
	}

	internal static void Warning(string message)
	{
		Write("Warning", message);
	}

	internal static void Error(string message)
	{
		Write("Error", message);
	}

	internal static void Debug(string message)
	{
		Write("Debug", message);
	}

	private static void Write(string level, string message)
	{
		try
		{
			string text = level + ": " + message;
			if (_modLog != null)
			{
				if (level == "Warning")
				{
					_modLog.Warning(text);
				}
				else if (level == "Error")
				{
					_modLog.Error(text);
				}
				else
				{
					_modLog.Log(text);
				}
			}
			else if (level == "Warning")
			{
				UnityEngine.Debug.LogWarning("[PerkShopFramework] " + text);
			}
			else if (level == "Error")
			{
				UnityEngine.Debug.LogError("[PerkShopFramework] " + text);
			}
			else
			{
				UnityEngine.Debug.Log("[PerkShopFramework] " + text);
			}
		}
		catch
		{
		}
	}
}
