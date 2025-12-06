// -----------------------------------------------------------------------
// 	AddItemStrategy.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Reverie_Inventory_Manager
{
    public class AddItemStrategy : IItemSelectionStrategy
    {
        private readonly Character character;
        private readonly int quantity;

        public AddItemStrategy(Character character, int quantity)
        {
            this.character = character;
            this.quantity = quantity;
        }

        public void HandleSelection(Unit selectedItem, DisplayItemsWindow window)
        {
            InventoryActions.AddItemsIntoInventory(selectedItem, character, quantity);
            window.CharacterDetailsWindow?.SetInventory();
            App.StarReverieDbContext.SaveChanges();
            window.Close();
        }
    }
}
