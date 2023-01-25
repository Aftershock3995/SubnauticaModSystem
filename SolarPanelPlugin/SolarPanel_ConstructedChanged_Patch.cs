using System;
using HarmonyLib;

namespace Aftershock
{
    
    [HarmonyPatch(typeof(SolarPanel), "IConstructable.OnConstructedChanged")]
    public class SolarPanel_ConstructedChanged_Patch
    {      
        [HarmonyPrefix]
        private static bool PreFix(SolarPanel __instance, bool constructed)
        {
            __instance.maxDepth = 500f;
            return true;
        }
    }
}