// -----------------------------------------------------------------------
// 	CharacterDetailsWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.CharacterManager;
using Star_Reverie_Inventory_Manager.DialogueManager;
using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindows
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

        public void SetText()
        {
            NameText.Text = $"{character.FirstName} {character.LastName}";
            EquippedWeaponText.Text = character.Weapon?.Name ?? "No Weapon";
            EquippedArmorText.Text = character.Armor?.Name ?? "No Armor";
            EquippedShieldText.Text = character.Shield?.Name ?? "No Shield";

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
            SquadName.Text = character.Squad?.Name.ToString() ?? "None";

        }
        private void AddWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Weapon, ActionStatus.AddingItem, character, this);
            window.ShowDialog();
        }

        private void AddArmorButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Armor, ActionStatus.AddingItem, character, this);
            window.ShowDialog();
        }
        private void AddAmmoButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Ammo, ActionStatus.AddingItem, character, this);
            window.ShowDialog();
        }

        private void AddShieldButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Shield, ActionStatus.AddingItem, character, this);
            window.ShowDialog();
        }

        private void EquipWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Weapon, ActionStatus.EquippingItem, character, this);
            window.ShowDialog();
        }

        private void UnequipWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryActions.UnequipWeapon(character);
            SetText();
            App.StarReverieDbContext.SaveChanges();
        }
        private void UnequipArmorButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryActions.UnequipArmor(character);
            SetText();
            App.StarReverieDbContext.SaveChanges();
        }
        private void UnequipShieldButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryActions.UnequipShield(character);
            SetText();
            App.StarReverieDbContext.SaveChanges();
        }
        private void EquipArmorButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Armor, ActionStatus.EquippingItem, character, this);
            window.ShowDialog();
        }

        private void EquipShieldButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Shield, ActionStatus.EquippingItem, character, this);
            window.ShowDialog();
        }

        private void AddAstralTechniqueButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.AstralTechnique, ActionStatus.LearnTechnique, character, this);
            window.ShowDialog();
        }
        private void AddTechniqueButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Technique, ActionStatus.LearnTechnique, character, this);
            window.ShowDialog();
        }
        private void DisplayTechniques_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.Technique, ActionStatus.DisplayTechniques, character, this);
            window.ShowDialog();
        }

        private void DisplayAstralTechniques_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsWindow window = new(ItemType.AstralTechnique, ActionStatus.DisplayTechniques, character, this);
            window.ShowDialog();
        }

        private void ChangeSquad_Click(object sender, RoutedEventArgs e)
        {
            DisplaySquadWindow window = new(character, this);
            window.ShowDialog();
        }
        private void CreateDialogue_Click(object sender, RoutedEventArgs e)
        {
            CreateDialogueWindow createDialogueWindow = new(character);
            createDialogueWindow.ShowDialog();
        }
        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsListView.SelectedItem is UnitStack selectedItem)
            {
                InventoryItemDetials window = new(selectedItem, character, this);
                window.ShowDialog();

            }

        }
    }
}
