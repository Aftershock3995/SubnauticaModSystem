using System;
using HarmonyLib;
using UnityEngine;

namespace Aftershock
{
   
    [HarmonyPatch(typeof(SolarPanel), "GetDepthScalar")]
    public class SolarPanel_DepthScalar_Patch
    {
        [HarmonyPrefix]
        private static bool PreFix(SolarPanel __instance, ref float __result)
        {
            float num = Mathf.Clamp01((__instance.maxDepth - Ocean.GetDepthOf(__instance.gameObject)) / (__instance.maxDepth / 2f));
            __result = __instance.depthCurve.Evaluate(num);
            return false;
        }
    }
}