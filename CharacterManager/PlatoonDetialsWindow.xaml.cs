// -----------------------------------------------------------------------
// 	PlatoonDetialsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager.CharacterManager
{
    /// <summary>
    /// Interaction logic for PlatoonDetialsWindow.xaml
    /// </summary>
    public partial class PlatoonDetialsWindow : Window
    {
        private PlatoonModel platoon;
        private DisplayPlatoonsWindow displayPlatoonsWindow;
        public PlatoonDetialsWindow(PlatoonModel platoon, DisplayPlatoonsWindow displayPlatoonsWindow)
        {
            InitializeComponent();
            this.platoon = platoon;
            this.displayPlatoonsWindow = displayPlatoonsWindow;
            DataContext = platoon;
            namePlatoon.Text = $"Platoon Name: {platoon.Name}";
            ItemsListView.ItemsSource = platoon.Squads;
        }

        private void AddSquadButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayPlatoonSquadsWindow window = new(platoon, this);
            window.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeletePlatoonButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void SetText()
        {
            ItemsListView.ItemsSource = null;
            ItemsListView.ItemsSource = platoon.Squads;
            displayPlatoonsWindow.UpdateListView();
        }
        private void PlatoonSquadsControl_DeleteRequested(object sender, SquadModel squad)
        {
            platoon?.Squads?.Remove(squad);
            App.StarReverieDbContext.SaveChanges();
            ItemsListView.ItemsSource = null;
            ItemsListView.ItemsSource = platoon?.Squads;
            displayPlatoonsWindow.UpdateListView();
        }

        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }


}
