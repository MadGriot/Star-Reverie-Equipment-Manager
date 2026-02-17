// -----------------------------------------------------------------------
// 	CreateQuestWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.QuestManager
{
    /// <summary>
    /// Interaction logic for CreateQuestWindow.xaml
    /// </summary>
    public partial class CreateQuestWindow : Window
    {
        private ObservableCollection<QuestStage> questStages;
        public CreateQuestWindow()
        {
            InitializeComponent();
            questStages = new();
            QuestStagesListView.ItemsSource = questStages;
            questStageAmount.Text = questStages.Count.ToString();

            questStages.CollectionChanged += (s, e) =>
            {
                questStageAmount.Text = questStages.Count.ToString();
            };
        }

        private void AddQuestStageButton_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestStageWindow createQuestStageWindow = new();
            if (createQuestStageWindow.ShowDialog() == true && createQuestStageWindow.CreatedStage != null)
            {
                // Assign required StageIndex here
                createQuestStageWindow.CreatedStage.StageIndex = questStages.Count;

                questStages.Add(createQuestStageWindow.CreatedStage);
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (questStages.Count == 0)
            {
                MessageBox.Show("You must add a Quest Stage to save",
                                "Invalid Input",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            QuestModel questModel = new()
            {
                QuestKey = questKeyTextBox.Text,
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
                QuestStages = questStages.ToList()
            };

            App.StarReverieDbContext.QuestModels.Add(questModel);
            App.StarReverieDbContext.SaveChanges();
            Close();
        }
    }
}
