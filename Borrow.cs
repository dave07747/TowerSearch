using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data.SqlClient;

namespace TowerSearch
{
    public partial class Borrow : Form
    {
        public Borrow()
        {
            InitializeComponent();
        }

        [Table(Name = "Log")]
        public class log
        {

            [Column(CanBeNull = false)]
            public string FirstName;
            [Column(CanBeNull = false)]
            public string LastName;
            [Column(CanBeNull = false)]
            public int Grade;
            [Column(CanBeNull = false)]
            public string PartName;
            [Column(CanBeNull = false)]
            public int isOut;
            [Column(CanBeNull = false)]
            public string Quantity;
            [Column(CanBeNull = false)]
            public string Date;
            [Column(CanBeNull = false)]
            public int Marking_Period;

        }

        const string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Parts.mdf;Integrated Security=True";
        static DataClasses1DataContext databaseLogging = new DataClasses1DataContext(conString);
        static Table<Log> listOfPeople = databaseLogging.GetTable<Log>();


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("spCheckIfExists", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pName", pName.Text);

            cmd.Connection.Open();

            var check = cmd.ExecuteScalar();

            if (check == null)
            {
                MessageBox.Show("This part does not exist!");
                //this.Close();
            }
            else
            {
                double n;
                if (double.TryParse(Quantity.Text, out n))
                {

                    SqlCommand cmd1 = new SqlCommand("spLogExists", new SqlConnection(conString));
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@pName", pName.Text);
                    cmd1.Parameters.AddWithValue("@fName", fName.Text);
                    cmd1.Parameters.AddWithValue("@lName", lName.Text);
                    cmd1.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));

                    cmd1.Connection.Open();

                    var check2 = cmd1.ExecuteScalar();

                    if (check2 == null)
                    {
                        int ID = listOfPeople.Max(log => log.Id);

                        string day = DateTime.Now.ToString("M/d/yyyy");

                        // int mp = listOfPeople.Max(log => log.Marking_Period);

                        SqlCommand cmd4 = new SqlCommand("spMP", new SqlConnection(conString));
                        cmd4.CommandType = CommandType.StoredProcedure;
                        cmd4.Parameters.AddWithValue("@id", (ID));

                        //  ID += 1;

                        cmd4.Connection.Open();

                        var check1 = cmd4.ExecuteScalar();

                        cmd4.Connection.Close();

                        //MessageBox.Show(check1.ToString());

                        Log newPerson = new Log
                        {

                            FirstName = fName.Text,
                            LastName = lName.Text,
                            Grade = Convert.ToInt32(Grade.Value),
                            Quantity = Quantity.Text,
                            PartName = pName.Text,
                            isOut = 1,
                            Date = Convert.ToDateTime(day),
                            Marking_Period = Convert.ToInt32(check1)
                        };
                        listOfPeople.InsertOnSubmit(newPerson);
                        databaseLogging.SubmitChanges();

                        SqlCommand cmd2 = new SqlCommand("spTakenOutTimes", new SqlConnection(conString));
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@pName", pName.Text);

                        cmd2.Connection.Open();

                        var check3 = Convert.ToInt32(cmd2.ExecuteScalar());

                        check3 += Convert.ToInt32(Quantity.Text);

                        cmd2.Connection.Close();

                        SqlCommand cmd3 = new SqlCommand("spUpdateTakenOut", new SqlConnection(conString));
                        cmd3.CommandType = CommandType.StoredProcedure;
                        cmd3.Parameters.AddWithValue("@pName", pName.Text);
                        cmd3.Parameters.AddWithValue("@Out", check3);

                        cmd3.Connection.Open();

                        var check4 = Convert.ToInt32(cmd3.ExecuteScalar());

                        cmd3.Connection.Close();

                        this.Close();
                    }
                    else
                    {
                        int amount = Convert.ToInt32(Quantity.Text);
                        int amount2 = Convert.ToInt32(check2);
                        amount += amount2;

                        SqlCommand cmd2 = new SqlCommand("returnSome", new SqlConnection(conString));
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@pName", pName.Text);
                        cmd2.Parameters.AddWithValue("@fName", fName.Text);
                        cmd2.Parameters.AddWithValue("@lName", lName.Text);
                        cmd2.Parameters.AddWithValue("@Quantity", amount);
                        cmd2.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));


                        cmd2.Connection.Open();

                        cmd2.ExecuteScalar();
                        cmd2.Connection.Close();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Quantity is not a number!");
                }
            }
        }

        private void fName_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void lName_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Grade_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void pName_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Quantity_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                button1_Click(sender, e);
            }
        }

        private void pName_Enter(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT PartName FROM Parts", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    myCollection.Add(reader.GetString(0));
                }
                pName.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        private void fName_Enter(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT FirstName FROM Log WHERE Grade = @grade", con);
                cmd.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    myCollection.Add(reader.GetString(0));
                }
                fName.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        private void lName_Enter(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT LastName FROM Log WHERE FirstName = @fName AND Grade = @grade0", con);
                cmd.Parameters.AddWithValue("@fName", fName.Text);
                cmd.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    myCollection.Add(reader.GetString(0));
                }
                lName.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }
    }
}
