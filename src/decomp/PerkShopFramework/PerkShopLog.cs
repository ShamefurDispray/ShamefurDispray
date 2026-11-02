using MelonLoader;

namespace PerkShopFramework;

internal static class PerkShopLog
{
	private const string Prefix = "[PerkShopFramework]";

	private static Instance? _logger;

	internal static void Initialize(Instance logger)
	{
		_logger = logger;
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
			string text = "[PerkShopFramework] " + level + ": " + message;
			if (_logger == null)
			{
				MelonLogger.Msg(text);
			}
			else if (level == "Warning")
			{
				_logger.Warning(text);
			}
			else if (level == "Error")
			{
				_logger.Error(text);
			}
			else
			{
				_logger.Msg(text);
			}
		}
		catch
		{
		}
	}
}
