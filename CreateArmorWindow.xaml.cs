// -----------------------------------------------------------------------
// 	CreateArmorWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Equipment;
using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager
{
    /// <summary>
    /// Interaction logic for CreateArmorWindow.xaml
    /// </summary>
    public partial class CreateArmorWindow : Window
    {
        public Array ArmorLocations { get; } = Enum.GetValues(typeof(ArmorLocation));
        public ArmorLocation SelectedArmorLocation { get; set; } = ArmorLocation.FullSuit;
        public CreateArmorWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
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
            Close();
        }
    }
}
