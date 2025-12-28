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
        public SquadModel PlatoonSquad
        {
            get { return (SquadModel)GetValue(PlatoonSquadProperty); }
            set { SetValue(PlatoonSquadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlatoonSquad.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlatoonSquadProperty =
            DependencyProperty.Register(nameof(PlatoonSquad), typeof(SquadModel), typeof(PlatoonSquadsControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlatoonSquadsControl platoonSquadsControl = (PlatoonSquadsControl)d;

            if (platoonSquadsControl != null)
            {
                SquadModel squad = (SquadModel)e.NewValue;

                platoonSquadsControl.squadNameTextBlock.Text = squad.Name;
            }
        }

        private void DeleteSquadButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteRequested?.Invoke(this, PlatoonSquad);
        }
        public PlatoonSquadsControl()
        {
            InitializeComponent();
        }
    }
}
