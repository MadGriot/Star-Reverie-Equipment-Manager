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
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {

        public Unit Item
        {
            get { return (Unit)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Item.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register(nameof(Item), typeof(Unit), typeof(ItemControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ItemControl itemControl = (ItemControl)d;

            if (itemControl != null )
            {
                Unit item = (Unit)e.NewValue;
                switch (item)
                {
                    case WeaponModel:
                        WeaponModel weapon = (WeaponModel)item;
                        itemControl.nameTextBlock.Text = weapon.Name;
                        itemControl.itemProperty1TextBlock.Text = weapon.WeaponClass.ToString();
                        itemControl.itemProperty2Block.Text = weapon.WeaponType.ToString();
                        break;
                    case ArmorModel:
                        ArmorModel armor = (ArmorModel)item;
                        itemControl.nameTextBlock.Text = armor.Name;
                        itemControl.itemProperty1TextBlock.Text = $"Damage Resistance {armor.DamageResistance}";
                        itemControl.itemProperty2Block.Text = armor.ArmorLocation.ToString();
                        break;
                    case ShieldModel:
                        ShieldModel shield = (ShieldModel)item;
                        itemControl.nameTextBlock.Text = shield.Name;
                        itemControl.itemProperty1TextBlock.Text = $"SP: {shield.MaxSP}";
                        itemControl.itemProperty2Block.Text = $"SP Cost: {shield.SPCost}";
                        break;
                }

            }
        }


        public ItemControl()
        {
            InitializeComponent();
        }
    }
}
