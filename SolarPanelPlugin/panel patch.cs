using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using SolarPanelThingy;

namespace Aftershock
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class Main : BaseUnityPlugin
    {
        #region BEPINEX
        private const string myGUID = "com.Aftershock3995";
        private const string pluginName = "Solar_Panel_Plugin";
        private const string versionString = "1.0.0";
        private static readonly Harmony harmony = new Harmony(myGUID);
        internal static ManualLogSource logger;
        #endregion

        public void Awake()

        {
            harmony.PatchAll();
            logger = Logger;
            PluginConfig.Initialize(Config);
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
            __instance.biomeSunlightScale = 1000f;
        //setting what the new maxDepth and biomSunlightScale are

        //ErrorMessage.AddError($"DEPTH: {__instance.maxDepth} \nSCALE: {__instance.biomeSunlightScale}");   <----- for testing to see if the depth and scale are right
            
        }

    }
}