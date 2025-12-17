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

        }
        private void AddDialogueEffectButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SelectNextNodeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectNextNodeWindow selectNextNodeWindow = new();
            selectNextNodeWindow.ShowDialog();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
