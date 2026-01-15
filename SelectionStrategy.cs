// -----------------------------------------------------------------------
// 	NoneSelectionStrategy.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.ItemDetailsWindows;
using StarReverieCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Reverie_Inventory_Manager
{
    public class SelectionStrategy : ItemSelectionStrategy
    {
        public override void HandleSelection(Unit item, DisplayItemsWindow window)
        {
            switch (item)
            {
                case WeaponModel weapon:
                    new WeaponDetailsWindow(weapon, window).ShowDialog();
                    break;

                case ArmorModel armor:
                    new ArmorDetailsWindow(armor, window).ShowDialog();
                    break;

                case ShieldModel shield:
                    new ShieldDetailsWindow(shield, window).ShowDialog();
                    break;
            }
        }
    }
}
