// -----------------------------------------------------------------------
// 	App.xaml.cs
// 	Author: Trenton Scott 
// 	Copyright (c) Centuras. All rights reserved.
//  -----------------------------------------------------------------------

using StarReverieCore;
using System.Windows;

namespace Star_Reverie_Inventory_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static StarReverieDbContext StarReverieDbContext = new StarReverieDbContext();
    }

}
