using StarReverieCore.Equipment;
using StarReverieCore.Mechanics;
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

        public Skill[] Skills { get; } =
        {
            Skill.MeleeWeapons,
            Skill.BallisticWeapons,
            Skill.EnergyWeapons,
            Skill.HeavyWeapons,
            Skill.MartialArts,
        };

        public DamageType SelectedDamageType { get; set; } = DamageType.Piercing;
        public WeaponType SelectedWeaponType { get; set; } = WeaponType.RangedPhysical;
        public WeaponClass SelectedWeaponClass { get; set; } = WeaponClass.Pistol;
        public Skill SelectedSkill { get; set; } = Skill.BallisticWeapons;

        public CreateWeaponsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Save weapon
            WeaponModel weaponModel = new()
            {
                Name = nameTextBox.Text,
                DamageType = SelectedDamageType,
                WeaponType = SelectedWeaponType,
                WeaponClass = SelectedWeaponClass,
                Accuracy = int.Parse(accTextBox.Text),
                Range = int.Parse(rangeTextBox.Text),
                WeaponWeight = decimal.Parse(weightTextBox.Text),
                AmmoWeight = decimal.Parse(ammoWeightTextBox.Text),
                RoF = int.Parse(roFTextBox.Text),
                MaxAmmo = int.Parse(ShotsTextBox.Text),
                CurrentAmmo = int.Parse(ShotsTextBox.Text),
                STRRequirement = int.Parse(STRTextBox.Text),
                Bulk = int.Parse(bulkTextBox.Text),
                Cost = int.Parse(costTextBox.Text),
                Skill = SelectedSkill,
                DiceCount = int.Parse(damageTextBox.Text),
                Modifier = int.Parse(modifierTextBox.Text),
            };
            App.StarReverieDbContext.Weapons.Add(weaponModel);
            App.StarReverieDbContext.SaveChanges();
            Close();
        }
    }
}
