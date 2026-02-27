// -----------------------------------------------------------------------
// 	CreateAstralTechniqueWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Microsoft.Win32;
using StarReverieCore.Equipment;
using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.IO;
using System.Windows;

using static Star_Reverie_Inventory_Manager.InputValidator;
namespace Star_Reverie_Inventory_Manager.CreateTechniquesWindows
{
    /// <summary>
    /// Interaction logic for CreateAstralTechnique.xaml
    /// </summary>
    public partial class CreateAstralTechniqueWindow : Window
    {
        public Array DamageTypes { get; } = Enum.GetValues(typeof(DamageType));
        public Array AstralTechEffects { get; } = Enum.GetValues(typeof(AstralTechEffect));
        public Array StatusEffects { get; } = Enum.GetValues(typeof(StatusEffect));
        public Array TargetAreas { get; } = Enum.GetValues(typeof(TargetArea));

        public DamageType SelectedDamageType { get; set; } = DamageType.Burning;
        public AstralTechEffect SelectedEffect { get; set; } = AstralTechEffect.None;
        public StatusEffect SelectedStatusEffect { get; set; } = StatusEffect.None;
        public TargetArea SelectedTargetArea { get; set; } = TargetArea.Single;
        public bool IsOffensive { get; set; }
        public CreateAstralTechniqueWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TryParseInt(diceCountTextBox, "Dice Count", out int diceCount)) return;
            if (!TryParseInt(accuracyTextBox, "Accuracy", out int accuracy)) return;
            if (!TryParseInt(rangeTextBox, "Range", out int range)) return;
            if (!TryParseInt(turnCountTextBox, "Turn Count", out int turnCount)) return;
            if (!TryParseInt(turnDurationTextBox, "Turn Duration", out int turnDuration)) return;
            if (!TryParseInt(staminaCostTextBox, "Stamina Cost", out int staminaCost)) return;
            if (!TryParseInt(intTextBox, "Int Req", out int intReq)) return;
            if (!TryParseInt(radiusTextBox, "Range", out int radius)) return;
            if (!TryParseInt(costTextBox, "Cost", out int cost)) return;
            if (!TryParseDecimal(statusEffectStrengthTextBox, "Effect Strength", out decimal statusEffectStrength)) return;

            AstralTech astralTech = new()
            {
                Name = nameTextBox.Text,
                DiceCount = diceCount,
                DamageType = SelectedDamageType,
                Effect = SelectedEffect,
                StatusEffect = SelectedStatusEffect,
                Accuracy = accuracy,
                Range = range,
                TurnCount = turnCount,
                TurnCountMax = turnCount,
                StaminaCost = staminaCost,
                IntelligenceRequirement = intReq,
                Radius = radius,
                Cost = cost,
                TargetArea = SelectedTargetArea,
                IsOffensive = this.IsOffensive,
                TurnDuration = turnDuration,
                StatusEffectStrength = (float)statusEffectStrength,
                Skill = Skill.AstralTech,
                AstralTechVfxPath = vfxPathTextBox.Text,
                AstralTechSoundEffectPath = soundPathTextBox.Text,
            };
            App.StarReverieDbContext.AstralTechniques.Add(astralTech);
            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("Technique saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();
        }

        private void BrowseVfx_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Select Astral VFX File",
                Filter = "VFX Files (*.vfx;*.prefab;*.unity3d)|*.vfx;*.prefab;*.unity3d|All Files (*.*)|*.*",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (dialog.ShowDialog() == true)
            {
                // Optional: Validate file actually exists
                if (File.Exists(dialog.FileName))
                {
                    vfxPathTextBox.Text = dialog.FileName;
                }
                else
                {
                    MessageBox.Show(
                        "Selected file could not be found.",
                        "File Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
            }
        }

        private void BrowseSfx_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Select Astral Sound Effect",
                Filter = "Audio Files (*.wav;*.mp3;*.ogg)|*.wav;*.mp3;*.ogg|All Files (*.*)|*.*",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (dialog.ShowDialog() == true)
            {
                if (File.Exists(dialog.FileName))
                {
                    soundPathTextBox.Text = dialog.FileName;
                }
                else
                {
                    MessageBox.Show(
                        "Selected audio file could not be found.",
                        "File Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
            }
        }
    }
}
