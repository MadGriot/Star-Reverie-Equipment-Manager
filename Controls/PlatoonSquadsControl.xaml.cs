// -----------------------------------------------------------------------
// 	PlatoonSquadsControl.xaml.cs
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Star_Reverie_Inventory_Manager.Controls
{
    /// <summary>
    /// Interaction logic for PlatoonSquadsControl.xaml
    /// </summary>
    public partial class PlatoonSquadsControl : UserControl
    {
        public event EventHandler<SquadModel>? DeleteRequested;
        public SquadModel Squad
        {
            get { return (SquadModel)GetValue(SquadProperty); }
            set { SetValue(SquadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Squad.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SquadProperty =
            DependencyProperty.Register(nameof(Squad), typeof(SquadModel), typeof(SquadControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SquadControl squadControl = (SquadControl)d;

            if (squadControl != null)
            {
                SquadModel squad = (SquadModel)e.NewValue;

                squadControl.nameTextBlock.Text = squad.Name;
            }
        }

        private void DeleteSquadButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteRequested?.Invoke(this, Squad);
        }
        public PlatoonSquadsControl()
        {
            InitializeComponent();
        }
    }
}
