using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using Logger = QModManager.Utility.Logger;

using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Handlers;

namespace KnifeDamageMod_SN
{
    [QModCore]
    public static class QMod
    {

        internal static Config config { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();
        [QModPatch]
        public static void Patch()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var testMod = ($"Aftershock3995{assembly.GetName().Name}");
            Logger.Log(Logger.Level.Info, $"Patching {testMod}");
            Harmony harmony = new Harmony(testMod);
            harmony.PatchAll(assembly);
            Logger.Log(Logger.Level.Info, "Patched successfully!");
        }
    }
    [Menu("KnifeDamageMod")]
    public class Config : ConfigFile
    {
        
        [Slider("knife damage", Format = "{0:F2}", Min = 0.0F, Max = 100.0F, DefaultValue = 1.0F, Step = 0.5F, Tooltip = "Sets the max damage")]
        public float knifeDamage = 1.0f;
        [Slider("knife distance", Format = "{0:F2}", Min = 0.0F, Max = 100.0F, DefaultValue = 1.0F, Step = 0.5F, Tooltip = "Sets the max distance")]
        public float knifeRange = 1.0f;
      
    }
}