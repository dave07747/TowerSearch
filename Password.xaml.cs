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

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PassWord.Password == "EPaterno666")
            {
                new Admin().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }
    }
}