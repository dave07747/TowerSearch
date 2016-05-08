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
using System.Windows.Shapes;

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for PasswordEditParts.xaml
    /// </summary>
    public partial class PasswordEditParts : Window
    {
        public PasswordEditParts()
        {
            InitializeComponent();
            _edit = new EditParts();
        }

        private bool buttonClose = true;
        private EditParts _edit;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pass pass = new Pass();
           if (pass.checkPass(PassWord.Password) || pass.checkPassMaster(PassWord.Password))
            {
                buttonClose = false;
                if (!buttonClose)
                {
                    _edit.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(buttonClose)
                new Admin().Show();
        }
    }
    }

