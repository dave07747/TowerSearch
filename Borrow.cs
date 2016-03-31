using System;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace TowerSearch
{
    public partial class Borrow : Form
    {
        private const string conString = ConString.conString;

        private static int keepGrade = 9;
        private static readonly DataClasses1DataContext databaseLogging = new DataClasses1DataContext(conString);
        private static readonly Table<Log> listOfPeople = databaseLogging.GetTable<Log>();

        public Borrow()
        {
            InitializeComponent();
            Grade.Value = keepGrade;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var cmd = new SqlCommand("spCheckIfExists", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pName", pName.Text);

            cmd.Connection.Open();

            var check = cmd.ExecuteScalar();

            if (check == null)
            {
                MessageBox.Show(@"This part does not exist!");
                //this.Close();
            }
            else
            {
                double n;
                if (double.TryParse(Quantity.Text, out n) && n > 0)
                {
                    var cmd1 = new SqlCommand("spFindAmount", new SqlConnection(conString))
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd1.Parameters.AddWithValue("@searchString", pName.Text);
                    cmd1.Connection.Open();
                    var pAmount = cmd1.ExecuteScalar();
                    cmd1.Connection.Close();
                    var borrowAmount = Convert.ToInt32(pAmount) - Convert.ToInt32(Quantity.Text);
                    MessageBox.Show(borrowAmount.ToString());

                    if (borrowAmount >= 0)
                    {
                        cmd1 = new SqlCommand("spLogExists", new SqlConnection(conString))
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd1.Parameters.AddWithValue("@pName", pName.Text);
                        cmd1.Parameters.AddWithValue("@fName", fName.Text);
                        cmd1.Parameters.AddWithValue("@lName", lName.Text);
                        cmd1.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));

                        cmd1.Connection.Open();

                        var check2 = cmd1.ExecuteScalar();

                        if (check2 == null)
                        {
                            var ID = listOfPeople.Max(log => log.Id);

                            var day = DateTime.Now.ToString("M/d/yyyy");

                            // int mp = listOfPeople.Max(log => log.Marking_Period);

                            var cmd4 = new SqlCommand("spMP", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd4.Parameters.AddWithValue("@id", ID);

                            //  ID += 1;

                            cmd4.Connection.Open();

                            var check1 = cmd4.ExecuteScalar();

                            cmd4.Connection.Close();

                            //MessageBox.Show(check1.ToString());

                            var newPerson = new Log
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

                            var cmd2 = new SqlCommand("spTakenOutTimes", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd2.Parameters.AddWithValue("@pName", pName.Text);

                            cmd2.Connection.Open();

                            var check3 = Convert.ToInt32(cmd2.ExecuteScalar());

                            check3 += Convert.ToInt32(Quantity.Text);

                            cmd2.Connection.Close();

                            var cmd3 = new SqlCommand("spUpdateTakenOut", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd3.Parameters.AddWithValue("@pName", pName.Text);
                            cmd3.Parameters.AddWithValue("@Out", check3);

                            cmd3.Connection.Open();

                            var check4 = Convert.ToInt32(cmd3.ExecuteScalar());

                            cmd3.Connection.Close();
                            
                            // MessageBox.Show(borrowAmount.ToString());
                            var cmd6 = new SqlCommand("spBorrow", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd6.Parameters.AddWithValue("@pName", pName.Text);
                            cmd6.Parameters.AddWithValue("@quantity", borrowAmount);

                            cmd6.Connection.Open();
                            cmd6.ExecuteScalar();
                            cmd6.Connection.Close();
                            
                            Close();
                            new MainWindow().Show();
                        }
                        else
                        {
                            var amount = Convert.ToInt32(Quantity.Text);
                            var amount2 = Convert.ToInt32(check2);
                            amount += amount2;

                            var cmd2 = new SqlCommand("returnSome", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd2.Parameters.AddWithValue("@pName", pName.Text);
                            cmd2.Parameters.AddWithValue("@fName", fName.Text);
                            cmd2.Parameters.AddWithValue("@lName", lName.Text);
                            cmd2.Parameters.AddWithValue("@Quantity", amount);
                            cmd2.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));


                            cmd2.Connection.Open();

                            cmd2.ExecuteScalar();
                            cmd2.Connection.Close();


                            cmd = new SqlCommand("spBorrow", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("@pName", pName.Text);
                            cmd.Parameters.AddWithValue("@quantity", borrowAmount);

                            cmd.Connection.Open();
                            cmd.ExecuteScalar();
                            cmd.Connection.Close();

                            Close();
                            //  new MainWindow().Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("There are not enough parts to borrow " + Quantity.Text + " of " + pName.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Quantity is not a valid number!");
                }
            }
        }

        private void fName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control) sender, true, true, true, true);
            }
        }

        private void lName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control) sender, true, true, true, true);
            }
        }

        private void Grade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control) sender, true, true, true, true);
            }
        }

        private void pName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control) sender, true, true, true, true);
            }
        }

        private void Quantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control) sender, true, true, true, true);
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
            using (var con = new SqlConnection(conString))
            {
                var cmd = new SqlCommand("SELECT PartName FROM Parts", con);
                con.Open();
                var reader = cmd.ExecuteReader();
                var myCollection = new AutoCompleteStringCollection();
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
            using (var con = new SqlConnection(conString))
            {
                var cmd = new SqlCommand("SELECT FirstName FROM Log WHERE Grade = @grade", con);
                cmd.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));
                con.Open();
                var reader = cmd.ExecuteReader();
                var myCollection = new AutoCompleteStringCollection();
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
            using (var con = new SqlConnection(conString))
            {
                var cmd = new SqlCommand("SELECT LastName FROM Log WHERE FirstName = @fName AND Grade = @grade", con);
                cmd.Parameters.AddWithValue("@fName", fName.Text);
                cmd.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));
                con.Open();
                var reader = cmd.ExecuteReader();
                var myCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    myCollection.Add(reader.GetString(0));
                }
                lName.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        private void Borrow_FormClosed(object sender, FormClosedEventArgs e)
        {
            new MainWindow().Show();
        }

        private void Grade_ValueChanged(object sender, EventArgs e)
        {
            keepGrade = Convert.ToInt32(Grade.Value);
        }

        [Table(Name = "Log")]
        public class log
        {
            [Column(CanBeNull = false)] public string Date;

            [Column(CanBeNull = false)] public string FirstName;

            [Column(CanBeNull = false)] public int Grade;

            [Column(CanBeNull = false)] public int isOut;

            [Column(CanBeNull = false)] public string LastName;

            [Column(CanBeNull = false)] public int Marking_Period;

            [Column(CanBeNull = false)] public string PartName;

            [Column(CanBeNull = false)] public string Quantity;
        }
    }
}