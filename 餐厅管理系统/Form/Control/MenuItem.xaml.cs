﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Form.Control
{
    /// <summary>
    /// MenuItem.xaml 的交互逻辑
    /// </summary>
    public partial class MenuItem : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsSelect { get; set; } = false;
        public string Text { get; set; }
        public Action Click { get; set; }
        public MenuItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Click();
            this.IsSelect = true;
        }
    }
}
