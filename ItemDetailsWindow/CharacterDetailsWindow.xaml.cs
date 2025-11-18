// -----------------------------------------------------------------------
// 	CharacterDetailsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindow
{
    /// <summary>
    /// Interaction logic for CharacterDetailsWindow.xaml
    /// </summary>
    public partial class CharacterDetailsWindow : Window
    {
        private Character character;
        private List<UnitStack> inventory = new();
        public CharacterDetailsWindow(Character character)
        {
            InitializeComponent();
            this.character = character;
            SetInventory();
            SetText();
        }

        public void SetInventory()
        {
            if (character.Inventory != null)
            {
                inventory = character.Inventory.Units.ToList();

            }
            ItemsListView.ItemsSource = inventory;
        }

        private void SetText()
        {
            NameText.Text = $"{character.FirstName} {character.LastName}";
            EquippedWeaponText.Text = character.Weapon?.Name;
            EquippedArmorText.Text = character.Armor?.Name;
            EquippedShieldText.Text = character.Shield?.Name;

            LevelText.Text = character.Level.ToString();
            StrengthText.Text = character.AttributeScore.Strength.ToString();
            DexterityText.Text = character.AttributeScore.Dexterity.ToString();
            IntelligenceText.Text = character.AttributeScore.Intelligence.ToString();
            ConstitutionText.Text = character.AttributeScore.Constitution.ToString();
            WisdomText.Text = character.AttributeScore.Wisdom.ToString();
            PerceptionText.Text = character.AttributeScore.Perception.ToString();
            BasicLiftText.Text = character.AttributeScore.BasicLift.ToString();
            SpeedText.Text = character.AttributeScore.Speed.ToString();
            DodgeText.Text = character.AttributeScore.Dodge.ToString();
            DamageText.Text = $"{character.Weapon?.DiceCount} - {character.Weapon?.DiceCount * 6}";
            DamageResistanceText.Text = $"{character.Armor?.DamageResistance}";
            WeightText.Text = character.AttributeScore.Weight.ToString();
            EncumbranceText.Text = character.AttributeScore.Encumbrance.ToString();

        }
        public void UpdateCharacterStats()
        {
            EquippedWeaponText.Text = character.Weapon?.Name;
            EquippedArmorText.Text = character.Armor?.Name;
            EquippedShieldText.Text = character.Shield?.Name;
        }
        private void AddWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.Weapon, character, this);
            displayItemsWindow.ShowDialog();
        }

        private void AddArmorButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.Armor, character, this);
            displayItemsWindow.ShowDialog();
        }

        private void AddShieldButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.Shield, character, this);
            displayItemsWindow.ShowDialog();
        }

        private void EquipWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.Weapon, character);
            displayItemsWindow.SetCharacterDetailsWindow(this);
            displayItemsWindow.ShowDialog();
        }

        private void EquipArmorButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.Armor, character);
            displayItemsWindow.SetCharacterDetailsWindow(this);
            displayItemsWindow.ShowDialog();
        }

        private void EquipShieldButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow displayItemsWindow = new(ItemType.Shield, character);
            displayItemsWindow.SetCharacterDetailsWindow(this);
            displayItemsWindow.ShowDialog();
        }
    }
}
