// -----------------------------------------------------------------------
// 	CreateQuestStageWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

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

namespace Star_Reverie_Inventory_Manager.QuestManager
{
    /// <summary>
    /// Interaction logic for CreateQuestStageWindow.xaml
    /// </summary>
    public partial class CreateQuestStageWindow : Window
    {
        List<QuestStage> questStages;
        private TextBlock textBlockNumber;

        public CreateQuestStageWindow(List<QuestStage> questStages, TextBlock textBlockNumber)
        {
            InitializeComponent();
            this.questStages = questStages;
            this.textBlockNumber = textBlockNumber;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            QuestStage questStage = new()
            {
                Description = descriptionTextBox.Text,
                StageIndex = Math.Max(0, questStages.Count - 1)
            };
            questStages.Add(questStage);
            textBlockNumber.Text = questStages.Count.ToString();
            Close();
 
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
