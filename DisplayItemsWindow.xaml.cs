// -----------------------------------------------------------------------
// 	DisplayItemsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.ItemDetailsWindows;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager
{
    public enum ActionStatus
    {
        None,
        AddingItem,
        EquippingItem,
    }
    /// <summary>
    /// Interaction logic for DisplayItemssWindow.xaml
    /// </summary>
    public partial class DisplayItemsWindow : Window
    {
        List<Unit> items;
        private Character character = new() { FirstName = "Unknown", LastName = "Person" };
        private int quantity = 1;
        private ActionStatus actionStatus = ActionStatus.None;
        private CharacterDetailsWindow characterDetailsWindow = null;
        public DisplayItemsWindow(ItemType itemType, Character character, CharacterDetailsWindow characterDetailsWindow)
        {
            InitializeComponent();
            items = new();
            this.character = character;
            actionStatus = ActionStatus.AddingItem;
            ReadItemsFromDatabase(itemType);
            this.characterDetailsWindow = characterDetailsWindow;
        }
        public DisplayItemsWindow(ItemType itemType)
        {
            InitializeComponent();
            items = new();
            actionStatus = ActionStatus.None;
            ReadItemsFromDatabase(itemType);
        }

        public DisplayItemsWindow(ItemType itemType, Character character)
        {
            InitializeComponent();
            actionStatus = ActionStatus.EquippingItem;
            this.character = character;
            ReadItemsFromInventory(character.Inventory.Units, itemType);
        }

        public void SetCharacterDetailsWindow(CharacterDetailsWindow characterDetailsWindow) 
            => this.characterDetailsWindow = characterDetailsWindow;
        public void ReadItemsFromInventory(List<UnitStack> inventory, ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Weapon:
                    List<Unit?> weapons = inventory
                        .Where(s => s.Unit is WeaponModel)
                        .Select(s => s.Unit)
                        .ToList();
                    ItemsListView.ItemsSource = weapons;
                    break;
                case ItemType.Shield:
                    List<Unit?> shields = inventory
                        .Where(s => s.Unit is ShieldModel)
                        .Select(s => s.Unit)
                        .ToList();
                    ItemsListView.ItemsSource = shields;
                    break;

                case ItemType.Armor:
                    List<Unit?> armors = inventory
                        .Where(s => s.Unit is ArmorModel)
                        .Select(s => s.Unit)
                        .ToList();
                    ItemsListView.ItemsSource = armors;
                    break;
            }

        }
        public void ReadItemsFromDatabase(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Weapon:
                    items = App.StarReverieDbContext.Weapons
                        .OfType<Unit>()
                        .ToList();
                    break;

                case ItemType.Armor:
                    items = App.StarReverieDbContext.Armors
                        .OfType<Unit>()
                        .ToList();
                    break;
                case ItemType.Shield:
                    items = App.StarReverieDbContext.Shields
                        .OfType<Unit>()
                        .ToList();
                    break;

                case ItemType.Technique:
                    items = App.StarReverieDbContext.Techniques
                        .OfType<Unit>()
                        .ToList();
                    break;

                case ItemType.AstralTechnique:
                    items = App.StarReverieDbContext.AstralTechniques
                        .OfType<Unit>()
                        .ToList();
                    break;
            }


            ItemsListView.ItemsSource = items;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = (TextBox)sender;

            List<Unit> filteredList = items
                .Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower()))
                .ToList();

            ItemsListView.ItemsSource = filteredList;
        }

        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit selectedItem = (Unit)ItemsListView.SelectedItem;

            if (selectedItem != null)
            {
                if (actionStatus == ActionStatus.AddingItem)
                {
                    Equipper.AddItemsIntoInventory(selectedItem, character, quantity);
                    actionStatus = ActionStatus.None;
                    characterDetailsWindow.SetInventory();
                    Close();
                    return;
                }

                if (actionStatus == ActionStatus.EquippingItem)
                {

                    switch(selectedItem)
                    {
                        case WeaponModel:
                            Equipper.EquipWeapon(selectedItem, character);
                            actionStatus = ActionStatus.None;
                            characterDetailsWindow.UpdateCharacterStats();
                            Close();
                            return;
                        case ArmorModel:
                            Equipper.EquipArmor(selectedItem, character);
                            actionStatus = ActionStatus.None;
                            characterDetailsWindow.UpdateCharacterStats();
                            Close();
                            return;
                        case ShieldModel:
                            Equipper.EquipShield(selectedItem, character);
                            actionStatus = ActionStatus.None;
                            characterDetailsWindow.UpdateCharacterStats();
                            Close();
                            return;


                    }

                }
                switch (selectedItem)
                {
                    case WeaponModel:
                        WeaponDetailsWindow weaponDetailsWindow = new((WeaponModel)selectedItem, this);
                        weaponDetailsWindow.ShowDialog();
                        break;
                    case ArmorModel:
                        ArmorDetailsWindow armorDetailsWindow = new((ArmorModel)selectedItem, this);
                        armorDetailsWindow.ShowDialog();
                        break;
                    case ShieldModel:
                        ShieldDetailsWindow shieldDetailsWindow = new((ShieldModel)selectedItem, this);
                        shieldDetailsWindow.ShowDialog();
                        break;
                }
            }
        }
    }
}
