// -----------------------------------------------------------------------
// 	WeaponDetailsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Equipment;
using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindows
{
    /// <summary>
    /// Interaction logic for WeaponDetailsWindow.xaml
    /// </summary>
    public partial class WeaponDetailsWindow : Window
    {
        private WeaponModel weapon;
        private DisplayItemsWindow displayItemsWindow;
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
        public WeaponDetailsWindow(WeaponModel weapon, DisplayItemsWindow displayItemsWindow)
        {
            InitializeComponent();
            DataContext = this;
            this.weapon = weapon;
            this.displayItemsWindow = displayItemsWindow;
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

            weapon.Name = nameTextBox.Text;
            weapon.DamageType = SelectedDamageType;
            weapon.WeaponType = SelectedWeaponType;
            weapon.WeaponClass = SelectedWeaponClass;
            weapon.Accuracy = int.Parse(accTextBox.Text);
            weapon.Range = int.Parse(rangeTextBox.Text);
            weapon.WeaponWeight = decimal.Parse(weightTextBox.Text);
            weapon.AmmoWeight = decimal.Parse(ammoWeightTextBox.Text);
            weapon.RoF = int.Parse(roFTextBox.Text);
            weapon.MaxAmmo = int.Parse(ShotsTextBox.Text);
            weapon.CurrentAmmo = int.Parse(ShotsTextBox.Text);
            weapon.STRRequirement = int.Parse(STRTextBox.Text);
            weapon.Bulk = int.Parse(bulkTextBox.Text);
            weapon.Cost = decimal.Parse(costTextBox.Text);
            weapon.Skill = SelectedSkill;
            weapon.DiceCount = int.Parse(damageTextBox.Text);
            weapon.Modifier = int.Parse(modifierTextBox.Text);
            App.StarReverieDbContext.Weapons.Update(weapon);
            App.StarReverieDbContext.SaveChanges();
            displayItemsWindow.ReadItemsFromDatabase(ItemType.Weapon);
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            App.StarReverieDbContext.Weapons.Remove(weapon);
            App.StarReverieDbContext.SaveChanges();
            displayItemsWindow.ReadItemsFromDatabase(ItemType.Weapon);
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
