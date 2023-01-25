using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using KnifeDamageMod_SN;
using UnityEngine;
using Logger = QModManager.Utility.Logger;

namespace KnifeDamageMod_SN
{
    internal class KnifeDamageMod
    {
        [HarmonyPatch(typeof(PlayerTool))]
        [HarmonyPatch("OnDraw")]
        internal class PatchPlayerToolAwake

        {
            [HarmonyPostfix]

            public static void Postfix(PlayerTool __instance)
            {
                if (__instance.GetType() == typeof(Knife))
                {
                    Knife knife = __instance as Knife;

                    float damage = QMod.config.knifeDamage;
                    float reach = QMod.config.knifeRange;

                    knife.damage = damage * 25f;
                    knife.attackDist = reach * 2f;
                }
                else if (__instance.GetType() == typeof(HeatBlade))
                {
                    HeatBlade heatblade = __instance as HeatBlade;

                    heatblade.attackDist = QMod.config.knifeRange * 2f;
                    heatblade.damage = QMod.config.knifeDamage * 25f;
                }
            }
        }
    }
}