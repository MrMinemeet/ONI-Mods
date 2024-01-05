using TUNING;
using UnityEngine;

namespace MrMinemeet.TinyBattery
{
    public class TinyBatteryConfig : BaseBatteryConfig
    {
        public const string ID = "ProjectWhitespace.TinyBattery";
        public const string Name = "Tiny Battery";
        public const string Description = "A Tiny Battery for small spaces.";
        public const string Effect = "Stores a small amount of power.";

        public override BuildingDef CreateBuildingDef()
        {
            int width = 1;
            int height = 1;
            int hitpoints = BUILDINGS.HITPOINTS.TIER0;
            string anim = "batterymed_kanim";
            float construction_time = BUILDINGS.CONSTRUCTION_TIME_SECONDS.TIER1;
            float[] construction_mass = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] coonstruction_materials = MATERIALS.ALL_METALS;
            float melting_point = BUILDINGS.MELTING_POINT_KELVIN.TIER0;
            float exhaust_temperature_active = BUILDINGS.EXHAUST_ENERGY_ACTIVE.TIER1;
            float self_heat_kilowatts_active = BUILDINGS.SELF_HEAT_KILOWATTS.TIER1;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = this.CreateBuildingDef(ID, width, height, hitpoints, anim, construction_time, construction_mass, coonstruction_materials, melting_point, exhaust_temperature_active, self_heat_kilowatts_active, BUILDINGS.DECOR.PENALTY.TIER0, none);
            buildingDef.Breakable = true;
            buildingDef.Floodable = true;
            buildingDef.PermittedRotations = PermittedRotations.R360;
            buildingDef.BuildLocationRule = BuildLocationRule.OnFoundationRotatable;
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
