using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using PluginConfigs;

namespace Aftershock
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class Main : BaseUnityPlugin
    {
        #region BEPINEX
        private const string myGUID = "com.Aftershock3995.AftershockCannon";
        private const string pluginName = "Propulsion Cannon Plugin";
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
  
    [HarmonyPatch(typeof(PropulsionCannon), nameof(PropulsionCannon.OnDisable))]

    public class PropulsionCannon_Update_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix(PropulsionCannon __instance)
        {
            __instance.pickupDistance = PluginConfig.pickupDistance.Value;
            __instance.maxMass = PluginConfig.maxMass.Value;
            __instance.shootForce = PluginConfig.shootForce.Value;

        }

    }
}