// -----------------------------------------------------------------------
// 	EquipItemStrategy.cs
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
    public class EquipItemStrategy : ItemSelectionStrategy
    {
        private readonly Character character;

        public EquipItemStrategy(Character character)
        {
            this.character = character;
        }

        public override void HandleSelection(Unit item, DisplayItemsWindow window)
        {
            switch (item)
            {
                case WeaponModel:
                    InventoryActions.EquipWeapon(item, character);
                    break;
                case ArmorModel:
                    InventoryActions.EquipArmor(item, character);
                    break;
                case ShieldModel:
                    InventoryActions.EquipShield(item, character);
                    break;
            }

            window.CharacterDetailsWindow?.SetText();
            App.StarReverieDbContext.SaveChanges();
            window.Close();
        }
    }
}
