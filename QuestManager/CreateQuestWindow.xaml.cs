// -----------------------------------------------------------------------
// 	CreateQuestWindow.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

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
    /// Interaction logic for CreateQuestWindow.xaml
    /// </summary>
    public partial class CreateQuestWindow : Window
    {
        public CreateQuestWindow()
        {
            InitializeComponent();
        }

        private void AddQuestStageButton_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestStageWindow createQuestStageWindow = new();
            createQuestStageWindow.ShowDialog();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
