using STRINGS;
using System;

namespace pwLib.Utils
{
    public class StringUtils
    {
        /// <summary>
        /// Adds Strings for Building
        /// </summary>
        /// <param name="id">Building ID</param>
        /// <param name="name">Building Name</param>
        /// <param name="description">Building Description</param>
        /// <param name="effect">Building Effect</param>
        public static void AddBuildingStrings(string Id, string Name, string Description, string Effect)
        {
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{Id.ToUpperInvariant()}.NAME", UI.FormatAsLink(Name, Id));
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{Id.ToUpperInvariant()}.DESC", Description);
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{Id.ToUpperInvariant()}.EFFECT", Effect);
        }

        /// <summary>
        /// Adds Strings for Plant
        /// </summary>
        /// <param name="Id">Plant ID</param>
        /// <param name="Name">Plant Description</param>
        /// <param name="Description"></param>
        /// <param name="Domesticated"></param>
        public static void AddPlantStrings(string Id, string Name, string Description, string Domesticated)
        {
            Strings.Add($"STRINGS.CREATURES.SPECIES.{Id.ToUpperInvariant()}.NAME", UI.FormatAsLink(Name, Id));
            Strings.Add($"STRINGS.CREATURES.SPECIES.{Id.ToUpperInvariant()}.DESC", Description);
            Strings.Add($"STRINGS.CREATURES.SPECIES.{Id.ToUpperInvariant()}.DOMESTICATEDDESC", Domesticated);
        }
    }
}
