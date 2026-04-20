// -----------------------------------------------------------------------
// 	SelectNextNodeWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager.DialogueManager
{
    /// <summary>
    /// Interaction logic for SelectNextNodeWindow.xaml
    /// </summary>
    public partial class SelectNextNodeWindow : Window
    {
        private List<DialogueNode> dialogueNodes;
        public DialogueNode? nextNode { get; private set; }
        private TextBlock nextNodeText;
        public SelectNextNodeWindow(DialogueNode? nextNode, TextBlock nextNodeText)
        {
            InitializeComponent();
            dialogueNodes = App.StarReverieDbContext.Dialogues
                .Include(n => n.NextNode).ToList();
            ItemsListView.ItemsSource = dialogueNodes;
            this.nextNode = nextNode;
            this.nextNodeText = nextNodeText;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = (TextBox)sender;

            List<DialogueNode> filteredList = dialogueNodes
                .Where(c => c.Text.ToLower().Contains(searchTextBox.Text.ToLower()))
                .ToList();

            ItemsListView.ItemsSource = filteredList;
        }
        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsListView.SelectedItem is DialogueNode selectedItem)
            {
                nextNode = selectedItem;
                nextNodeText.Text = selectedItem.Text;
                Close();
            }
        }
    }
}
