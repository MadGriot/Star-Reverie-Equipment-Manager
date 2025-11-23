// -----------------------------------------------------------------------
// 	CreateTechniqueWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using System.Windows;
using StarReverieCore.Models;
using static Star_Reverie_Inventory_Manager.InputValidator;
namespace Star_Reverie_Inventory_Manager.CreateTechniquesWindows
{
    /// <summary>
    /// Interaction logic for CreateTechniqueWindow.xaml
    /// </summary>
    public partial class CreateTechniqueWindow : Window
    {
        public bool IsOffensive { get; set; }
        public CreateTechniqueWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TryParseInt(turnCountTextBox, "Turn Count", out int turnCount)) return;
            if (!TryParseInt(staminaCostTextBox, "Stamina Cost", out int staminaCost)) return;
            if (!TryParseInt(costTextBox, "Cost", out int  cost)) return;

            //Save Technique

            Technique technique = new()
            {
                Name = nameTextBox.Text,
                TurnCount = turnCount,
                StaminaCost = staminaCost,
                Cost = cost,
                IsOffensive = this.IsOffensive,
            };
            App.StarReverieDbContext.Techniques.Add(technique);
            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("Technique saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();

        }
    }

}
