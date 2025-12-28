// -----------------------------------------------------------------------
// 	CreateSquadWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.CharacterManager
{
    /// <summary>
    /// Interaction logic for CreateSquadWindow.xaml
    /// </summary>
    public partial class CreateSquadWindow : Window
    {
        public CreateSquadWindow()
        {
            InitializeComponent();
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            SquadModel squadModel = new()
            {
                Name = nameTextBox.Text,
            };
            App.StarReverieDbContext.Squads.Add(squadModel);
            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("PlatoonSquad saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
