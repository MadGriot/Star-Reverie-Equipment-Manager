// -----------------------------------------------------------------------
// 	DisplayPlatoonSquadsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.ItemDetailsWindows;
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

namespace Star_Reverie_Inventory_Manager.CharacterManager
{
    /// <summary>
    /// Interaction logic for DisplayPlatoonSquadsWindow.xaml
    /// </summary>
    public partial class DisplayPlatoonSquadsWindow : Window
    {
        private List<SquadModel> squads;
        private PlatoonModel platoon;
        private PlatoonDetialsWindow platoonDetialsWindow;
        public DisplayPlatoonSquadsWindow(PlatoonModel platoon, PlatoonDetialsWindow platoonDetialsWindow)
        {
            InitializeComponent();
            this.platoon = platoon;
            this.platoonDetialsWindow = platoonDetialsWindow;
            squads = App.StarReverieDbContext.Squads
                            .Where(s =>
                                !platoon.Squads.Contains(s) &&
                                s.Platoon.Squads.Count < 4)
                            .ToList();
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
                platoon.Squads?.Add(selectedItem);
                if (selectedItem == null)
                {
                    throw new NullReferenceException();
                }
                App.StarReverieDbContext.SaveChanges();
                platoonDetialsWindow.SetText();
            }
            Close();
        }
    }
}
