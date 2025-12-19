// -----------------------------------------------------------------------
// 	CreateDialogueWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.DialogueManager
{
    /// <summary>
    /// Interaction logic for CreateDialogueWindow.xaml
    /// </summary>
    public partial class CreateDialogueWindow : Window
    {
        private readonly Character character;
        public List<DialogueCondition> DialogueConditions { get; set; } = new();
        public List<DialogueChoice> DialogueChoices { get; set; } = new();
        public List<DialogueEffect> DialogueEffects { get; set; } = new();
        public DialogueNode? NextDialogueNode { get; set; } = null;
        public CreateDialogueWindow(Character character)
        {
            InitializeComponent();
            this.character = character;
            nextNodeTextBox.Text = NextDialogueNode?.Text ?? "None";
        }

        private void AddDialogueChoiceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddDialogueConditionButton_Click(object sender, RoutedEventArgs e)
        {
            CreateDialogueConditionWindow createDialogueConditionWindow = new(DialogueConditions, dialogueConditionAmount);
            createDialogueConditionWindow.ShowDialog();
        }
        private void AddDialogueEffectButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SelectNextNodeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectNextNodeWindow selectNextNodeWindow = new(NextDialogueNode, nextNodeTextBox);
            selectNextNodeWindow.ShowDialog();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DialogueConditions.Count > 0)
            {
                DialogueNode dialogueNode = new()
                {
                    Text = dialogueTextBox.Text,
                    NextNode = NextDialogueNode,
                    NextNodeId = NextDialogueNode?.NextNodeId ?? null,
                    Conditions = DialogueConditions,
                    Choices = DialogueChoices,
                    Effects = DialogueEffects,

                };
                character.Dialogues.Add(dialogueNode);
                App.StarReverieDbContext.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show($"You must have aleast one Dialogue Condition to save", "Ivalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
