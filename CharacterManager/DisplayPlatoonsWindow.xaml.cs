// -----------------------------------------------------------------------
// 	DisplayPlatoonsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager.CharacterManager
{
    /// <summary>
    /// Interaction logic for DisplayPlatoonsWindow.xaml
    /// </summary>
    public partial class DisplayPlatoonsWindow : Window
    {
        private List<PlatoonModel> platoons;
        public DisplayPlatoonsWindow()
        {
            InitializeComponent();
            platoons = App.StarReverieDbContext.Platoons.Include(s => s.Squads).ToList();
                        ItemsListView.ItemsSource = platoons;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsListView.SelectedItem is not PlatoonModel platoon)
                return;
            PlatoonDetialsWindow window = new(platoon, this);
            window.ShowDialog();
            ItemsListView.SelectedItem = null;
        }

        public void UpdateListView()
        {
            ItemsListView.ItemsSource = null;
            ItemsListView.ItemsSource = platoons;
        }
    }
}
