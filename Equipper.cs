// -----------------------------------------------------------------------
// 	Equipper.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;

namespace Star_Reverie_Inventory_Manager
{
    public static class Equipper
    {
        public static void AddItemsIntoInventory(Unit item, Character character, int quantity)
        {
            UnitStack unitStack = character.Inventory.Units.FirstOrDefault(u => u.Unit == item, null);
            if (unitStack != null)
            {
                unitStack.Quantity += quantity;
            }
            else
            {
                unitStack = new()
                {
                    UnitId = item.Id,
                    Unit = item,
                    InventoryId = character.Inventory.Id,
                    Quantity = quantity
                };
                character.Inventory.Units.Add(unitStack);
            }
            App.StarReverieDbContext.SaveChanges();
        }
    }
}
