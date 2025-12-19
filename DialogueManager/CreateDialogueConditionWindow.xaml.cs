// -----------------------------------------------------------------------
// 	CreateDialogueConditionWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager.DialogueManager
{
    /// <summary>
    /// Interaction logic for CreateDialogueConditionWindow.xaml
    /// </summary>
    public partial class CreateDialogueConditionWindow : Window
    {

        public Array DialogueConditionTypes { get; } = Enum.GetValues(typeof(DialogueConditionType));
        public string[] Keys { get; } = App.StarReverieDbContext.QuestModels.Select(k => k.QuestKey).ToArray();

        public DialogueConditionType SelectedDialogueCondition { get; set; } = DialogueConditionType.QuestActive;
        public string SelectedKey { get; set; }
        public bool BoolValue { get; set; }

        private readonly List<DialogueCondition> dialogueConditions;
        private TextBlock textBlockNumber;
        public CreateDialogueConditionWindow(List<DialogueCondition> dialogueConditions, TextBlock textBlockNumber)
        {
            InitializeComponent();
            DataContext = this;
            SelectedKey = Keys.First();
            this.dialogueConditions = dialogueConditions;
            this.textBlockNumber = textBlockNumber;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!InputValidator.TryParseInt(questValueBox, "Quest Value", out int questValue)) return;

                DialogueCondition newDialogueCondition = new()
                {
                    Key = SelectedKey,
                    IntValue = questValue,
                    BoolValue = BoolValue,
                    Type = SelectedDialogueCondition
                };
                //if (DialogueConditionExists(App.StarReverieDbContext.DialogueConditions.ToList(), newDialogueCondition)) 
                //    return;
                if (DialogueConditionExists(dialogueConditions, newDialogueCondition))
                {
                    MessageBox.Show($"Dialogue Condition with the same values already exists", "Ivalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;

                }
                dialogueConditions.Add(newDialogueCondition);
                textBlockNumber.Text = dialogueConditions.Count.ToString();
                Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool DialogueConditionExists(List<DialogueCondition> conditions, DialogueCondition dialogueCondition)
        {
            return conditions.Any(q => q.IntValue == dialogueCondition.IntValue
                && q.Key == dialogueCondition.Key
                && q.BoolValue == dialogueCondition.BoolValue
                && q.Type == dialogueCondition.Type);
        }
    }
}
