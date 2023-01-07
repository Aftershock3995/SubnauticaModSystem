using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using KnifeDamageMod_SN;

namespace KnifeDamageMod_SN
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class Main : BaseUnityPlugin
    {
        #region BEPINEX
        private const string myGUID = "com.Aftershock3995";
        private const string pluginName = "Knife Damage & Distance";
        private const string versionString = "1.2.0";
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

}
    internal class KnifeDamageMod
{
    [HarmonyPatch(typeof(PlayerTool))]
    [HarmonyPatch("OnDraw")]
    internal class PatchPlayerToolAwake
    {
        [HarmonyPostfix]
        public static void Postix(PlayerTool __instance)
        {
            {
                if (__instance.GetType() == typeof(Knife))
                {
                    Knife knife = __instance as Knife;

                    knife.damage = PluginConfig.knifeDamage.Value;
                    knife.attackDist = PluginConfig.knifeDistance.Value;
                }
                else if (__instance.GetType() == typeof(HeatBlade))
                {
                    HeatBlade heatblade = __instance as HeatBlade;

                    heatblade.damage = PluginConfig.heatDamage.Value;
                    heatblade.attackDist = PluginConfig.heatDistance.Value;
                }
            }
        }
    }
}
