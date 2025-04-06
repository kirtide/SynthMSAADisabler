using MelonLoader;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace SynthMSAA
{
    public class MSAAMod : MelonMod
    {
        private bool noMSAA = false;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (!noMSAA)
            {
                ForceMSAA();
                //have it load in its own function, it looks nicer on the console lol
            }
        }

        private void ForceMSAA()
        {
            var urpAssets = Resources.FindObjectsOfTypeAll<UniversalRenderPipelineAsset>(); //indexes all or most loaded pipelines in memory idk
            foreach (var urpAsset in urpAssets) //make available
            {
                MelonLogger.Msg($"Found pipeline: {urpAsset.name}"); //prints actual name of pipeline
                //at this point, we are assuming this is the current and only active pipeline
                //this part will likely change if found inaccurate, if so we'll need to index all available pipelines in memory, then run something like a switch case
                MelonLogger.Msg($"Boot MSAA is: {urpAsset.msaaSampleCount}");
                if (urpAsset.msaaSampleCount != (int)MsaaQuality.Disabled) //simple int check, if no equals do the following
                {
                    urpAsset.msaaSampleCount = (int)MsaaQuality.Disabled; //sets the integer value to 1
                    MelonLogger.Msg($"MSAA set to: {urpAsset.msaaSampleCount} (Disabled)");
                    noMSAA = true; //we're done
                }
                else
                {
                    MelonLogger.Msg("MSAA already Disabled");
                }
                return;
            }
            MelonLogger.Msg("Ultra_PipelineAsset not found among URP assets");
            noMSAA = true; //couldnt find pc pipeline, this is a possibly unneeded preventative step
        }
    }
}