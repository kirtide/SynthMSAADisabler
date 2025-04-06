# SynthMSAADisabler

A simple MelonLoader mod to disable MSAA (`Multisample anti-aliasing`) in *Synth Riders* `v3` on PC, with potential use in other Unity games.

## Why?

Since the `v3` release of *Synth Riders*, MSAA defaults to `4x`. Despite the MSAA option within the `advanced graphics settings` menu existing—changing it does nothing.

In VR, `4x` MSAA can be resource intensive (VRAM and more), so this mod offers a quick workaround by turning it off.

This might also help other Unity games if they:
- Use MelonLoader v0.6.6+
- Are IL2CPP-based
- Run on .NET 6
- Use URP 

## What Does It Do?
1. **Waits for Scene Load**: Initiates at the first scene (e.g., `GameStart`).
   
2. **Finds All Pipelines**: Calls `Resources.FindObjectsOfTypeAll<UniversalRenderPipelineAsset>()` to list all URP assets in memory.
   
3. **Targets the PC Pipeline**: Loops through, stops at the most likely current pipeline, or `Ultra_PipelineAsset`—what *Synth Riders* uses for PC, then prints to console.
   
4. **Checks MSAA**: Prints the starting MSAA value (e.g., `4` for `4x`).
   
5. **Disables MSAA**: Sets it to `1` (Disabled) if it’s not already, then prints the change.
    
6. **Skips if Missing**: Prints a note and stops if no pipeline is found.

## Installation

1. Make sure you have [MelonLoader](https://melonwiki.xyz/) installed (at least `v0.6.6`), *Synth Riders* specific instructions can be found here - [https://wiki.synthriderz.com/en/guides/installing-mods](https://wiki.synthriderz.com/en/guides/installing-mods)

2. Next, grab the latest mod version from the [Releases](https://github.com/kirtide/SynthMSAADisabler/releases) section, and place the `MSAA_Disabler.dll` file in your `SynthRiders/Mods/` folder.

3. Launch the game and check the MelonLoader console for logs like:

- [XX:XX:XX] Found pipeline: Ultra_PipelineAsset
- [XX:XX:XX] Boot MSAA is: 4
- [XX:XX:XX] MSAA set to: 1 (Disabled)

This will confirm MSAA has been disabled!

## Special Thanks

- [UnityExplorer](https://github.com/sinai-dev/UnityExplorer)
- [xAI](https://x.ai/)
