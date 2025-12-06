// -----------------------------------------------------------------------
// 	CreateArmorWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Equipment;
using StarReverieCore.Models;
using System.Windows;

using static Star_Reverie_Inventory_Manager.InputValidator;
namespace Star_Reverie_Inventory_Manager.CreateItemWindows
{
    /// <summary>
    /// Interaction logic for CreateArmorWindow.xaml
    /// </summary>
    public partial class CreateArmorWindow : Window, ICreate
    {
        public Array ArmorLocations { get; } = Enum.GetValues(typeof(ArmorLocation));
        public ArmorLocation SelectedArmorLocation { get; set; } = ArmorLocation.FullSuit;
        public CreateArmorWindow()
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
            if (!TryParseInt(damageResistanceTextBox, "Damage Resistance", out int damageResistance)) return;
            if (!TryParseInt(costTextBox, "Cost", out int cost)) return;
            if (!TryParseInt(weightTextBox, "Weight", out int weight)) return;

            if (damageResistance < 0)
            {
                MessageBox.Show("Damage Resistance cannot be negative.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (weight < 0)
            {
                MessageBox.Show("Weight cannot be negative.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ArmorModel armorModel = new()
            {
                Name = nameTextBox.Text,
                DamageResistance = int.Parse(damageResistanceTextBox.Text),
                ArmorLocation = SelectedArmorLocation,
                Cost = int.Parse(costTextBox.Text),
                Weight = int.Parse(weightTextBox.Text),
            };
            App.StarReverieDbContext.Armors.Add(armorModel);
            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("Armor saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
