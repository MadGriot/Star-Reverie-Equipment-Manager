// -----------------------------------------------------------------------
// 	SelectNextNodeWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Star_Reverie_Inventory_Manager.Controls;
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

namespace Star_Reverie_Inventory_Manager.DialogueManager
{
    /// <summary>
    /// Interaction logic for SelectNextNodeWindow.xaml
    /// </summary>
    public partial class SelectNextNodeWindow : Window
    {
        private List<DialogueNode> dialogueNodes;
        public SelectNextNodeWindow()
        {
            InitializeComponent();
            dialogueNodes = App.StarReverieDbContext.DialogueNodes
                .Include(n => n.NextNode).ToList();
            ItemsListView.ItemsSource = dialogueNodes;
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
            
        }
    }
}
