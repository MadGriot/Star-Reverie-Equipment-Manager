// -----------------------------------------------------------------------
// 	CreatePlatoonWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

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
    /// Interaction logic for CreatePlatoonWindow.xaml
    /// </summary>
    public partial class CreatePlatoonWindow : Window
    {
        public CreatePlatoonWindow()
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


            PlatoonModel platoonModel = new()
            {
                Name = nameTextBox.Text,
            };
            App.StarReverieDbContext.Platoons.Add(platoonModel);
            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("PlatoonSquad saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
