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
