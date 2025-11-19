// -----------------------------------------------------------------------
// 	InputValidator.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Star_Reverie_Inventory_Manager
{
    public static class InputValidator
    {
        public static bool TryParseInt(TextBox textBox, string fieldName, out int value)
        {
            if (!int.TryParse(textBox.Text, out value))
            {
                MessageBox.Show($"{fieldName} must be a valid whole number.", "Ivalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool TryParseDecimal(TextBox textBox, string fieldName, out decimal value)
        {
            if (!decimal.TryParse(textBox.Text, out value))
            {
                MessageBox.Show($"{fieldName} must be a valid decimal number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBox.Focus();
                return false;

            }
            return true;
        }
    }
}
