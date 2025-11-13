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

namespace Star_Reverie_Inventory_Manager
{
    /// <summary>
    /// Interaction logic for CreateShieldWindow.xaml
    /// </summary>
    public partial class CreateShieldWindow : Window
    {
        public CreateShieldWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
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
            Close();
        }
    }
}
