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
    public interface IItemSelectionStrategy
    {
        void HandleSelection(Unit selectedItem, DisplayItemsWindow window);
    }
}
