// -----------------------------------------------------------------------
// 	CreateQuestWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager.QuestManager
{
    /// <summary>
    /// Interaction logic for CreateQuestWindow.xaml
    /// </summary>
    public partial class CreateQuestWindow : Window
    {
        List<QuestStage> questStages;
        public CreateQuestWindow()
        {
            InitializeComponent();
            questStages = new();
            questStageAmount.Text = questStages.Count.ToString();
        }

        private void AddQuestStageButton_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestStageWindow createQuestStageWindow = new(questStages, questStageAmount);
            createQuestStageWindow.ShowDialog();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (questStages.Count > 0)
            {
                QuestModel questModel = new()
                {
                    QuestKey = questKeyTextBox.Text,
                    Name = nameTextBox.Text,
                    Description = descriptionTextBox.Text,
                };
                questModel.QuestStages = questStages;
                App.StarReverieDbContext.QuestModels.Add(questModel);
                App.StarReverieDbContext.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show($"You must add a Quest Stage to save", "Ivalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
