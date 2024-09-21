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

        private const int WIDTH = 1;
        private const int HEIGHT = 1;
        private const string ANIMATION = "batterymed_kanim";


        public override BuildingDef CreateBuildingDef()
        {
            LocString.CreateLocStringKeys(typeof(TinyBatteryStrings.BUILDINGS));

            BuildingDef buildingDef = this.CreateBuildingDef(
                ID, 
                WIDTH, 
                HEIGHT,
                BUILDINGS.HITPOINTS.TIER0, 
                ANIMATION,
                BUILDINGS.CONSTRUCTION_TIME_SECONDS.TIER1,
                BUILDINGS.CONSTRUCTION_MASS_KG.TIER2,
                MATERIALS.ALL_METALS,
                BUILDINGS.MELTING_POINT_KELVIN.TIER0,
                BUILDINGS.EXHAUST_ENERGY_ACTIVE.TIER1,
                BUILDINGS.SELF_HEAT_KILOWATTS.TIER1, 
                BUILDINGS.DECOR.PENALTY.TIER0,
                NOISE_POLLUTION.NONE);

            buildingDef.Breakable = true;
            buildingDef.PermittedRotations = PermittedRotations.R360;
            buildingDef.BuildLocationRule = BuildLocationRule.OnFoundationRotatable;
            buildingDef.ObjectLayer = ObjectLayer.Building;

            SoundEventVolumeCache.instance.AddVolume("batterymed_kanim", "Battery_rattle", NOISE_POLLUTION.NOISY.TIER1);

            // TODO: Fix incorrectly sized and placed "charge display" on the building

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
