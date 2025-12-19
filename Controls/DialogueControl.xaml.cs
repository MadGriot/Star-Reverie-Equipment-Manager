// -----------------------------------------------------------------------
// 	DialogueControl.xaml.cs
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
    /// Interaction logic for DialogueControl.xaml
    /// </summary>
    public partial class DialogueControl : UserControl
    {


        public DialogueNode Dialogue
        {
            get { return (DialogueNode)GetValue(DialogueProperty); }
            set { SetValue(DialogueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Dialogue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogueProperty =
            DependencyProperty.Register(nameof(Dialogue), typeof(DialogueNode), typeof(DialogueControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DialogueControl dialogueControl = (DialogueControl)d;

            if (dialogueControl != null)
            {
                DialogueNode dialogueNode = (DialogueNode)e.NewValue;
                dialogueControl.nameTextBlock.Text = dialogueNode.Character.FirstName;
                dialogueControl.itemProperty1TextBlock.Text = dialogueNode.Text;
                dialogueControl.itemProperty2Block.Text = dialogueNode?.NextNode?.Text ?? "None";
            }
        }

        public DialogueControl()
        {
            InitializeComponent();
        }
    }
}
