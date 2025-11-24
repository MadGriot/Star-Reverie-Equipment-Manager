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
        public static void EquipWeapon(Unit item, Character character)
        {
            // Unequip current weapon
            CharacterWeaponInstance? oldWeaponInstance =
                character.WeaponInstances.FirstOrDefault(w => w.WeaponModel == character.Weapon);
            oldWeaponInstance!.IsEquipped = false;

            // Equip weapon
            character.Weapon = (WeaponModel)item;

            CharacterWeaponInstance? newWeaponInstance =
                character.WeaponInstances.FirstOrDefault(w => w.WeaponModel == character.Weapon);

            bool isNew = newWeaponInstance is null;

            newWeaponInstance ??= new CharacterWeaponInstance
            {
                WeaponModel = character.Weapon,
                Character = character,
                CurrentAmmo = character.Weapon.MaxAmmo
            };

            if (isNew)
                character.WeaponInstances.Add(newWeaponInstance);
            newWeaponInstance.IsEquipped = true;
            App.StarReverieDbContext.SaveChanges();
        }

        public static void EquipArmor(Unit item, Character character)
        {
            //Equipping armor.. no instances needed for now
            character.Armor = (ArmorModel)item;
            App.StarReverieDbContext.SaveChanges();
        }

        public static void EquipShield(Unit item, Character character)
        {
            //Unequipping current shield
            CharacterShieldInstance? oldShieldInstance = 
                character.ShieldInstances.FirstOrDefault(s => s.ShieldModel == character.Shield);
            oldShieldInstance!.IsEquipped = false;

            //Equip Shield
            character.Shield = (ShieldModel)item;
            CharacterShieldInstance? newShieldInstance =
                character.ShieldInstances.FirstOrDefault(s => s.ShieldModel == character.Shield);
            bool isNew = newShieldInstance is null;

            newShieldInstance ??=  new CharacterShieldInstance
            {
                ShieldModel = character.Shield,
                Character = character,
                CurrentSP = character.Shield.MaxSP,
            };

            if (isNew) 
                character.ShieldInstances.Add(newShieldInstance);
            newShieldInstance.IsEquipped = true;
            App.StarReverieDbContext.SaveChanges();

        }
        public static void AddItemsIntoInventory(Unit item, Character character, int quantity)
        {
            InventoryModel? inventory = character.Inventory;

            UnitStack? unitStack = inventory?.Units.FirstOrDefault(u => u.Unit == item)
                    ?? new UnitStack
                    {
                        UnitId = item.Id,
                        Unit = item,
                        InventoryId = inventory.Id,
                        Quantity = 0
                    };
            if (!inventory.Units.Contains(unitStack))
                inventory.Units.Add(unitStack);

            unitStack?.Quantity += quantity;
            App.StarReverieDbContext.SaveChanges();
        }

        public static void RemoveItemsFromInventory(Unit item, Character character, int quantity)
        {
            UnitStack? unitStack = character.Inventory?.Units.First(u => u.Unit == item);
            unitStack?.Quantity -= quantity;
            if (unitStack?.Quantity <= 0)
            {
                character.Inventory?.Units.Remove(unitStack);
                switch (unitStack.Unit)
                {
                    case WeaponModel:
                        character.WeaponInstances.Remove(
                            character.WeaponInstances.First(w => w.WeaponModel == item));
                        break;
                    case ShieldModel:
                        character.ShieldInstances.Remove(
                            character.ShieldInstances.First(w => w.ShieldModel == item));
                        break;
                }
            }
        }
    }
}
