// -----------------------------------------------------------------------
// 	WeaponDetailsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Equipment;
using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindow
{
    /// <summary>
    /// Interaction logic for WeaponDetailsWindow.xaml
    /// </summary>
    public partial class WeaponDetailsWindow : Window
    {
        private WeaponModel weapon;
        public Array DamageTypes { get; } = Enum.GetValues(typeof(DamageType));
        public Array WeaponTypes { get; } = Enum.GetValues(typeof(WeaponType));
        public Array WeaponClasses { get; } = Enum.GetValues(typeof(WeaponClass));

        public DamageType SelectedDamageType { get; set; }
        public WeaponType SelectedWeaponType { get; set; }
        public WeaponClass SelectedWeaponClass { get; set; }
        public Skill SelectedSkill { get; set; }
        public Skill[] Skills { get; } =
        {
            Skill.MeleeWeapons,
            Skill.BallisticWeapons,
            Skill.EnergyWeapons,
            Skill.HeavyWeapons,
            Skill.MartialArts,
        };
        public WeaponDetailsWindow(WeaponModel weapon)
        {
            InitializeComponent();
            DataContext = this;
            this.weapon = weapon;
            nameTextBox.Text = weapon.Name;
            SelectedDamageType = weapon.DamageType;
            SelectedWeaponType = weapon.WeaponType;
            SelectedWeaponClass = weapon.WeaponClass;
            SelectedSkill = weapon.Skill;
            damageTextBox.Text = weapon.DiceCount.ToString();
            modifierTextBox.Text = weapon.Modifier.ToString();
            accTextBox.Text = weapon.Accuracy.ToString();
            rangeTextBox.Text = weapon.Range.ToString();
            weightTextBox.Text = weapon.WeaponWeight.ToString();
            ammoWeightTextBox.Text = weapon.AmmoWeight.ToString();
            roFTextBox.Text = weapon.RoF.ToString();
            ShotsTextBox.Text = weapon.MaxAmmo.ToString();
            STRTextBox.Text = weapon.STRRequirement.ToString();
            bulkTextBox.Text = weapon.Bulk.ToString();
            costTextBox.Text = weapon.Cost.ToString();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
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
            App.StarReverieDbContext.Weapons.Update(weaponModel);
            App.StarReverieDbContext.SaveChanges();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            App.StarReverieDbContext.Weapons.Remove(weapon);
            App.StarReverieDbContext.SaveChanges();
            Close();
        }
    }
}
