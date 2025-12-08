// -----------------------------------------------------------------------
// 	DisplayItemsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.ItemDetailsWindows;
using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.Net.NetworkInformation;
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
        private List<Unit> items;
        private int quantity = 1;
        private IItemSelectionStrategy strategy;
        private ItemType itemType;
        private Character? character;
        private ActionStatus status;
        public CharacterDetailsWindow? CharacterDetailsWindow { get; private set; } = null;
        public DisplayItemsWindow(ItemType itemType, ActionStatus status = ActionStatus.None, 
            Character? character = null, CharacterDetailsWindow? characterWindow = null)
        {
            InitializeComponent();
            CharacterDetailsWindow = characterWindow;

            strategy = StrategyFactory.CreateStrategy(status, character, quantity);
            items = ItemSourceFactory.LoadItems(itemType, character, status);
            this.itemType = itemType;
            this.character = character;
            this.status = status;
            ItemsListView.ItemsSource = items;
        }


        public void RefreshItems()
        {
            ItemsListView.ItemsSource = ItemSourceFactory.LoadItems(itemType, character, status);
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
            if (ItemsListView.SelectedItem is Unit selectedItem)
                strategy.HandleSelection(selectedItem, this);
        }
    }
}
