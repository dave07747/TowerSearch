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
    /// Interaction logic for ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Window
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Pass pass = new Pass();
            if (Convert.ToBoolean(!SU.IsChecked))
            {
                if (pass.checkPass(Current.Password))
                {

                    if (New1.Password == New2.Password)
                    {
                        pass.changePassword(New1.Password);
                        this.Close();
                    }
                }
            }
            else if (Convert.ToBoolean(SU.IsChecked))
            {
                MessageBox.Show(SU.IsChecked.ToString());
                if (pass.checkPassMaster(Current.Password))
                {

                    if (New1.Password == New2.Password)
                    {
                        pass.changeSU(New1.Password);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The passwords do not match", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Current password is incorrect", "Try Again");
                }
            }

        }

        }
    }


