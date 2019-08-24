using Harmony;
using pwLib;

namespace ProjectWhitespace.TinyBattery
{
    public static class BuildingGenerationPatches
    {
        [HarmonyPatch(typeof(GeneratedBuildings))]
        [HarmonyPatch("LoadGeneratedBuildings")]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
        {
            public static void Prefix()
            {
                StringUtils.AddBuildingStrings(TinyBatteryConfig.ID, TinyBatteryConfig.Name, TinyBatteryConfig.Description, TinyBatteryConfig.Effect);
                BuildingUtils.AddBuildingToPlanScreen(GameStrings.PlanMenuCategory.Power, TinyBatteryConfig.ID, BatteryConfig.ID);


                StringUtils.AddBuildingStrings(TinySmartBatteryConfig.id, TinySmartBatteryConfig.Name, TinySmartBatteryConfig.Description, TinySmartBatteryConfig.Effect);
                BuildingUtils.AddBuildingToPlanScreen(GameStrings.PlanMenuCategory.Power, TinySmartBatteryConfig.id, BatteryConfig.ID);
            }
        }

        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch(nameof(Db.Initialize))]
        public static class Db_Initialize_Patch
        {
            public static void Prefix()
            {
                BuildingUtils.AddIntoResearchTree(GameStrings.ResearchTree.Power.PowerRegulation, TinyBatteryConfig.ID);
                BuildingUtils.AddIntoResearchTree(GameStrings.ResearchTree.Power.SoundAmplifiers, TinySmartBatteryConfig.id);
            }
        }
    }
}
