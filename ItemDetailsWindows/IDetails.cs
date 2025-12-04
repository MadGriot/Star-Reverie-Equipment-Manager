// -----------------------------------------------------------------------
// 	IDetails.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Star_Reverie_Inventory_Manager.ItemDetailsWindows
{
    public interface IDetails
    {
        void UpdateButton_Click(object sender, RoutedEventArgs e);
        void DeleteButton_Click(object sender, RoutedEventArgs e);
        void ExitButton_Click(object sender, RoutedEventArgs e);
    }
}
