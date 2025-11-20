// -----------------------------------------------------------------------
// 	CreateWeaponsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Equipment;
using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

using static Star_Reverie_Inventory_Manager.InputValidator;
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
        public AmmoModel[] AmmoModels { get; } = App.StarReverieDbContext.Ammos.ToArray();

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
        public AmmoModel SelectedAmmo { get; set; }
        public Skill SelectedSkill { get; set; } = Skill.BallisticWeapons;

        public CreateWeaponsWindow()
        {
            InitializeComponent();
            DataContext = this;
            SelectedAmmo = AmmoModels[0];
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!TryParseInt(accTextBox, "Accuracy", out int accuracy)) return;
            if (!TryParseInt(rangeTextBox, "Range", out int range)) return;
            if (!TryParseDecimal(weightTextBox, "Weapon Weight", out decimal weaponWeight)) return;
            if (!TryParseDecimal(ammoWeightTextBox, "Ammo Weight", out decimal ammoWeight)) return;
            if (!TryParseInt(roFTextBox, "Rate of Fire", out int rof)) return;
            if (!TryParseInt(ShotsTextBox, "Max Ammo", out int maxAmmo)) return;
            if (!TryParseInt(STRTextBox, "STR Requirement", out int strReq)) return;
            if (!TryParseInt(bulkTextBox, "Bulk", out int bulk)) return;
            if (!TryParseInt(costTextBox, "Cost", out int cost)) return;
            if (!TryParseInt(damageTextBox, "Dice Count", out int diceCount)) return;
            if (!TryParseInt(modifierTextBox, "Damage Modifier", out int modifier)) return;
            //Save weapon
            WeaponModel weaponModel = new()
            {
                Name = nameTextBox.Text,
                DamageType = SelectedDamageType,
                WeaponType = SelectedWeaponType,
                WeaponClass = SelectedWeaponClass,
                Ammo = SelectedAmmo,
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

            MessageBox.Show("Weapon saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();
        }
    }
}
