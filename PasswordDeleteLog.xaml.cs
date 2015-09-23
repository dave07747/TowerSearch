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
using System.Data.Linq;

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for PasswordDeleteLog.xaml
    /// </summary>
    public partial class PasswordDeleteLog : Window
    {
        const string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Parts.mdf;Integrated Security=True";
        static DataClasses1DataContext databaseLogging = new DataClasses1DataContext(conString);
         Table<Log> listOfPeople = databaseLogging.GetTable<Log>();

        public PasswordDeleteLog()
        {
            InitializeComponent();
        }

        public void logNewPerson()
        {
            string day = DateTime.Now.ToString("M/d/yyyy");
            string year = DateTime.Now.ToString("yyyy");
            int year2 = Convert.ToInt32(year) + 1;

           
            Log newPerson = new Log
            {
                
                FirstName = "New School Year " + year + " - " + year2.ToString(),
                LastName = "New School Year " + year + " - " + year2.ToString(),
                Grade = 1,
                Quantity = "New School Year " + year + " - " + year2.ToString(),
                PartName = "New School Year " + year + " - " + year2.ToString(),
                isOut = 0,
                Date = Convert.ToDateTime(day),
                Marking_Period = 1
            };
            listOfPeople.InsertOnSubmit(newPerson);
           databaseLogging.SubmitChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pass pass = new Pass();
            if (pass.checkPassMaster(PassWord.Password))
            {
                SqlCommand cmd = new SqlCommand("spDeleteLog", new SqlConnection(conString));
                cmd.Connection.Open();
                cmd.ExecuteScalar();
                cmd.Connection.Close();
                this.Close();
                IEnumerable<Log> delete = (from Log in listOfPeople select Log);

                listOfPeople.DeleteAllOnSubmit(delete);
               // databaseLogging.SubmitChanges();

                logNewPerson();

                MessageBox.Show("Successfully deleted all the contents of Log!");
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }
    }
}
