// -----------------------------------------------------------------------
// 	MainWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Star_Reverie_Inventory_Manager.CharacterManager;
using Star_Reverie_Inventory_Manager.CreateTechniquesWindows;
using Star_Reverie_Inventory_Manager.ItemDetailsWindows;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

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

        private void CreateAstralTechniqueButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAstralTechniqueWindow createAstralTechniqueWindow = new();
            createAstralTechniqueWindow.ShowDialog();
        }
        private void CreateTechniqueButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTechniqueWindow createTechniqueWindow = new();
            createTechniqueWindow.ShowDialog();
        }

        private void DisplayTechniqueButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.Technique);
            displayItemsWindow.ShowDialog();
        }
        private void DisplayAstralTechniqueButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.AstralTechnique);
            displayItemsWindow.ShowDialog();
        }
        private void CreateShieldButton_Click(object sender, RoutedEventArgs e)
        {
            CreateShieldWindow createShieldWindow = new();
            createShieldWindow.ShowDialog();
        }
        private void DisplayWeaponsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayWeaponsWindow = new(ItemType.Weapon);
            displayWeaponsWindow.ShowDialog();
        }
        private void DisplayArmorsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.Armor);
            displayItemsWindow.ShowDialog();
        }
        private void DisplayShieldsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.Shield);
            displayItemsWindow.ShowDialog();
        }
        private void CreateCharacterButton_Click(object sender, RoutedEventArgs e)
        {
            CreateCharacterWindow createCharacterWindow = new();
            createCharacterWindow.ShowDialog();
        }
        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character character = (Character)ItemsListView.SelectedItem;
            CharacterDetailsWindow characterDetailsWindow = new(character);
            characterDetailsWindow.ShowDialog();
        }
        void ReadCharactersFromDatabase()
        {
            characters = App.StarReverieDbContext.Characters
                .Include(w => w.Weapon)
                .Include(wi => wi.WeaponInstances)
                .Include(a => a.AttributeScore)
                .Include(o => o.Armor)
                .Include(a => a.AstralTech)
                .Include(t => t.Techniques)
                .Include(o => o.Shield)
                .Include(si => si.ShieldInstances)
                .Include(i => i.Inventory)
                    .ThenInclude(u => u.Units)
                        .ThenInclude(us => us.Unit)
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