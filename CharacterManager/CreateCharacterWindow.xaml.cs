// -----------------------------------------------------------------------
// 	CreateCharacterWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.Controls;
using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.CharacterManager
{
    /// <summary>
    /// Interaction logic for CreateCharacterWindow.xaml
    /// </summary>
    public partial class CreateCharacterWindow : Window
    {
        public Array SpeciesList { get; } = Enum.GetValues(typeof(Species));
        public Array Genders { get; } = Enum.GetValues(typeof(Gender));

        private Species selectedSpecies = Species.Human;
        private Species previousSpecies = Species.Human;
        public Species SelectedSpecies
        {
            get => selectedSpecies;
            set
            {
                if (selectedSpecies != value)
                {
                    previousSpecies = selectedSpecies;
                    selectedSpecies = value;
                    OnSpeciesChange(previousSpecies, selectedSpecies);
                }
            }
        }
        public Gender SelectedGender { get; set; } = Gender.Male;
        public CreateCharacterWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SubtractAgeButton_Click(object sender, RoutedEventArgs e)
        {
            int currentAge = int.Parse(ageNumber.Text);
            if (currentAge > 4)
            {
                currentAge -= 1;

            }
            ageNumber.Text = currentAge.ToString();
        }

        private void AddAgeButton_Click(object sender, RoutedEventArgs e)
        {
            int currentAge = int.Parse(ageNumber.Text);
            if (currentAge < 200)
            {
                currentAge += 1;

            }
            ageNumber.Text = currentAge.ToString();
        }

        private void SubtractStrengthButton_Click(object sender, RoutedEventArgs e)
        {
            int currentStrength = int.Parse(strengthNumber.Text);
            if (currentStrength > 3)
            {
                currentStrength -= 1;
                hpNumber.Text = (int.Parse(hpNumber.Text) - 1).ToString();
                attributePointsNumber.Text = (int.Parse(attributePointsNumber.Text) + 1).ToString();
                carryWeight.Text = CalculateCarryWeight(currentStrength).ToString();
            }
            strengthNumber.Text = currentStrength.ToString();
        }

        private void AddStrengthButton_Click(object sender, RoutedEventArgs e)
        {
            int currentStrength = int.Parse(strengthNumber.Text);
            int currentAttributePoints = int.Parse(attributePointsNumber.Text);
            if (currentAttributePoints > 0)
            {
                currentStrength += 1;
                hpNumber.Text = (int.Parse(hpNumber.Text) + 1).ToString();
                attributePointsNumber.Text = (int.Parse(attributePointsNumber.Text) - 1).ToString();
                carryWeight.Text = CalculateCarryWeight(currentStrength).ToString();
                strengthNumber.Text = currentStrength.ToString();
            }

        }

        private void SubtractDexterityButton_Click(object sender, RoutedEventArgs e)
        {
            int currentDexterity = int.Parse(dexterityNumber.Text);
            int currentConstitution = int.Parse(constitutionNumber.Text);
            int currentDodge = int.Parse(dodge.Text);
            if (currentDexterity > 3)
            {
                currentDexterity -= 1;
                attributePointsNumber.Text = (int.Parse(attributePointsNumber.Text) + 1).ToString();
                decimal currentSpeed = (decimal)(currentDexterity + currentConstitution) / 4;
                speed.Text = currentSpeed.ToString();
                dodge.Text = ((int)Math.Round(currentSpeed + 3)).ToString();
                dexterityNumber.Text = currentDexterity.ToString();
            }
        }

        private void AddDexterityButton_Click(object sender, RoutedEventArgs e)
        {
            int currentDexterity = int.Parse(dexterityNumber.Text);
            int currentConstitution = int.Parse(constitutionNumber.Text);
            int currentAttributePoints = int.Parse(attributePointsNumber.Text);
            int currentDodge = int.Parse(dodge.Text);
            if (currentAttributePoints > 0)
            {
                currentDexterity += 1;
                attributePointsNumber.Text = (currentAttributePoints - 1).ToString();
                decimal currentSpeed = (decimal)(currentDexterity + currentConstitution) / 4;
                speed.Text = currentSpeed.ToString();
                dodge.Text = ((int)Math.Round(currentSpeed + 3)).ToString();
                dexterityNumber.Text = currentDexterity.ToString();
            }
        }

        private void SubtractIntelligenceButton_Click(object sender, RoutedEventArgs e)
        {
            int currentIntelligence = int.Parse(intelligenceNumber.Text);
            if (currentIntelligence > 3)
            {
                currentIntelligence -= 1;
                attributePointsNumber.Text = (int.Parse(attributePointsNumber.Text) + 1).ToString();
            }
            intelligenceNumber.Text = currentIntelligence.ToString();
        }

        private void AddIntelligenceButton_Click(object sender, RoutedEventArgs e)
        {
            int currentIntelligence = int.Parse(intelligenceNumber.Text);
            int currentAttributePoints = int.Parse(attributePointsNumber.Text);
            if (currentAttributePoints > 0)
            {
                currentIntelligence += 1;
                attributePointsNumber.Text = (currentAttributePoints - 1).ToString();
            }
            intelligenceNumber.Text = currentIntelligence.ToString();
        }

        private void SubtractConstitutionButton_Click(object sender, RoutedEventArgs e)
        {
            int currentDexterity = int.Parse(dexterityNumber.Text);
            int currentConstitution = int.Parse(constitutionNumber.Text);
            int currentDodge = int.Parse(dodge.Text);
            if (currentConstitution > 3)
            {
                currentConstitution -= 1;
                staminaNumber.Text = (int.Parse(staminaNumber.Text) - 1).ToString();
                attributePointsNumber.Text = (int.Parse(attributePointsNumber.Text) + 1).ToString();
                decimal currentSpeed = (decimal)(currentDexterity + currentConstitution) / 4;
                speed.Text = currentSpeed.ToString();
                dodge.Text = ((int)Math.Round(currentSpeed + 3)).ToString();
                constitutionNumber.Text = currentConstitution.ToString();
            }
        }

        private void AddConstitutionButton_Click(object sender, RoutedEventArgs e)
        {
            int currentDexterity = int.Parse(dexterityNumber.Text);
            int currentConstitution = int.Parse(constitutionNumber.Text);
            int currentAttributePoints = int.Parse(attributePointsNumber.Text);
            int currentDodge = int.Parse(dodge.Text);
            if (currentAttributePoints > 0)
            {
                currentConstitution += 1;
                staminaNumber.Text = (int.Parse(staminaNumber.Text) + 1).ToString();
                attributePointsNumber.Text = (currentAttributePoints - 1).ToString();
                decimal currentSpeed = (decimal)(currentDexterity + currentConstitution) / 4;
                speed.Text = currentSpeed.ToString();
                dodge.Text = ((int)Math.Round(currentSpeed + 3)).ToString();
                constitutionNumber.Text = currentConstitution.ToString();
            }
        }

        private void SubtractWisdomButton_Click(object sender, RoutedEventArgs e)
        {
            int currentWisdom = int.Parse(wisdomNumber.Text);
            if (currentWisdom > 3)
            {
                currentWisdom -= 1;
                attributePointsNumber.Text = (int.Parse(attributePointsNumber.Text) + 1).ToString();
            }
            wisdomNumber.Text = currentWisdom.ToString();
        }

        private void AddWisdomButton_Click(object sender, RoutedEventArgs e)
        {
            int currentWisdom = int.Parse(wisdomNumber.Text);
            int currentAttributePoints = int.Parse(attributePointsNumber.Text);
            if (currentAttributePoints > 0)
            {
                currentWisdom += 1;
                attributePointsNumber.Text = (currentAttributePoints - 1).ToString();
            }
            wisdomNumber.Text = currentWisdom.ToString();
        }

        private void AddPerceptionButton_Click(object sender, RoutedEventArgs e)
        {
            int currentPerception = int.Parse(perceptionNumber.Text);
            int currentAttributePoints = int.Parse(attributePointsNumber.Text);
            if (currentAttributePoints > 0)
            {
                currentPerception += 1;
                attributePointsNumber.Text = (currentAttributePoints - 1).ToString();
            }
            perceptionNumber.Text = currentPerception.ToString();
        }

        private void SubtractPerceptionButton_Click(object sender, RoutedEventArgs e)
        {
            int currentPerception = int.Parse(perceptionNumber.Text);
            if (currentPerception > 3)
            {
                currentPerception -= 1;
                attributePointsNumber.Text = (int.Parse(attributePointsNumber.Text) + 1).ToString();
            }
            perceptionNumber.Text = currentPerception.ToString();

            foreach (SkillModel skill in Skills)
            {
                
            }
        }

        private void OnSpeciesChange(Species oldSpecies, Species newSpecies)
        {
            switch (oldSpecies)
            {
                case Species.Sutharian:
                    perceptionNumber.Text = (int.Parse(perceptionNumber.Text) - 2).ToString();
                    break;
                case Species.Karnok:
                    strengthNumber.Text = (int.Parse(strengthNumber.Text) - 4).ToString();
                    intelligenceNumber.Text = (int.Parse(intelligenceNumber.Text) + 4).ToString();
                    break;
            }
            switch (newSpecies)
            {
                case Species.Sutharian:
                    perceptionNumber.Text = (int.Parse(perceptionNumber.Text) + 2).ToString();
                    break;
                case Species.Karnok:
                    strengthNumber.Text = (int.Parse(strengthNumber.Text) + 4).ToString();
                    intelligenceNumber.Text = (int.Parse(intelligenceNumber.Text) - 4).ToString();
                    break;
            }
        }

        public Character CreateCharacter()
        {
            Character character = new()
            {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Age = int.Parse(ageNumber.Text),
                Species = SelectedSpecies,
                Gender = SelectedGender,
                Level = 1,
                PowerLevel = 81,
                AttributePoints = int.Parse(attributePointsNumber.Text),
                SkillPoints = int.Parse(skillPointsNumber.Text),
                PortraitPath = portraitPath.Text,
                AttributeScore = new()
                {
                    Strength = int.Parse(strengthNumber.Text),
                    Dexterity = int.Parse(dexterityNumber.Text),
                    Constitution = int.Parse(constitutionNumber.Text),
                    Intelligence = int.Parse(intelligenceNumber.Text),
                    Wisdom = int.Parse(wisdomNumber.Text),
                    Perception = int.Parse(perceptionNumber.Text),
                    HP = int.Parse(hpNumber.Text),
                    MinHP = int.Parse(hpNumber.Text),
                    Stamina = int.Parse(staminaNumber.Text),
                    MinStamina = int.Parse(staminaNumber.Text),
                    BasicLift = int.Parse(carryWeight.Text),
                    Speed = decimal.Parse(speed.Text),
                    Dodge = int.Parse(dodge.Text),
                    XP = 1000,
                },
            };

            foreach (SkillModel skill in Skills)
            {
                if (skill.Level > 0)
                {
                    character.Skills.Add(new SkillModel
                    {
                        Skill = skill.Skill,
                        Level = skill.Level,
                        Character = character
                    });
                }
            }

            return character;
        }

        private int CalculateCarryWeight(int carryWeight) => (carryWeight * carryWeight) / 5;

        public ObservableCollection<SkillModel> Skills { get; } = new ObservableCollection<SkillModel>(
            Enum.GetValues(typeof(Skill))
            .Cast<Skill>()
            .Select(s => new SkillModel { Skill = s }));

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Character character = CreateCharacter();
            App.StarReverieDbContext.Characters.Add(character);
            App.StarReverieDbContext.SaveChanges();

            MessageBox.Show("Character saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();
        }
    }
}
