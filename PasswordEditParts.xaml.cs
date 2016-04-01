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
        }

        bool buttonClose = true;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pass pass = new Pass();
           if (pass.checkPass(PassWord.Password) || pass.checkPassMaster(PassWord.Password))
            {
                if (!buttonClose)
                {
                    new EditParts().Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new Admin().Show();
        }
    }
    }

