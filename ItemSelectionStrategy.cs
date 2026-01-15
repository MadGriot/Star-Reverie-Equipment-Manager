// -----------------------------------------------------------------------
// 	IItemSelectionStrategy.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Reverie_Inventory_Manager
{
    public abstract class ItemSelectionStrategy
    {
        public int quantity;
        public virtual void HandleSelection(Unit selectedItem, DisplayItemsWindow window)
        {

        }
    }
}
