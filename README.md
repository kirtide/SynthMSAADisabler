# SynthMSAADisabler

This mod is a basic MSAA disabler for Synth Riders.

## Why?

Since the v3 release of the game, MSAA is "baked" at 4x. Despite the MSAA option within the advanced graphics settings menu existing-changing it does nothing.

Having MSAA running at 4x, especially in VR, is and can be very resource intensive.

While it would be possible for a mod to fix this button itself, I decided to keep it simple and completely disable MSAA. 

(totally because its out-of-scope and not because i can barely program)

## What does the mod do?

1. **Waits for the initial scene to Load**: The mod hooks in when the first scene loads (GameStart).
2. **Finds All Pipelines**: The following function `Resources.FindObjectsOfTypeAll<UniversalRenderPipelineAsset>()` is called to search for every URP asset.
3. **Targets the PC Pipeline**: Loops through the list and checks each pipeline’s name. When it finds `Ultra_PipelineAsset`—the one *Synth Riders* uses for PC—it stops there.
4. **Checks MSAA**: Prints the current/cold-boot MSAA setting (e.g., 4 for `4x`) to the MelonLoader console.
5. **Disables MSAA**: If MSAA isn’t already off, the mod sets it to `Disabled` (value 1), prints the change to console, and stops.
6. **Skips if Not Found**: If `Ultra_PipelineAsset` isn’t there (rare), it prints a message and quits trying (i think).

## Installation

1. Make sure you have [MelonLoader](https://melonwiki.xyz/) installed, instructions can be found here - [https://wiki.synthriderz.com/en/guides/installing-mods](https://wiki.synthriderz.com/en/guides/installing-mods)

22. Next, grab the latest mod version from the [Releases](https://github.com/kirtide/SynthMSAADisabler/releases) section, and place the '.dll' file in your 'SynthRiders/Mods/' folder.

3. Launch the game and check the MelonLoader console for logs like:

- [XX:XX:XX] Found pipeline: Ultra_PipelineAsset
- [XX:XX:XX] Boot MSAA is: 4
- [XX:XX:XX] MSAA set to: 1 (Disabled)

This will confirm MSAA has been disabled!

## Special Thanks

- [UnityExplorer](https://github.com/sinai-dev/UnityExplorer)
