using BepInEx.Logging;
using BepInEx;
using HarmonyLib;

namespace Aftershock
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class Main : BaseUnityPlugin
    {
        #region BEPINEX
        private const string myGUID = "AftershockPanel";
        private const string pluginName = "com.Aftershock3995SolarPanel";
        private const string versionString = "1.0.0";
        private static readonly Harmony harmony = new Harmony(myGUID);
        internal static ManualLogSource logger;
        #endregion

        public void Awake()

        {
            harmony.PatchAll();
            logger = Logger;
        }
    }
        //above is needed to make the mod work, who would have thought (trust me not me...)
    

[HarmonyPatch(typeof(SolarPanel), nameof(SolarPanel.Update))]
        //random patching shit, you probably need this

    public class SolarPanel_Update_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix(SolarPanel __instance)
        {
            __instance.maxDepth = 500f;
            __instance.biomeSunlightScale = 500f;
        //setting what the new maxDepth and biomeSunlightScale are

        //ErrorMessage.AddError($"DEPTH: {__instance.maxDepth} \nSCALE: {__instance.biomeSunlightScale}");   <----- for testing to see if the depth and scale are right
            
        }

    }
}
