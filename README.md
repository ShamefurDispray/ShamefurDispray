# PerkShopFramework — native mod port

This repo turns the MelonLoader mod `PerkShopFramework.dll` into a mod for the game's
own mod loader (`manifest.xml` + `IMod` + the game's Harmony). The mod no longer needs
MelonLoader, and it no longer targets the IL2CPP build of the game.

## Install

Copy the folder `dist/PerkShopFramework` into

```
Probably Stolen/Mods/PerkShopFramework/
    manifest.xml
    PerkShopFramework.dll
```

Start the game, open the Mods menu, approve the `reflection-external` capability and
enable the mod. A full restart is required the first time.

Settings are available from the Mods menu (they are stored in
`%UserProfile%/AppData/LocalLow/Questing Goose Studio/Probably Stolen/ModConfigs/PerkShopFramework.json`
through the game's own `ModConfig`).

## What changed

| MelonLoader (old) | Native API (new) |
| --- | --- |
| `Core : MelonMod`, `OnInitializeMelon` / `OnUpdate` / `OnDeinitializeMelon` | `PerkShopModEntry : IMod` with `Init` / `OnEnable` / `OnDisable` |
| `MelonCoroutines.Start` | `PerkShopRunner.Start` (a hidden `MonoBehaviour` that is `DontDestroyOnLoad`) |
| `MelonEvents.OnGUI` subscribe / unsubscribe | the same `MonoBehaviour`'s `OnGUI` |
| `MelonPreferences` category + entries | `ModConfig.For(modId).Define(...)`, which also gives the mod a settings page in the Mods menu |
| `MelonLogger` | the game's `ModLog` (falls back to `UnityEngine.Debug`) |
| `Il2CppSystem.Collections.Generic` | `System.Collections.Generic` |
| `Il2CppArrayBase<T>`, `Il2CppStringArray`, `UnityAction.op_Implicit`, `WindowFunction.op_Implicit` | plain arrays and delegate construction |
| `MelonInfo` / `MelonGame` attributes | `manifest.xml` |

The mod used to be built against the IL2CPP version of the game. This install is the
Mono build, so types live in the global namespace instead of `Il2Cpp.*`. Places that
depended on that are fixed, notably `PurchasedPerkLifecycleReplay`, which matched
`DeclaringType.FullName` against `"Il2Cpp.PlayerStore"` / `"Il2Cpp.GameMaster"`; it now
matches `DeclaringType.Name` against `"PlayerStore"` / `"GameMaster"`.

### Game members that moved in this game version

* `CommissaryUIManager.commissaryElements` is private here → read through
  `GameApi.CommissaryElements` (a cached `AccessTools.FieldRef`).
* `StoreClientInstance.storeClient` is private here → uses the public
  `GetClientBlueprint()`.
* `MapUIManager.Bazar` and the `upgradeMerchantButton` / `dumpingGroundButton` /
  `bazarButton` objects no longer exist: the map is now the transit UI, which lists
  `AfterhourLocation` entries. The old "clone the upgrade button" code was dead in the
  MelonLoader build too (nothing called `EnsureNativeButton`), so the shop now
  registers a real `DelegateAfterhourLocation` (`id = "perkshop"`) through
  `ModHelper.AddAfterhourLocation`. Its panel has an **打开天赋商店** button, and
  arriving at the location opens the shop directly. `PerkShopMapOpenPatch` re-checks
  the registration when `MapUIManager.OpenUI` runs.

Everything else is a straight port: perk shop and pricing curve, starting perk fixes,
mentor dialogue events, commissary integration, purchase tracking and the
`psfw.*` save-state keys are untouched, so existing saves keep working.

## Layout

```
mod/                     native mod sources (build here)
  PerkShopFramework.csproj
  PerkShopModEntry.cs    IMod entry point + MonoBehaviour runner
  GameApi.cs             reflection accessor for private game members
  PerkShopMod.cs         the mod itself
  ...patches             [HarmonyPatch] classes, unchanged apart from the API fixes
dist/PerkShopFramework/  ready-to-install mod folder (manifest.xml + dll)
src/decomp/              ilspy output of the original MelonLoader dll (reference)
tools/validate/          harness that checks patch targets against Assembly-CSharp
```

Build (needs the game's `Managed` folder, unzipped to `managed/Managed`):

```
dotnet build mod/PerkShopFramework.csproj -c Release
```

`ManagedDir` can point somewhere else: `-p:ManagedDir=/path/to/Managed/`.

## How this was verified

`tools/validate` loads `Assembly-CSharp.dll` plus the built mod and checks:

* every `[HarmonyPatch]` target type and method exists (17/17 ok),
* every prefix/postfix parameter matches a target parameter name and type (0 problems),
* the mod references no `MelonLoader` / `Il2Cpp*` assembly,
* exactly one `IMod` implementation exists,
* `NewGameData.HandleInitialItem()`, used by the purchased-perk replay, still exists.

Not verifiable outside the game: `Harmony.PatchAll` itself. Running it in .NET 8 fails
with `MissingMethodException: ILGenerator.MarkSequencePoint` because the harness
runtime lacks an emit API that the game's Mono mscorlib *does* have (checked in
`managed/Managed/mscorlib.dll`), so the detours could only be exercised inside the game.

## Test checklist in game

1. Mods menu lists the mod, capability prompt appears, enable + restart.
2. Console shows `[PerkShopFramework] 初始化完成。` and `Native map location registered.`
3. Night → go outside → transit map shows the **天赋商店 / PerkShop** station → travel
   → the shop window opens (or use the panel button).
4. Buy a perk: points go down, the perk unlocks, pricing follows the configured curve.
5. Commissary panel still shows the 体悟 tab, returns to trading correctly.
6. Mentor dialogue appears and advances.
7. Save, reload: points, purchased perks and the `psfw.*` state survive.
