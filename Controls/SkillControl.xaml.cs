// -----------------------------------------------------------------------
// 	SkillControl.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Star_Reverie_Inventory_Manager.CharacterManager;
using StarReverieCore.Mechanics;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

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



        public SkillModel SkillModel
        {
            get { return (SkillModel)GetValue(SkillModelProperty); }
            set { SetValue(SkillModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SkillModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SkillModelProperty =
            DependencyProperty.Register(nameof(SkillModel), typeof(SkillModel), typeof(SkillControl), new PropertyMetadata(null, OnSkillModelChanged));



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

        private static void OnSkillModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            SkillControl skillControl = (SkillControl)d;
            SkillModel skillModel = (SkillModel)e.NewValue;

            if (skillModel != null)
            {
                skillControl.nameTextBlock.Text = skillModel.Skill.ToString();
                skillControl.skillLevel.Text = skillModel.Level.ToString();

            }
        }

        private void SubtractSkillButton_Click(object sender, RoutedEventArgs e)
        {

            if (SkillModel.Level > 0)
            {
                int currentSkillPoints = int.Parse(CurrentSkillPointsTextBlock?.Text ?? "0");
                int refund = SkillMechanics.GetSkillCost(SkillModel.Level - 1);

                SkillModel.Level -= 1;
                skillLevel.Text = SkillModel.Level.ToString();
                CurrentSkillPointsTextBlock?.Text = (currentSkillPoints + refund).ToString();
            }
        }

        private void AddSkillButton_Click(object sender, RoutedEventArgs e)
        {

            int currentSkillPoints = int.Parse(CurrentSkillPointsTextBlock?.Text ?? "0");
            int cost = SkillMechanics.GetSkillCost(SkillModel.Level);

            if (currentSkillPoints >= cost)
            {
                SkillModel.Level += 1;
                skillLevel.Text = SkillModel.Level.ToString();
                CurrentSkillPointsTextBlock?.Text = (currentSkillPoints - cost).ToString();
            }
        }
    }
}
