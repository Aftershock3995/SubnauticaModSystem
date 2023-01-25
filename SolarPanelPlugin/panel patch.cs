using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Aftershock
{
    [BepInPlugin("com.Aftershock3995.AftershockPanel", "Solar Panel Plugin", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public void Awake()
        {
            logger = Logger;
            Main.harmony.PatchAll();
        }

        private const string myGUID = "com.Aftershock3995.AftershockPanel";

        private const string pluginName = "Solar Panel Plugin";

        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony("com.Aftershock3995.AftershockPanel");

        internal static ManualLogSource logger = new ManualLogSource("Solar_Panel");
    }
}
