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
            Pass pass = new Pass();
            if (pass.checkPass(PassWord.Password) || pass.checkPassMaster(PassWord.Password))
            {
                try
                {
                    new Admin().Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ChangePass().Show();
        }
    }
}
