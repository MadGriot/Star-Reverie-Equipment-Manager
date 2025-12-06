// -----------------------------------------------------------------------
// 	ArmorDetailsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Equipment;
using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindows
{
    /// <summary>
    /// Interaction logic for ArmorDetailsWindow.xaml
    /// </summary>
    public partial class ArmorDetailsWindow : Window, IDetails
    {
        private ArmorModel armor;
        private DisplayItemsWindow displayItemsWindow;
        public Array ArmorLocations { get; } = Enum.GetValues(typeof(ArmorLocation));
        public ArmorLocation SelectedArmorLocation { get; set; }

        public ArmorDetailsWindow(ArmorModel armor, DisplayItemsWindow displayItemsWindow)
        {
            InitializeComponent();
            DataContext = this;
            this.armor = armor;
            this.displayItemsWindow = displayItemsWindow;
            nameTextBox.Text = armor.Name;
            SelectedArmorLocation = armor.ArmorLocation;
            damageResistanceTextBox.Text = armor.DamageResistance.ToString();
            weightTextBox.Text = armor.Weight.ToString();
            costTextBox.Text = armor.Cost.ToString();
        }

        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            armor.Name = nameTextBox.Text;
            armor.ArmorLocation = SelectedArmorLocation;
            armor.DamageResistance = int.Parse(damageResistanceTextBox.Text);
            armor.Weight = int.Parse(weightTextBox.Text);
            armor.Cost = int.Parse(costTextBox.Text);
            App.StarReverieDbContext.Update(armor);
            App.StarReverieDbContext.SaveChanges();
            displayItemsWindow.ReadItemsFromDatabase(ItemType.Armor);
            Close();
        }

        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            App.StarReverieDbContext.Remove(armor);
            App.StarReverieDbContext.SaveChanges();
            displayItemsWindow.ReadItemsFromDatabase(ItemType.Armor);
            Close();
        }

        public void ExitButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
