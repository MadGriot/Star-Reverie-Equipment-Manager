// -----------------------------------------------------------------------
// 	DisplaySquadWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.Controls;
using Star_Reverie_Inventory_Manager.ItemDetailsWindows;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager.CharacterManager
{
    /// <summary>
    /// Interaction logic for DisplaySquadWindow.xaml
    /// </summary>
    public partial class DisplaySquadWindow : Window
    {
        private List<SquadModel> squads;
        private readonly Character character;
        private readonly CharacterDetailsWindow characterDetailsWindow;
        public DisplaySquadWindow(Character character, CharacterDetailsWindow characterDetailsWindow)
        {
            InitializeComponent();
            this.character = character;
            this.characterDetailsWindow = characterDetailsWindow;
            squads = App.StarReverieDbContext.Squads
                .Where(s => !s.Equals(character.Squad) && s.Characters!.Count < 4).ToList();
            ItemsListView.ItemsSource = squads;
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = (TextBox)sender;

            List<SquadModel> filteredList = squads
                .Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower()))
                .ToList();

            ItemsListView.ItemsSource = filteredList;
        }

        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsListView.SelectedItem is SquadModel selectedItem)
            {
                character.Squad = selectedItem;
                App.StarReverieDbContext.SaveChanges();
                characterDetailsWindow.SetText();
            }
            Close();
        }
    }
}
