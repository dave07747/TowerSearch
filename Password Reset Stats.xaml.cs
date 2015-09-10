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
using System.Data;
using System.Data.SqlClient;

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for Password_Reset_Stats.xaml
    /// </summary>
    public partial class Password_Reset_Stats : Window
    {
      
        const string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=X:\TowerSearch\TowerSearch\Parts.mdf;Integrated Security=True";
        public Password_Reset_Stats()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pass pass = new Pass();
            if (pass.checkPass(PassWord.Password))
            {
                SqlCommand cmd = new SqlCommand("spResetStats", new SqlConnection(conString));
                cmd.Connection.Open();
                cmd.ExecuteScalar();
                cmd.Connection.Close();
                this.Close();
                MessageBox.Show("Successfully reset statistics!");
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }
    }
}
