﻿using System;
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
using System.Windows.Shapes;
using TestLaserwar.UserControls;

namespace TestLaserwar.Windows.Subdivision
{
    /// <summary>
    /// Interaction logic for SubdivisionLeafWindow.xaml
    /// </summary>
    public partial class SubdivisionLeafWindow : Window
    {
        public SubdivisionLeafWindow()
        {
            InitializeComponent();
            this.Content = new SubdivisionLeafUserControl();
        }
    }
}