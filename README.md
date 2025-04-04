# SynthMSAADisabler

This is a basic MSAA disabler for Synth Riders.

Since the v3 release of the game, MSAA is "baked" at 4x. Despite the MSAA option in the advanced settings menu existing--changing it does nothing.

## What does the mod do?

1. **Waits for the initial scene to Load**: The mod hooks in when the first scene loads (GameStart).
2. **Finds All Pipelines**: A Unity function is called to search for every URP asset.
3. **Targets the PC Pipeline**: Loops through the list and checks each pipeline’s name. When it finds `Ultra_PipelineAsset`—the one *Synth Riders* uses for PC—it stops there.
4. **Checks MSAA**: Prints the current/cold-boot MSAA setting (e.g., 4 for `_4x`) to the MelonLoader console.
5. **Disables MSAA**: If MSAA isn’t already off, the mod sets it to `Disabled` (value 1), prints the change to console, and stops.
6. **Skips if Not Found**: If `Ultra_PipelineAsset` isn’t there (rare), it prints a message and quits trying (i think).

## Installation

Make sure you have [MelonLoader](https://melonwiki.xyz/) installed, insructions can be found here - [https://wiki.synthriderz.com/en/guides/installing-mods](https://wiki.synthriderz.com/en/guides/installing-mods)

Next, grab the latest mod version from the [Releases] section, and place the '.dll' file in your 'SynthRiders/Mods/' folder.

Launch the game and check the MelonLoader console for logs like:

  [XX:XX:XX] Found pipeline: Ultra_PipelineAsset
  [XX:XX:XX] Boot MSAA is: 4
  [XX:XX:XX] MSAA set to: 1 (Disabled)

This will confirm MSAA has been disabled.

