// -----------------------------------------------------------------------
// 	InventoryControl.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for InventoryControl.xaml
    /// </summary>
    public partial class InventoryControl : UserControl
    {


        public UnitStack Items
        {
            get { return (UnitStack)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(UnitStack), typeof(InventoryControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            InventoryControl inventoryControl = (InventoryControl)d;

            if (inventoryControl != null)
            {
                UnitStack items = (UnitStack)e.NewValue;
                inventoryControl.nameTextBlock.Text = items.Unit?.Name;
                inventoryControl.itemProperty2Block.Text = $"Quantity: {items.Quantity}";
                inventoryControl.itemProperty1TextBlock.Text = items.Unit switch
                {
                    WeaponModel => "Weapon",
                    ArmorModel => "Armor",
                    ShieldModel => "Shield",
                    _ => "Item"
                };

            }
        }
        public InventoryControl()
        {
            InitializeComponent();
        }
    }
}
