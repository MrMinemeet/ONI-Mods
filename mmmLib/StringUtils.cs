namespace mmmLib
{
    public static class StringUtils
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
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{Id.ToUpperInvariant()}.NAME", "<link=\"" + Id + "\">" + Name + "</link>");
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{Id.ToUpperInvariant()}.DESC", Description);
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{Id.ToUpperInvariant()}.EFFECT", Effect);
        }

        /// <summary>
        /// Adds Strings for Plant
        /// </summary>
        /// <param name="Id">Plant ID</param>
        /// <param name="Name">Plant Name</param>
        /// <param name="Description">Plant Descritpion in nature</param>
        /// <param name="Domesticated">Plant Description when domesticated</param>
        public static void AddPlantStrings(string Id, string Name, string Description, string Domesticated)
        {
            Strings.Add($"STRINGS.CREATURES.SPECIES.{Id.ToUpperInvariant()}.NAME", "<link=\"" + Id + "\">" + Name + "</link>");
            Strings.Add($"STRINGS.CREATURES.SPECIES.{Id.ToUpperInvariant()}.DESC", Description);
            Strings.Add($"STRINGS.CREATURES.SPECIES.{Id.ToUpperInvariant()}.DOMESTICATEDDESC", Domesticated);
        }
    }
}