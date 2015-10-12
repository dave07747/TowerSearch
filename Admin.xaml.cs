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
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data.Linq.SqlClient;

namespace TowerSearch
{

    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {

        string conString = ConString.conString;
        static DataClasses1DataContext databaseLogging = new DataClasses1DataContext();
        static Table<Log> listOfPeople = databaseLogging.GetTable<Log>();
        public Admin()
        {
            InitializeComponent();
        }

        // Full Log
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Full_Log().Show();
        }

        // Stats
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new PartsStats().Show();
        }

        // Change MP
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           // databaseLogging = new DataClasses1DataContext(conString);
            int ID = listOfPeople.Max(log => log.Id);

            SqlCommand cmd1 = new SqlCommand("spMP", new SqlConnection(conString));
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@id", ID);
           

            cmd1.Connection.Open();
            var mp = cmd1.ExecuteScalar();
            cmd1.Connection.Close();
            int MP = Convert.ToInt32(mp);
            MP++;

            string day = DateTime.Now.ToString("M/d/yyyy");
            string year = DateTime.Now.ToString("yyyy");
            int year2 = Convert.ToInt32(year) + 1;

            if (MP > 4)
            {
                
                MP = 1;
                Log newPerson = new Log
                {
                   
                    FirstName = "New School Year " + year + " - " + year2.ToString(),
                    LastName = "New School Year " + year + " - " + year2.ToString(),
                    Grade = MP,
                    Quantity = "New School Year " + year + " - " + year2.ToString(),
                    PartName = "New School Year " + year + " - " + year2.ToString(),
                    isOut = 0,
                    Date = Convert.ToDateTime(day),
                    Marking_Period = MP
                };
                //MessageBox.Show(newPerson.FirstName.ToString() + "\n" + newPerson.Grade.ToString());
                listOfPeople.InsertOnSubmit(newPerson);
                databaseLogging.SubmitChanges();
            }
            else
            {
                Log newPerson = new Log
                {
                 
                    FirstName = "New Marking Period " + MP,
                    LastName = "New Marking Period " + MP,
                    Grade = MP,
                    Quantity = "New Marking Period " + MP,
                    PartName = "New Marking Period " + MP,
                    isOut = 0,
                    Date = Convert.ToDateTime(day),
                    Marking_Period = MP
                };
                //MessageBox.Show(newPerson.FirstName.ToString() + "\n" + newPerson.Grade.ToString());
                listOfPeople.InsertOnSubmit(newPerson);
                databaseLogging.SubmitChanges();
            }
            MessageBox.Show("Marking Period set to " + MP);
        }

        // Delete All Log
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new PasswordDeleteLog().Show();
        }

        // Reset Statistics
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new Password_Reset_Stats().Show();
        }

        // Edit Parts
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            new PasswordEditParts().Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            new LogView().Show();
        }
    }
}
