using System;
using System.Collections;
using HarmonyLib;
using UnityEngine;

namespace PerkShopFramework;

/// <summary>
/// Entry point for the game's native mod loader. The loader patches every
/// [HarmonyPatch] class in this assembly itself, then calls Init and OnEnable.
/// </summary>
public sealed class PerkShopModEntry : IMod
{
	internal static string ModId = "PerkShopFramework";

	internal static ModManifest? Manifest;

	private static Harmony? _harmony;

	private PerkShopRunner? _runner;

	public void Init(ModManifest manifest)
	{
		Manifest = manifest;
		if (!string.IsNullOrEmpty(manifest?.ID))
		{
			ModId = manifest.ID;
		}
		PerkShopLog.Initialize(new ModLog(manifest));
		try
		{
			PerkShopLog.Msg("开始初始化。");
			_harmony = new Harmony("mod." + ModId);
			PerkShopMod.Initialize(_harmony);
			PerkShopLog.Msg("初始化完成。");
		}
		catch (Exception ex)
		{
			PerkShopLog.Error("初始化失败：" + ex);
		}
	}

	public void OnEnable()
	{
		try
		{
			if (_runner == null)
			{
				GameObject host = new GameObject("PerkShopFramework.Runner");
				UnityEngine.Object.DontDestroyOnLoad(host);
				_runner = host.AddComponent<PerkShopRunner>();
			}
			_runner.enabled = true;
		}
		catch (Exception ex)
		{
			PerkShopLog.Error("启用失败：" + ex);
		}
	}

	public void OnDisable()
	{
		try
		{
			if (_runner != null)
			{
				_runner.enabled = false;
			}
			PerkShopMod.Shutdown();
			_harmony?.UnpatchAll(_harmony.Id);
			PerkShopLog.Msg("已卸载。");
		}
		catch (Exception ex)
		{
			PerkShopLog.Error("卸载失败：" + ex);
		}
	}
}

/// <summary>
/// Hosts the per-frame update, the IMGUI pass and coroutines that the mod used
/// to get from MelonLoader.
/// </summary>
internal sealed class PerkShopRunner : MonoBehaviour
{
	private static PerkShopRunner? _instance;

	private void Awake()
	{
		_instance = this;
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
	}

	private void Update()
	{
		try
		{
			PerkShopMod.Update();
		}
		catch (Exception ex)
		{
			PerkShopLog.Error("OnUpdate 失败：" + ex);
		}
	}

	private void OnGUI()
	{
		try
		{
			PerkShopMod.DrawGuiRoot();
		}
		catch (Exception ex)
		{
			PerkShopLog.Error("OnGUI 失败：" + ex);
		}
	}

	internal static void Start(IEnumerator routine)
	{
		if (routine == null)
		{
			return;
		}
		if (_instance == null)
		{
			PerkShopLog.Warning("宿主未就绪，协程未启动。");
			return;
		}
		_instance.StartCoroutine(routine);
	}
}
