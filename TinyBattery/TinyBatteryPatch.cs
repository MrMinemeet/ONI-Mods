using HarmonyLib;
using System.Collections.Generic;
using System;
using TUNING;
using UnityEngine.Diagnostics;
using System.Reflection;
using static STRINGS.RESEARCH.TECHS;

namespace TinyBattery
{
    public class TinyBatteryPatch : KMod.UserMod2
    {
        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
        {
            public static void Prefix()
            {
                ModUtil.AddBuildingToPlanScreen("Power", TinyBatteryConfig.ID);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public static class Db_Initialize_Patch
        {
            public static void Postfix()
            {
                // Add the Tiny Battery to the Power Regulation tech research
                AddToResearch("PowerRegulation", TinyBatteryConfig.ID);
            }

            /// <summary>
            /// Adds a building to a tech research.
            /// </summary>
            /// <param name="techId">The tech to add it to.</param>
            /// <param name="buildingId">The building to add.</param>
            private static void AddToResearch(string techId, string buildingId)
            {
                Tech tech = Db.Get()?.Techs.TryGet(techId);

                if (tech != null)
                {
                    tech.unlockedItemIDs.Add(buildingId);
                }
                else
                {
                    Debug.LogWarning($"{Assembly.GetExecutingAssembly().GetName().Name}: Failed to get '{techId}' tech.");
                }
            }
        }
    }
}
