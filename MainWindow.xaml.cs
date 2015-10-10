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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* string xCoordinate;
         string yCoordinate;
         string tower;
         string side;
         string partNameforSearch;
         string quantity;
         */

        static int firstOpen = 0;
        public MainWindow()
        {
            InitializeComponent();
            // this.WindowState = WindowState.Maximized;

        }



        //Search
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Search().Show();
            this.Hide();
        }

        //View Logs
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new LogView().Show();
        }

        //Borrow
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Borrow().Show();
            this.Hide();
        }

        //Return
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new Return().Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Directory.Exists("C:\\TowerSearch"))
            {
                Directory.CreateDirectory("C:\\TowerSearch");
            }
            try
            {
                //const string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Parts.mdf;Integrated Security=True";
                // string conString = @"Data Source=DAVIDS_LAPTOP;Initial Catalog=X:\PARTS.MDF;Integrated Security=True";
                string conString = ConString.conString;
                string backupDir = @"C:\TowerSearch";

                BackupService backup = new BackupService(conString, backupDir);
                backup.BackupAllUserDatabases();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (firstOpen == 0)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConString.conString);
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Successfully connected to server!");

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a uh-oh:\t\t\t :(\n\n\n\n\n" + ex);
                    MessageBox.Show(ex.InnerException.ToString());
                    MessageBox.Show(ex.StackTrace);
                    this.Close();
                }
                firstOpen++;
            }
        }


    }
}
