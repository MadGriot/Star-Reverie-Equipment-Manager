// -----------------------------------------------------------------------
// 	CreateFirstAidWindow.xaml.cs
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

using static Star_Reverie_Inventory_Manager.InputValidator;
namespace Star_Reverie_Inventory_Manager.CreateItemWindows
{
    /// <summary>
    /// Interaction logic for CreateFirstAidWindow.xaml
    /// </summary>
    public partial class CreateFirstAidWindow : Window
    {
        public Array TechnologyLevels { get; } = Enum.GetValues(typeof(TechnologyLevel));
        public TechnologyLevel SelectedTechnologyLevel { get; set; } = TechnologyLevel.Current;
        public CreateFirstAidWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!TryParseInt(healAmountTextBox, "Charge amount", out int healAmount)) return;
            if (!TryParseInt(costTextBox, "Cost", out int cost)) return;
            if (!TryParseDecimal(weightTextBox, "Weight", out decimal weight)) return;

            if (healAmount < 0)
            {
                MessageBox.Show("Heal Amount cannot be negative.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (weight < 0)
            {
                MessageBox.Show("Weight cannot be negative.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            FirstAidModel firstAidModel = new()
            {
                Name = nameTextBox.Text,
                DiceCount = healAmount,
                Description = descriptionTextBox.Text,
                TriechAppearanceDate = triechAppearanceTextBox.Text,
                EarthAppearanceDate = earthAppearanceTextBox.Text,
                Origin = originTextBox.Text,
                TechnologyLevel = SelectedTechnologyLevel,
                Cost = cost,
                Weight = weight,
            };
            App.StarReverieDbContext.FirstAids.Add(firstAidModel);
            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("First Aid kit saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
