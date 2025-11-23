// -----------------------------------------------------------------------
// 	SkillControl.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.CharacterManager;
using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Star_Reverie_Inventory_Manager.Controls
{
    /// <summary>
    /// Interaction logic for SkillControl.xaml
    /// </summary>
    public partial class SkillControl : UserControl
    {
        private CreateCharacterWindow? CreateCharacterWindow;
        private TextBlock? CurrentSkillPointsTextBlock;
        public SkillControl()
        {

            InitializeComponent();
            CreateCharacterWindow = Application.Current.Windows
                        .OfType<CreateCharacterWindow>()
                        .FirstOrDefault();
            if (CreateCharacterWindow != null)
            {
                CurrentSkillPointsTextBlock = CreateCharacterWindow.skillPointsNumber;
            }
        }



        public Skill? Skills
        {
            get { return (Skill)GetValue(SkillsProperty); }
            set { SetValue(SkillsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Skills.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SkillsProperty =
            DependencyProperty.Register(nameof(Skills), typeof(Skill?), typeof(SkillControl), new PropertyMetadata(null, SetText));



        public int Level
        {
            get => (int)GetValue(LevelProperty);
            set => SetValue(LevelProperty, value);
        }

        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register(nameof(Level), typeof(int), typeof(SkillControl), new PropertyMetadata(0, OnLevelChanged));

        private static void OnLevelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SkillControl control = (SkillControl)d;
            control.skillLevel.Text = e.NewValue.ToString();
        }

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            SkillControl skillControl = (SkillControl)d;
            skillControl.nameTextBlock.Text = e.NewValue.ToString();
        }

        private void SubtractSkillButton_Click(object sender, RoutedEventArgs e)
        {

            int currentSkillPoints = int.Parse(CurrentSkillPointsTextBlock.Text);
            int currentLevel = int.Parse(skillLevel.Text);
            int skillCost = SkillMechanics.GetSkillCost(currentLevel - 1);
            if (Level > 0)
            {
                Level = (currentLevel - 1);
                currentSkillPoints += skillCost;
                CurrentSkillPointsTextBlock.Text = currentSkillPoints.ToString();
            }
        }

        private void AddSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is SkillModel skill)
            {

            }
            int currentSkillPoints = int.Parse(CurrentSkillPointsTextBlock.Text);
            int currentLevel = int.Parse(skillLevel.Text);
            int skillCost = SkillMechanics.GetSkillCost(currentLevel);
            if (currentSkillPoints >= skillCost)
            {
                Level = (currentLevel + 1);
                currentSkillPoints -= skillCost;
                CurrentSkillPointsTextBlock.Text = currentSkillPoints.ToString();
            }
        }
    }
}
