// -----------------------------------------------------------------------
// 	CreateCharacterWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Star_Reverie_Inventory_Manager.CharacterManager
{
    /// <summary>
    /// Interaction logic for CreateCharacterWindow.xaml
    /// </summary>
    public partial class CreateCharacterWindow : Window
    {
        public CreateCharacterWindow()
        {
            InitializeComponent();
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
                attributePointsNumber.Text = (int.Parse(attributePointsNumber.Text) + 1).ToString();
                carryWeight.Text = CalculateCarryWeight(currentStrength).ToString();
            }
            strengthNumber.Text = currentStrength.ToString();
        }

        private void AddStrengthButton_Click(object sender, RoutedEventArgs e)
        {
            int currentStrength = int.Parse(strengthNumber.Text);

            currentStrength += 1;
            attributePointsNumber.Text = (int.Parse(attributePointsNumber.Text) - 1).ToString();
            carryWeight.Text = CalculateCarryWeight(currentStrength).ToString();
            strengthNumber.Text = currentStrength.ToString();
        }

        private void SubtractDexterityButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddDexterityButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubtractIntelligenceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddIntelligenceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubtractConstitutionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddConstitutionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubtractWisdomButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddWisdomButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPerceptionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubtractPerceptionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private int CalculateCarryWeight(int carryWeight) => (carryWeight * carryWeight) / 5;

    }
}
