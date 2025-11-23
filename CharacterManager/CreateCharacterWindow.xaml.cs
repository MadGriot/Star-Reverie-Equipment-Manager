// -----------------------------------------------------------------------
// 	CreateCharacterWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
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

        public Species SelectedSpecies { get; set; } = Species.Human;
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

        }

        private int CalculateCarryWeight(int carryWeight) => (carryWeight * carryWeight) / 5;

    }
}
