using System;
using System.Collections.Generic;
using System.Data.Linq;
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
using System.Data.Linq.Mapping;


namespace TowerSearch
{
    
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Borrow : Window
    {
        public Borrow()
        {
            InitializeComponent();
        }

        [Table(Name="Log")]
        public class log
        {
            [Column(Name = "Id", IsPrimaryKey = true, CanBeNull = false)]
            public int Id;
            [Column(CanBeNull = false)]
            public string FirstName;
            [Column(CanBeNull         = false)]
            public string LastName;
            [Column(CanBeNull = false)]
            public string Grade;
            [Column(CanBeNull = false)]
            public string PartName;
            [Column(CanBeNull = false)]
            public int isOut;
            [Column(CanBeNull = false)]
            public string Quantity;
        }

        const string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=X:\TowerSearch\TowerSearch\Parts.mdf;Integrated Security=True";
         static DataClasses1DataContext databaseLogging = new DataClasses1DataContext(connection);
        static Table<Log> listOfPeople = databaseLogging.GetTable<Log>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fName = firstName.Text;
            string lName = lastName.Text;
            string grade = gradee.Text;
            string part = partName.Text;
            string quantity = amount.Text;
            int id = listOfPeople.Max(log => log.Id) + 1;
            

            Log newPerson = new Log
            {
                Id = id,
                FirstName = fName,
                LastName = lName,
                Grade = grade,
                Quantity = quantity,
                PartName = part,
                isOut = 1
        };
            listOfPeople.InsertOnSubmit(newPerson);
            databaseLogging.SubmitChanges();

            this.Close();
        }
    }
}
