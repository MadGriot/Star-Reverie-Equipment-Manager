// -----------------------------------------------------------------------
// 	CreateShieldWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;
using static Star_Reverie_Inventory_Manager.InputValidator;

namespace Star_Reverie_Inventory_Manager.CreateItemWindows
{
    /// <summary>
    /// Interaction logic for CreateShieldWindow.xaml
    /// </summary>
    public partial class CreateShieldWindow : Window, ICreate
    {
        public CreateShieldWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            // Validate required name
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate numeric inputs using InputValidator
            if (!TryParseInt(spTextBox, "Shield Points (SP)", out int sp)) return;
            if (!TryParseInt(spCostTextBox, "SP Cost", out int spCost)) return;
            if (!TryParseInt(costTextBox, "Cost", out int cost)) return;
            if (!TryParseInt(weightTextBox, "Weight", out int weight)) return;

            if (sp < 0)
            {
                MessageBox.Show("Shield Points cannot be negative.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (spCost < 0)
            {
                MessageBox.Show("SP Cost cannot be negative.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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

            MessageBox.Show("Shield saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
