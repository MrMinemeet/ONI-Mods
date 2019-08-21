using pwLib;
using TUNING;
using UnityEngine;

namespace ProjectWhitespace.TinyBattery
{
    public class TinySmartBatteryConfig : BaseBatteryConfig
    {
        public const string id = "ProjectWhitespace.TinySmartBattery";
        public const string Name = "Tiny Smart Battery";
        public const string Description = "A Tiny Smart Battery for small spaces.";
        public const string Effect = "Stores a small amount of power but keeps being smart.";


        private static readonly LogicPorts.Port[] OUTPUT_PORTS = new LogicPorts.Port[1]
        {
            LogicPorts.Port.OutputPort(BatterySmart.PORT_ID, new CellOffset(0, 0), (string) STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT, (string) STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT_ACTIVE, (string) STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT_INACTIVE, true, false)
        };

        public override BuildingDef CreateBuildingDef()
        {
            int width = 1;
            int height = 1;
            int hitpoints = BUILDINGS.HITPOINTS.TIER0;
            string anim = "smartbattery_kanim";
            float construction_time = BUILDINGS.CONSTRUCTION_TIME_SECONDS.TIER2;
            float[] construction_mass_kg = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] constructionMaterials = MATERIALS.REFINED_METALS;
            float meltingPoint = BUILDINGS.MELTING_POINT_KELVIN.TIER0;
            float exhaust_temperature_active = 0.0f;
            float self_heat_kilowatts_active = BUILDINGS.SELF_HEAT_KILOWATTS.TIER1;
            EffectorValues tieR1 = TUNING.NOISE_POLLUTION.NOISY.TIER1;
            BuildingDef buildingDef = this.CreateBuildingDef(id, width, height, hitpoints, anim, construction_time, construction_mass_kg, constructionMaterials, meltingPoint, exhaust_temperature_active, self_heat_kilowatts_active, TUNING.BUILDINGS.DECOR.PENALTY.TIER2, tieR1);
            SoundEventVolumeCache.instance.AddVolume("batterymed_kanim", "Battery_med_rattle", TUNING.NOISE_POLLUTION.NOISY.TIER2);
            return buildingDef;
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            GeneratedBuildings.RegisterLogicPorts(go, (LogicPorts.Port[])null, TinySmartBatteryConfig.OUTPUT_PORTS);
            go.GetComponent<KBatchedAnimController>().animHeight = 0.5f;
            go.GetComponent<KBatchedAnimController>().animWidth = 0.5f;
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            GeneratedBuildings.RegisterLogicPorts(go, (LogicPorts.Port[])null, TinySmartBatteryConfig.OUTPUT_PORTS);
            go.GetComponent<KBatchedAnimController>().animHeight = 0.5f;
            go.GetComponent<KBatchedAnimController>().animWidth = 0.5f;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            BatterySmart batterySmart = go.AddOrGet<BatterySmart>();
            batterySmart.capacity = 5000f;
            batterySmart.joulesLostPerSecond = (float)((double)batterySmart.capacity * 0.0199999995529652 / 600.0);
            batterySmart.powerSortOrder = 1000;
            GeneratedBuildings.RegisterLogicPorts(go, (LogicPorts.Port[])null, TinySmartBatteryConfig.OUTPUT_PORTS);
            base.DoPostConfigureComplete(go);
            go.GetComponent<KBatchedAnimController>().animHeight = 0.5f;
            go.GetComponent<KBatchedAnimController>().animWidth = 0.5f;
        }
    }
}
