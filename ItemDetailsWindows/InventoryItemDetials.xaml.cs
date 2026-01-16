// -----------------------------------------------------------------------
// 	InventoryItemDetials.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindows
{
    /// <summary>
    /// Interaction logic for InventoryItemDetials.xaml
    /// </summary>
    public partial class InventoryItemDetials : Window
    {
        private UnitStack item;
        private Character character;
        private CharacterDetailsWindow characterDetailsWindow;
        private List<Unit?> equippedUnits;
        public InventoryItemDetials(UnitStack item, Character character, CharacterDetailsWindow characterDetailsWindow)
        {
            InitializeComponent();
            this.item = item;
            this.character = character;
            this.characterDetailsWindow = characterDetailsWindow;
            nameTextBox.Text = item?.Unit?.Name;
            descriptionTextBox.Text = item?.Unit?.Description;
            quantityTextBox.Text = item?.Quantity.ToString();
            equippedUnits = new() { character.Weapon, character.Armor, character.Shield };
        }

        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (item.Unit != null) 
                InventoryActions.RemoveItemsFromInventory(item.Unit, character, int.Parse(quantityNumber.Text));
            characterDetailsWindow.SetInventory();
            characterDetailsWindow.SetText();
            App.StarReverieDbContext.SaveChanges();
            Close();
        }
        private void SubtractQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity = int.Parse(quantityNumber.Text);
            if (quantity > 1)
            {
                quantity -= 1;

            }
            quantityNumber.Text = quantity.ToString();
        }
        private void AddQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity = int.Parse(quantityNumber.Text);
            if (quantity < item.Quantity)
            {
                quantity += 1;

            }
            quantityNumber.Text = quantity.ToString();
        }
        public void ExitButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
