// -----------------------------------------------------------------------
// 	CreateBatteryWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;

using static Star_Reverie_Inventory_Manager.InputValidator;
namespace Star_Reverie_Inventory_Manager.CreateItemWindows
{
    /// <summary>
    /// Interaction logic for CreateBatteryWindow.xaml
    /// </summary>
    public partial class CreateBatteryWindow : Window
    {
        public Array TechnologyLevels { get; } = Enum.GetValues(typeof(TechnologyLevel));
        public TechnologyLevel SelectedTechnologyLevel { get; set; } = TechnologyLevel.Current;
        public CreateBatteryWindow()
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
            if (!TryParseDecimal(chargeAmountTextBox, "Charge amount", out decimal chargeAmount)) return;
            if (!TryParseInt(costTextBox, "Cost", out int cost)) return;
            if (!TryParseDecimal(weightTextBox, "Weight", out decimal weight)) return;

            if (chargeAmount < 0)
            {
                MessageBox.Show("Charge Amount cannot be negative.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (weight < 0)
            {
                MessageBox.Show("Weight cannot be negative.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            BatteryModel batteryModel = new()
            {
                Name = nameTextBox.Text,
                ChargeAmount = chargeAmount,
                Description = descriptionTextBox.Text,
                TriechAppearanceDate = triechAppearanceTextBox.Text,
                EarthAppearanceDate = earthAppearanceTextBox.Text,
                Origin = originTextBox.Text,
                TechnologyLevel = SelectedTechnologyLevel,
                Cost = cost,
                Weight = weight,
            };
            App.StarReverieDbContext.Batteries.Add(batteryModel);
            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("Battery saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
