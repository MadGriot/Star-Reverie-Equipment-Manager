using StarReverieCore.Mechanics;
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
        public SkillControl()
        {
            InitializeComponent();
        }



        public Skill Skills
        {
            get { return (Skill)GetValue(SkillsProperty); }
            set { SetValue(SkillsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Skills.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SkillsProperty =
            DependencyProperty.Register(nameof(Skills), typeof(Skill), typeof(SkillControl), new PropertyMetadata(default(Skill), SetText));

        public int SkillPoints
        {
            get => (int)GetValue(SkillPointsProperty);
            set => SetValue(SkillPointsProperty, value);
        }

        public static readonly DependencyProperty SkillPointsProperty =
            DependencyProperty.Register(nameof(SkillPoints), typeof(int), typeof(SkillControl), new PropertyMetadata(0));

        public int Level
        {
            get => (int)GetValue(LevelProperty);
            set => SetValue(LevelProperty, value);
        }

        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register(nameof(Level), typeof(int), typeof(SkillControl), new PropertyMetadata(0));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SkillControl skillControl = (SkillControl)d;

            if (skillControl != null)
            {
                Skill skill = (Skill)e.NewValue;
                skillControl.nameTextBlock.Text = skill.ToString();
            }
        }

        private void SubtractSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (SkillPoints > 0)
            {
                Level += 1;
                SkillPoints -= 1;
            }
        }

        private void AddSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (Level > 0)
            {
                Level -= 1;
                SkillPoints += 1;
            }
        }
    }
}
