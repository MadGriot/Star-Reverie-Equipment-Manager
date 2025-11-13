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

        private Unit item;

        public Unit Item
        {
            get { return item; }
            set
            {
                item = value;
                switch (item)
                {
                    case WeaponModel:
                        WeaponModel weapon = (WeaponModel)item;
                        nameTextBlock.Text = weapon.Name;
                        itemProperty1TextBlock.Text = weapon.WeaponClass.ToString();
                        itemProperty2Block.Text = weapon.WeaponType.ToString();
                        break;
                    case ArmorModel:
                        ArmorModel armor = (ArmorModel)item;
                        nameTextBlock.Text = armor.Name;
                        itemProperty1TextBlock.Text = $"Damage Resistance {armor.DamageResistance}";
                        itemProperty2Block.Text = armor.ArmorLocation.ToString();
                        break;
                    case ShieldModel:
                        ShieldModel shield = (ShieldModel)item;
                        nameTextBlock.Text = shield.Name;
                        itemProperty1TextBlock.Text = $"SP: {shield.MaxSP}";
                        itemProperty2Block.Text = $"SP Cost: {shield.SPCost}";
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
