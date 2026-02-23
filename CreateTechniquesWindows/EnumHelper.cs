// -----------------------------------------------------------------------
// 	EnumHelper.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------


using StarReverieCore.Mechanics;

namespace Star_Reverie_Inventory_Manager.CreateTechniquesWindows
{
    public static class EnumHelper
    {
        public static Array AttributeTypes =>
            Enum.GetValues(typeof(AttributeType));

        public static Array Skills =>
            Enum.GetValues(typeof(Skill));
    }
}
