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
    /// Interaction logic for DisplayWeaponsWindow.xaml
    /// </summary>
    public partial class DisplayWeaponsWindow : Window
    {
        List<WeaponModel> weapons;
        public DisplayWeaponsWindow()
        {
            InitializeComponent();
            weapons = new();
            ReadWeaponsFromDatabase();
        }

        void ReadWeaponsFromDatabase()
        {
            weapons = App.StarReverieDbContext.Weapons.ToList();

            ItemsListView.ItemsSource = weapons;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = (TextBox)sender;

            List<WeaponModel> filteredList = weapons
                .Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower()))
                .ToList();

            ItemsListView.ItemsSource = filteredList;
        }
    }
}
