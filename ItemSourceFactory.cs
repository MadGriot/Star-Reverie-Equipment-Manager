// -----------------------------------------------------------------------
// 	ItemSourceFactory.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore;
using StarReverieCore.Models;

namespace Star_Reverie_Inventory_Manager
{
    public static class ItemSourceFactory
    {
        public static List<Unit> LoadItems(ItemType type, Character? character, ActionStatus status)
        {

            return status switch
            {
                ActionStatus.AddingItem => LoadFromDatabase(type),
                ActionStatus.None => LoadFromDatabase(type),
                _ => LoadFromInventory(character!.Inventory?.Units, type)
            };

        }

        private static List<Unit> LoadFromInventory(List<UnitStack>? inventory, ItemType type)
        {
            return type switch
            {
                ItemType.Weapon => inventory?.Where(w => w.Unit is WeaponModel)
                    .Select(u => u.Unit!)
                    .ToList() ?? new(),
                ItemType.Shield => inventory?.Where(s => s.Unit is ShieldModel)
                    .Select(u => u.Unit!)
                    .ToList() ?? new(),
                ItemType.Armor => inventory?.Where(a => a.Unit is ArmorModel)
                    .Select(u => u.Unit!)
                    .ToList() ?? new(),
                _ => new(),
            };
        }

        private static List<Unit> LoadFromDatabase(ItemType type)
        {
            StarReverieDbContext context = App.StarReverieDbContext;

            return type switch
            {
                ItemType.Weapon => context.Weapons.OfType<Unit>().ToList(),
                ItemType.Armor => context.Armors.OfType<Unit>().ToList(),
                ItemType.Shield => context.Shields.OfType<Unit>().ToList(),
                ItemType.Technique => context.Techniques.OfType<Unit>().ToList(),
                ItemType.AstralTechnique => context.AstralTechniques.OfType<Unit>().ToList(),
                _ => new()
            };
        }
    }


}
