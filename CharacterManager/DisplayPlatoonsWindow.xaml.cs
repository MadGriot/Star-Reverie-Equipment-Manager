// -----------------------------------------------------------------------
// 	DisplayPlatoonsWindow.xaml.cs
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

namespace Star_Reverie_Inventory_Manager.CharacterManager
{
    /// <summary>
    /// Interaction logic for DisplayPlatoonsWindow.xaml
    /// </summary>
    public partial class DisplayPlatoonsWindow : Window
    {
        private List<PlatoonModel> platoons;
        public DisplayPlatoonsWindow()
        {
            InitializeComponent();
            platoons = App.StarReverieDbContext.Platoons
                .Where(s => s.Squads.Count() < 4).ToList();
                        ItemsListView.ItemsSource = platoons;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
