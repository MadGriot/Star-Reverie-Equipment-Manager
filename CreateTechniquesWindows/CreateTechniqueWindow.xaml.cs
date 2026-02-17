// -----------------------------------------------------------------------
// 	CreateTechniqueWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.Collections.ObjectModel;
using System.Windows;
using static Star_Reverie_Inventory_Manager.InputValidator;
namespace Star_Reverie_Inventory_Manager.CreateTechniquesWindows
{
    /// <summary>
    /// Interaction logic for CreateTechniqueWindow.xaml
    /// </summary>
    public partial class CreateTechniqueWindow : Window
    {

        public Array AttributeTypes => Enum.GetValues(typeof(AttributeType));
        public Array Skills => Enum.GetValues(typeof(Skill));
        public bool IsOffensive { get; set; }
        public ObservableCollection<TechniqueRequirement> TechniqueRequirements { get; set; }
            = new ObservableCollection<TechniqueRequirement>();
        public CreateTechniqueWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // --- Validation ---
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TryParseInt(turnCountTextBox, "Turn Count", out int turnCount)) return;
            if (!TryParseInt(staminaCostTextBox, "Stamina Cost", out int staminaCost)) return;
            if (!TryParseInt(costTextBox, "Cost", out int cost)) return;

            // --- Save Technique ---
            Technique technique = new()
            {
                Name = nameTextBox.Text,
                TurnCount = turnCount,
                StaminaCost = staminaCost,
                Cost = cost,
                IsOffensive = this.IsOffensive,
            };

            // Add technique to DB first so it gets an ID
            App.StarReverieDbContext.Techniques.Add(technique);
            App.StarReverieDbContext.SaveChanges();

            // --- Save Technique Requirements ---
            foreach (TechniqueRequirement requirement in TechniqueRequirements)
            {
                // Set the TechniqueId / relationship if needed
                requirement.TechniqueId = technique.Id; // assuming TechniqueRequirement has a TechniqueId FK
                App.StarReverieDbContext.TechniqueRequirements.Add(requirement);
            }

            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("Technique and requirements saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();

        }

        private void AddRequirement_Click(object sender, RoutedEventArgs e)
        {
            if (requirementTypeComboBox.SelectedIndex == 0)
            {
                TechniqueRequirements.Add(new AttributeRequirement
                {
                    AttributeType = AttributeType.Strength,
                    RequiredValue = 1
                });
            }
            else if (requirementTypeComboBox.SelectedIndex == 1)
            {
                TechniqueRequirements.Add(new SkillRequirement
                {
                    Skill = Skill.Acrobatics,
                    RequiredLevel = 1
                });
            }
        }
    }

}
