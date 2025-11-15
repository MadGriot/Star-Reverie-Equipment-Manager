// -----------------------------------------------------------------------
// 	ArmorDetailsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Equipment;
using StarReverieCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindow
{
    /// <summary>
    /// Interaction logic for ArmorDetailsWindow.xaml
    /// </summary>
    public partial class ArmorDetailsWindow : Window
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

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            App.StarReverieDbContext.Remove(armor);
            App.StarReverieDbContext.SaveChanges();
            displayItemsWindow.ReadItemsFromDatabase(ItemType.Armor);
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
