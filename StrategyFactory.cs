// -----------------------------------------------------------------------
// 	StrategyFactory.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Reverie_Inventory_Manager
{
    public static class StrategyFactory
    {
        public static IItemSelectionStrategy CreateStrategy(
            ActionStatus status,
            Character? character,
            int quantity = 1)
        {
            return status switch
            {
                ActionStatus.AddingItem => new AddItemStrategy(character!, quantity),
                ActionStatus.LearnTechnique => new AddItemStrategy(character!, quantity),
                ActionStatus.EquippingItem => new EquipItemStrategy(character!),
                _ => new SelectionStrategy(),
            };
        }
    }
}
