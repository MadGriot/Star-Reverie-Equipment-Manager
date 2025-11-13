using StarReverieCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            ReadWeaponsFromDatabase(itemType);
        }

        void ReadWeaponsFromDatabase(ItemType itemType)
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
                ItemDetailsWindow itemDetailsWindow = new(selectedItem);
                itemDetailsWindow.ShowDialog();
            }
        }
    }
}
