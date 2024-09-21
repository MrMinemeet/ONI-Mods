using TUNING;
using UnityEngine;

namespace TinyBattery
{
    /// <summary>
    /// This class is responsible for creating the Tiny Battery building.
    /// It extends the BaseBatteryConfig class with a few properties that are specific to the Tiny Battery.
    /// E.g. size of 1x1 (instead of 2x2) and other tweaks.
    /// </summary>
    internal class TinyBatteryConfig : BaseBatteryConfig
    {
        public const string ID = "TinyBattery";

        protected const int WIDTH = 1;
        protected const int HEIGHT = 1;

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
            return buildingDef;
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            ShrinkAnimationSize(go);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            ShrinkAnimationSize(go);
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            base.DoPostConfigureComplete(go);
            ShrinkAnimationSize(go);
            Battery battery = go.AddOrGet<Battery>();
            battery.capacity = 5000f;
            battery.joulesLostPerSecond = (float)(battery.capacity * 0.100000001490116 / 600.0);
            
        }

        // Shrink the animation size of the Tiny Battery.
        protected void ShrinkAnimationSize(GameObject go)
        {
            // FIXME: Currently not everything of the "animation" is scaled properly. This includes the following:
            // * The "charge indicator"
            // * Logic activation light on smart battery
            go.GetComponent<KBatchedAnimController>().animHeight = 0.5f;
            go.GetComponent<KBatchedAnimController>().animWidth = 0.5f;
        }
    }
}
