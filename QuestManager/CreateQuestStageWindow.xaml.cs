// -----------------------------------------------------------------------
// 	CreateQuestStageWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager.QuestManager
{
    /// <summary>
    /// Interaction logic for CreateQuestStageWindow.xaml
    /// </summary>
    public partial class CreateQuestStageWindow : Window
    {
        public QuestStage? CreatedStage { get; private set; }

        public CreateQuestStageWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CreatedStage = new()
            {
                Description = descriptionTextBox.Text,
            };

            DialogResult = true;
            Close();
 
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
