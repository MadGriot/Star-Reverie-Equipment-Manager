// -----------------------------------------------------------------------
// 	InventoryItemDetials.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindows
{
    /// <summary>
    /// Interaction logic for InventoryItemDetials.xaml
    /// </summary>
    public partial class InventoryItemDetials : Window
    {
        private UnitStack item;
        private Character character;
        public InventoryItemDetials(UnitStack item, Character character)
        {
            InitializeComponent();
            this.item = item;
            this.character = character;
            nameTextBox.Text = item?.Unit?.Name;
            descriptionTextBox.Text = item?.Unit?.Description;
            quantityTextBox.Text = item?.Quantity.ToString();
        }

        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (item.Unit != null) 
                InventoryActions.RemoveItemsFromInventory(item.Unit, character, int.Parse(quantityNumber.Text));
        }
        private void SubtractQuantityButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public void ExitButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
