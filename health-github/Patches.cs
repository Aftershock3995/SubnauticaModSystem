using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using seamothHealthModule;
using SMLHelper.V2.Handlers;
using System.Threading;

namespace patcher
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class HealthMod : BaseUnityPlugin
    {

        private const string myGUID = "com.aftershock.health";

        private const string pluginName = "health mod";

        private const string versionString = "1.0.0";
        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            logger = Logger;
            new SeamothHealthUpgrade().Patch();
            Logger.LogInfo("Mod Loaded Yippe!!");
        }
    }
}