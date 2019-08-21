using System;
using System.Collections.Generic;
using TUNING;

namespace pwLib.Utils
{
    public static class BuildingUtils
    { 
        /// <summary>
        /// Adds Building to Research Tree
        /// </summary>
        /// <param name="research">Name of research part</param>
        /// <param name="buildingID">ID of building which should be added</param>
        public static void AddIntoResearchTree(string Research, string BuildingId)
        {
            List<string> list = new List<string>(Database.Techs.TECH_GROUPING[Research]) { BuildingId };
            Database.Techs.TECH_GROUPING[Research] = list.ToArray();
        }

        /// <summary>
        /// Adds Building to Planing Screen
        /// </summary>
        /// <param name="Category">Cathegory where building should be added</param>
        /// <param name="Id">Building ID</param>
        /// <param name="InsertAfterIndex">Index of the item that it should added be after</param>
        public static void AddBuildingToPlanScreen(HashedString Category, string Id, string InsertAfterIndex = null)
        {
            int CategoryIndex = BUILDINGS.PLANORDER.FindIndex(x => x.category == Category);

            if (CategoryIndex == -1)
                return; // Failed to get Category Index

            List<string> PlaningListOrder = BUILDINGS.PLANORDER[CategoryIndex].data as List<string>;

            if(PlaningListOrder == null)
                // Error adding building
                Console.WriteLine("Failed to add " + Id + " to the building menu.");

            int beforeIndex = PlaningListOrder.IndexOf(InsertAfterIndex);

            if (beforeIndex != -1)
                PlaningListOrder.Insert(beforeIndex + 1, Id);
            else
                PlaningListOrder.Add(Id);
        }
    }
}
