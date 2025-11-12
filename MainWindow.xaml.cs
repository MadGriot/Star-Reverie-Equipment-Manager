using Microsoft.EntityFrameworkCore;
using StarReverieCore.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Star_Reverie_Inventory_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Character> characters;
        public MainWindow()
        {
            InitializeComponent();
            characters = new();
            ReadCharactersFromDatabase();
        }

        private void CreateWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            CreateWeaponsWindow createWeaponsWindow = new();
            createWeaponsWindow.ShowDialog();
        }
        private void CreateArmorButton_Click(object sender, RoutedEventArgs e)
        {
            CreateArmorWindow createArmorWindow = new();
            createArmorWindow.ShowDialog();
        }
        private void DisplayWeaponsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayWeaponsWindow displayWeaponsWindow = new();
            displayWeaponsWindow.ShowDialog();
        }

        void ReadCharactersFromDatabase()
        {
            characters = App.StarReverieDbContext.Characters
                .Include(w => w.Weapon)
                .Include(o => o.Armor)
                .ToList();

            ItemsListView.ItemsSource = characters;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = (TextBox)sender;

            List<Character> filteredList = characters
                .Where(c => c.FirstName.ToLower().Contains(searchTextBox.Text.ToLower()))
                .ToList();

            ItemsListView.ItemsSource = filteredList;
        }
    }
}