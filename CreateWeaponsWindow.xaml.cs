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
    /// Interaction logic for CreateWeaponsWindow.xaml
    /// </summary>
    public partial class CreateWeaponsWindow : Window
    {
        public Array DamageTypes { get; } = Enum.GetValues(typeof(DamageType));
        public Array WeaponTypes { get; } = Enum.GetValues(typeof(WeaponType));
        public Array WeaponClasses { get; } = Enum.GetValues(typeof(WeaponClass));

        public DamageType SelectedDamageType { get; set; } = DamageType.Piercing;
        public WeaponType SelectedWeaponType { get; set; } = WeaponType.RangedPhysical;
        public WeaponClass SelectedWeaponClass { get; set; } = WeaponClass.Pistol;
        public CreateWeaponsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Save weapon
            //WeaponModel weaponModel = new()
            //{
            //    Name = nameTextBox.Text,
            //    DamageType = SelectedDamageType,
            //    WeaponType = SelectedWeaponType,
            //    WeaponClass = SelectedWeaponClass,
            //};
            Close();
        }
    }
}
