using System.Collections.Generic;
using TUNING;
using UnityEngine;
using static STRINGS.BUILDINGS.PREFABS;

namespace TinyBattery
{
    /// <summary>
    /// This class is responsible for creating the Tiny Smart Battery building.
    /// It extends the TinyBattery class with a few properties that are specific to the Tiny Smart Battery.
    /// E.g. size of 1x1 (instead of 2x2) and other tweaks.
    /// </summary>
    internal class TinySmartBatteryConfig : TinyBatteryConfig
    {
        public new const string ID = "TinySmartBattery";
        private const string ANIMATION = "smartbattery_kanim";

        public override BuildingDef CreateBuildingDef()
        {
            LocString.CreateLocStringKeys(typeof(TinySmartBatteryStrings.BUILDINGS));

            BuildingDef buildingDef = this.CreateBuildingDef(
                ID,
                WIDTH,
                HEIGHT,
                BUILDINGS.HITPOINTS.TIER0,
                ANIMATION,
                BUILDINGS.CONSTRUCTION_TIME_SECONDS.TIER2,
                BUILDINGS.CONSTRUCTION_MASS_KG.TIER2,
                MATERIALS.REFINED_METALS,
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

            buildingDef.LogicOutputPorts = new List<LogicPorts.Port>()
            {
                LogicPorts.Port.OutputPort(BatterySmart.PORT_ID, 
                    new CellOffset(0, 0), 
                    BATTERYSMART.LOGIC_PORT, 
                    BATTERYSMART.LOGIC_PORT_ACTIVE, 
                    BATTERYSMART.LOGIC_PORT_INACTIVE, 
                    true)
            };

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
            BatterySmart batterySmart = go.AddOrGet<BatterySmart>();
            batterySmart.joulesLostPerSecond = (float)(batterySmart.capacity * 0.0199999995529652 / 600.0);
            batterySmart.powerSortOrder = 1000;
        }
    }
}
