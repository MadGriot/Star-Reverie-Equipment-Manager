// -----------------------------------------------------------------------
// 	ShieldDetailsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindows
{
    /// <summary>
    /// Interaction logic for ShieldDetailsWindow.xaml
    /// </summary>
    public partial class ShieldDetailsWindow : Window, IDetails
    {
        private ShieldModel shield;
        private DisplayItemsWindow displayItemsWindow;
        public ShieldDetailsWindow(ShieldModel shield, DisplayItemsWindow displayItemsWindow)
        {
            InitializeComponent();
            DataContext = this;
            this.shield = shield;
            this.displayItemsWindow = displayItemsWindow;
            nameTextBox.Text = shield.Name;
            spTextBox.Text = shield.MaxSP.ToString();
            spCostTextBox.Text = shield.SPCost.ToString();
            costTextBox.Text = shield.Cost.ToString();
            weightTextBox.Text = shield.Weight.ToString();

        }

        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            shield.Name = nameTextBox.Text;
            shield.MaxSP = int.Parse(spTextBox.Text);
            shield.MinSP = int.Parse(spTextBox.Text);
            shield.Cost = int.Parse(costTextBox.Text);
            shield.Weight = int.Parse(weightTextBox.Text);
            App.StarReverieDbContext.Shields.Update(shield);
            App.StarReverieDbContext.SaveChanges();
            displayItemsWindow.RefreshItems();
            Close();

        }

        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            App.StarReverieDbContext.Shields.Remove(shield);
            App.StarReverieDbContext.SaveChanges();
            displayItemsWindow.RefreshItems();
            Close();
        }

        public void ExitButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
