// -----------------------------------------------------------------------
// 	DisplayItemsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.ItemDetailsWindow;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager
{

    /// <summary>
    /// Interaction logic for DisplayItemssWindow.xaml
    /// </summary>
    public partial class DisplayItemsWindow : Window
    {
        List<Unit> items;

        public DisplayItemsWindow(ItemType itemType)
        {
            InitializeComponent();
            items = new();
            ReadItemsFromDatabase(itemType);
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

                switch (selectedItem)
                {
                    case WeaponModel:
                        WeaponDetailsWindow weaponDetailsWindow = new((WeaponModel)selectedItem, this);
                        weaponDetailsWindow.ShowDialog();
                        break;
                    case ArmorModel:
                        break;
                    case ShieldModel:
                        break;
                }
            }
        }
    }
}
