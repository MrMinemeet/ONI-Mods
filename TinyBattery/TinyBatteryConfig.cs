using TUNING;
using UnityEngine;

namespace TinyBattery {
    /// <summary>
    /// This class is responsible for creating the Tiny Battery building.
    /// It extends the BaseBatteryConfig class with a few properties that are specific to the Tiny Battery.
    /// E.g. size of 1x1 (instead of 1.2) and other tweaks.
    /// </summary>
    internal class TinyBatteryConfig : BaseBatteryConfig
    {
        public const string ID = "TinyBattery";


        public override BuildingDef CreateBuildingDef()
        {
            LocString.CreateLocStringKeys(typeof(TinyBatteryStrings.BUILDINGS));

            const int width = 1;
            const int height = 1;
            const int hitpoints = BUILDINGS.HITPOINTS.TIER0;
            const string anim = "batterymed_kanim";
            const float construction_time = BUILDINGS.CONSTRUCTION_TIME_SECONDS.TIER1;
            float[] construction_mass = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] coonstruction_materials = MATERIALS.ALL_METALS;
            const float melting_point = BUILDINGS.MELTING_POINT_KELVIN.TIER0;
            const float exhaust_temperature_active = BUILDINGS.EXHAUST_ENERGY_ACTIVE.TIER1;
            const float self_heat_kilowatts_active = BUILDINGS.SELF_HEAT_KILOWATTS.TIER1;
            EffectorValues none = NOISE_POLLUTION.NONE;

            BuildingDef buildingDef = this.CreateBuildingDef(ID, width, height, hitpoints, anim, construction_time,
                construction_mass, coonstruction_materials, melting_point, exhaust_temperature_active,
                self_heat_kilowatts_active, BUILDINGS.DECOR.PENALTY.TIER0, none);
            buildingDef.Breakable = true;
            buildingDef.Floodable = true;
            buildingDef.PermittedRotations = PermittedRotations.R360;
            buildingDef.BuildLocationRule = BuildLocationRule.OnFoundationRotatable;
            buildingDef.ObjectLayer = ObjectLayer.Building;

            SoundEventVolumeCache.instance.AddVolume("batterysm_kanim", "Battery_rattle", NOISE_POLLUTION.NOISY.TIER1);
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            go.GetComponent<KBatchedAnimController>().animHeight = 0.5f;
            go.GetComponent<KBatchedAnimController>().animWidth = 0.5f;
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            go.GetComponent<KBatchedAnimController>().animHeight = 0.5f;
            go.GetComponent<KBatchedAnimController>().animWidth = 0.5f;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            Battery battery = go.AddOrGet<Battery>();
            battery.capacity = 5000f;
            battery.joulesLostPerSecond = (float)((double)battery.capacity * 0.100000001490116 / 600.0);
            go.GetComponent<KBatchedAnimController>().animHeight = 0.5f;
            go.GetComponent<KBatchedAnimController>().animWidth = 0.5f;
            base.DoPostConfigureComplete(go);
        }
    }
}
