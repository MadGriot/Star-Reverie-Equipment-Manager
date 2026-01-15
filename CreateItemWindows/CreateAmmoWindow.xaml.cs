// -----------------------------------------------------------------------
// 	CreateAmmoWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;

using static Star_Reverie_Inventory_Manager.InputValidator;
namespace Star_Reverie_Inventory_Manager.CreateItemWindows
{
    /// <summary>
    /// Interaction logic for CreateAmmoWindow.xaml
    /// </summary>
    public partial class CreateAmmoWindow : Window, ICreate
    {
        public CreateAmmoWindow()
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
            if (!TryParseInt(costTextBox, "Cost", out int cost)) return;
            if (!TryParseDecimal(weightTextBox, "Weight", out decimal weight)) return;


            AmmoModel ammoModel = new()
            {
                Name = nameTextBox.Text,
                Cost = int.Parse(costTextBox.Text),
                Weight = decimal.Parse(weightTextBox.Text),
                Description = descriptionTextBox.Text,
                Origin = originTextBox.Text,
                TriechAppearanceDate = triechAppearanceTextBox.Text,
                EarthAppearanceDate = earthAppearanceTextBox.Text,
                
            };
            App.StarReverieDbContext.Ammos.Add(ammoModel);
            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("Ammo saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
