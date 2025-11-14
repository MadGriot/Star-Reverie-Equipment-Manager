// -----------------------------------------------------------------------
// 	CreateShieldWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager
{
    /// <summary>
    /// Interaction logic for CreateShieldWindow.xaml
    /// </summary>
    public partial class CreateShieldWindow : Window
    {
        public CreateShieldWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ShieldModel shieldModel = new()
            {
                Name = nameTextBox.Text,
                MaxSP = int.Parse(spTextBox.Text),
                MinSP = int.Parse(spTextBox.Text),
                SPCost = int.Parse(spCostTextBox.Text),
                Cost = int.Parse(costTextBox.Text),
                Weight = int.Parse(weightTextBox.Text),
            };
            App.StarReverieDbContext.Shields.Add(shieldModel);
            App.StarReverieDbContext.SaveChanges();
            Close();
        }
    }
}
