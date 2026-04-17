// -----------------------------------------------------------------------
// 	CharacterTechniqueDetails.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Mechanics;
using StarReverieCore.Models;
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

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindows
{
    /// <summary>
    /// Interaction logic for CharacterTechniqueDetails.xaml
    /// </summary>
    public partial class CharacterTechniqueDetails : Window
    {
        private Technique technique;
        private Character character;
        private DisplayItemsWindow displayItemsWindow;
        public CharacterTechniqueDetails(Technique technique, Character character, DisplayItemsWindow displayItemsWindow)
        {
            InitializeComponent();
            this.technique = technique;
            this.character = character;
            this.displayItemsWindow = displayItemsWindow;
            nameTextBox.Text = technique.Name;
            descriptionTextBox.Text = technique?.Description;
        }
        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            if (technique != null)
                TechniqueActions.ForgetTechnique(character, technique);
            displayItemsWindow.RefreshItems();
            App.StarReverieDbContext.SaveChanges();
            Close();
        }

        public void ExitButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
