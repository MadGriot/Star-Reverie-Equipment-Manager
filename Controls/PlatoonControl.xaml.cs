// -----------------------------------------------------------------------
// 	PlatoonControl.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager.Controls
{
    /// <summary>
    /// Interaction logic for PlatoonControl.xaml
    /// </summary>
    public partial class PlatoonControl : UserControl
    {


        public PlatoonModel Platoon
        {
            get { return (PlatoonModel)GetValue(PlatoonProperty); }
            set { SetValue(PlatoonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Platoon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlatoonProperty =
            DependencyProperty.Register(nameof(Platoon), typeof(PlatoonModel), typeof(PlatoonControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlatoonControl platoonControl = (PlatoonControl)d;

            if (platoonControl != null)
            {
                PlatoonModel platoon = (PlatoonModel)e.NewValue;

                platoonControl.nameTextBlock.Text = platoon.Name;
                platoonControl.itemProperty1TextBlock.Text = $"PlatoonSquad Count: {platoon?.Squads?.Count}";
                //Add Companies in the future:
                //platoonControl.itemProperty2Block.Text =
            }
        }
        public PlatoonControl()
        {
            InitializeComponent();
        }
    }
}
