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
                if (urpAsset.name == "Ultra_PipelineAsset") //must be the pc pipeline, this check could be skipped
                {
                    MelonLogger.Msg($"Found pipeline: {urpAsset.name}"); //prints actual name of pipeline
                    MelonLogger.Msg($"Boot MSAA is: {urpAsset.msaaSampleCount}"); //prints bootup msaa setting
                    if (urpAsset.msaaSampleCount != (int)MsaaQuality.Disabled) //simple int check
                    {
                        urpAsset.msaaSampleCount = (int)MsaaQuality.Disabled; //sets the integer value to 1
                        MelonLogger.Msg($"MSAA set to Disabled ({urpAsset.msaaSampleCount})");
                        noMSAA = true; //properly disabled
                    }
                    else
                    {
                        MelonLogger.Msg("MSAA already Disabled");
                    }
                    return;
                }
            }
            MelonLogger.Msg("Ultra_PipelineAsset not found among URP assets");
            noMSAA = true; //couldnt find pc pipeline, possibly prevents forking
        }
    }
}