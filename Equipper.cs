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
            //Unequipping current weapon
            CharacterWeaponInstance characterWeaponInstance = character.WeaponInstances.FirstOrDefault(w => w.WeaponModel == character.Weapon);
            if (characterWeaponInstance != null)
            {
                characterWeaponInstance.IsEquipped = false;

            }

            //Equipping weapon
            character.Weapon = (WeaponModel)item;
            characterWeaponInstance = character.WeaponInstances.FirstOrDefault(w => w.WeaponModel == character.Weapon);
            if (characterWeaponInstance != null)
            {
                characterWeaponInstance.IsEquipped = true;
            }
            else
            {
                characterWeaponInstance = new()
                {
                    WeaponModel = character.Weapon,
                    Character = character,
                    CurrentAmmo = character.Weapon.MaxAmmo,
                    IsEquipped = true
                };
                character.WeaponInstances.Add(characterWeaponInstance);

            }
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
            CharacterShieldInstance characterShieldInstance = character.ShieldInstances.FirstOrDefault(s => s.ShieldModel == character.Shield);
            if (characterShieldInstance != null)
            {
                characterShieldInstance.IsEquipped = false;
            }

            //Equipping Shield
            character.Shield = (ShieldModel)item;
            characterShieldInstance = character.ShieldInstances.FirstOrDefault(s => s.ShieldModel == character.Shield);
            if (characterShieldInstance != null)
            {
                characterShieldInstance.IsEquipped = true;
            }
            else
            {
                characterShieldInstance = new()
                {
                    ShieldModel = character.Shield,
                    Character = character,
                    CurrentSP = character.Shield.MaxSP,
                    IsEquipped = true
                };
                character.ShieldInstances.Add(characterShieldInstance);
            }
            App.StarReverieDbContext.SaveChanges();

        }
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

        public static void RemoveItemsFromInventory(Unit item, Character character, int quantity)
        {
            UnitStack unitStack = character.Inventory.Units.First(u => u.Unit == item);
            unitStack.Quantity -= quantity;
            if (unitStack.Quantity <= 0)
            {
                character.Inventory.Units.Remove(unitStack);
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
