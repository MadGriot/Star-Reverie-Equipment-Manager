// -----------------------------------------------------------------------
// 	CreateAstralTechnique.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Equipment;
using StarReverieCore.Mechanics;
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


        public DamageType SelectedDamageType { get; set; } = DamageType.Burning;
        public AstralTechEffect SelectedEffect { get; set; } = AstralTechEffect.None;
        public StatusEffect SelectedStatusEffect { get; set; } = StatusEffect.None;
        public CreateAstralTechniqueWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
