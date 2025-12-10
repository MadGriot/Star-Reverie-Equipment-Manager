// -----------------------------------------------------------------------
// 	SquadControl.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using StarReverieCore.Models;

namespace Star_Reverie_Inventory_Manager.Controls
{
    /// <summary>
    /// Interaction logic for SquadControl.xaml
    /// </summary>
    public partial class SquadControl : UserControl
    {


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
            ItemControl itemControl = (ItemControl)d;

            if (itemControl != null )
            {
                SquadModel squad = (SquadModel)e.NewValue;

                itemControl.nameTextBlock.Text = squad.Name;
                itemControl.itemProperty1TextBlock.Text = $"Member Count: {squad?.Characters?.Count}";
                // Enter platoon in the future
                //itemControl.itemProperty2Block.Text = 
            }
        }
        public SquadControl()
        {
            InitializeComponent();
        }
    }
}
