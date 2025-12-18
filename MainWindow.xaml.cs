// -----------------------------------------------------------------------
// 	MainWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Star_Reverie_Inventory_Manager.CharacterManager;
using Star_Reverie_Inventory_Manager.CreateItemWindows;
using Star_Reverie_Inventory_Manager.CreateTechniquesWindows;
using Star_Reverie_Inventory_Manager.ItemDetailsWindows;
using Star_Reverie_Inventory_Manager.QuestManager;
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
        private void CreateAmmoButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAmmoWindow createAmmoWindow = new();
            createAmmoWindow.ShowDialog();
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
            DisplayItemsWindow window = new(ItemType.Technique, ActionStatus.None);
            window.ShowDialog();
        }
        private void DisplayAstralTechniqueButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.AstralTechnique, ActionStatus.None);
            window.ShowDialog();
        }
        private void CreateShieldButton_Click(object sender, RoutedEventArgs e)
        {
            CreateShieldWindow createShieldWindow = new();
            createShieldWindow.ShowDialog();
        }
        private void DisplayWeaponsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Weapon, ActionStatus.None);
            window.ShowDialog();
        }
        private void DisplayArmorsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Armor, ActionStatus.None);
            window.ShowDialog();
        }
        private void DisplayShieldsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Shield, ActionStatus.None);
            window.ShowDialog();
        }
        private void CreateCharacterButton_Click(object sender, RoutedEventArgs e)
        {
            CreateCharacterWindow createCharacterWindow = new(this);
            createCharacterWindow.ShowDialog();
        }

        private void CreateSquadButton_Click(object sender, RoutedEventArgs e)
        {
            CreateSquadWindow createSquadWindow = new();
            createSquadWindow.ShowDialog();
        }
        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsListView.SelectedItem is not Character character)
                return;   // Ignore the "deselection" event
            CharacterDetailsWindow characterDetailsWindow = new(character);
            characterDetailsWindow.ShowDialog();
            ItemsListView.SelectedItem = null;
        }
        public void ReadCharactersFromDatabase()
        {
            characters = App.StarReverieDbContext.Characters
                .Include(w => w.Weapon)
                .Include(wi => wi.WeaponInstances)
                .Include(a => a.AttributeScore)
                .Include(o => o.Armor)
                .Include(a => a.AstralTech)
                .Include(t => t.Techniques)
                .Include(o => o.Shield)
                .Include(sq => sq.Squad)
                .Include(d => d.Dialogues)
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

        private void CreateQuestButton_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestWindow createQuestWindow = new();
            createQuestWindow.ShowDialog();
        }
    }
}