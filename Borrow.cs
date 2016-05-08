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
        private Multiple_Parts form2;

        private string[] quantityArray = Multiple_Parts.quantityArray;
        private string[] partArray = Multiple_Parts.partArray;
        private SqlCommand cmd;
        private int arrayCounter;

        public Borrow()
        {
            InitializeComponent();
            Grade.Value = keepGrade;
            form2 = new Multiple_Parts(this);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBoxMultiple.Checked)
            {
                Console.WriteLine("In checked");
                arrayCounter = 0;
                foreach (var part in partArray)
                {
                    if (string.IsNullOrWhiteSpace(partArray[arrayCounter]))
                        break;

                    cmd = new SqlCommand("spFindAmount", new SqlConnection(conString))
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@searchString", part);
                    cmd.Connection.Open();
                    var pAmount = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                    var borrowAmount = Convert.ToInt32(pAmount) - Convert.ToInt32(quantityArray[arrayCounter]);
                    // MessageBox.Show(borrowAmount.ToString());

                    if (borrowAmount >= 0 )//|| !string.IsNullOrWhiteSpace(quantityArray[arrayCounter]))
                    {
                        cmd = new SqlCommand("spLogExists", new SqlConnection(conString))
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@pName", part);
                        cmd.Parameters.AddWithValue("@fName", fName.Text);
                        cmd.Parameters.AddWithValue("@lName", lName.Text);
                        cmd.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));

                        cmd.Connection.Open();

                        var check2 = cmd.ExecuteScalar();

                        if (check2 == null)
                        {
                            var ID = listOfPeople.Max(log => log.Id);

                            var day = DateTime.Now.ToString("M/d/yyyy");

                            // int mp = listOfPeople.Max(log => log.Marking_Period);

                            cmd = new SqlCommand("spMP", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("@id", ID);

                            //  ID += 1;

                            cmd.Connection.Open();

                            var check1 = cmd.ExecuteScalar();

                            cmd.Connection.Close();

                            //MessageBox.Show(check1.ToString());

                            var newPerson = new Log
                            {
                                FirstName = fName.Text,
                                LastName = lName.Text,
                                Grade = Convert.ToInt32(Grade.Value),
                                Quantity = quantityArray[arrayCounter],
                                PartName = part,
                                isOut = 1,
                                Date = Convert.ToDateTime(day),
                                Marking_Period = Convert.ToInt32(check1)
                            };
                            listOfPeople.InsertOnSubmit(newPerson);
                            databaseLogging.SubmitChanges();

                            cmd = new SqlCommand("spTakenOutTimes", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("@pName", part);

                            cmd.Connection.Open();

                            var check3 = Convert.ToInt32(cmd.ExecuteScalar());

                            check3 += Convert.ToInt32(quantityArray[arrayCounter]);

                            cmd.Connection.Close();

                            cmd = new SqlCommand("spUpdateTakenOut", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("@pName", part);
                            cmd.Parameters.AddWithValue("@Out", check3);

                            cmd.Connection.Open();

                            var check4 = Convert.ToInt32(cmd.ExecuteScalar());

                            cmd.Connection.Close();

                            // MessageBox.Show(borrowAmount.ToString());
                            cmd = new SqlCommand("spBorrow", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("@pName", part);
                            cmd.Parameters.AddWithValue("@quantity", borrowAmount);

                            cmd.Connection.Open();
                            cmd.ExecuteScalar();
                            cmd.Connection.Close();

                            

                        }
                        else
                        {
                            var amount = Convert.ToInt32(quantityArray[arrayCounter]);
                            var amount2 = Convert.ToInt32(check2);
                            amount += amount2;

                            cmd = new SqlCommand("returnSome", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("@pName", part);
                            cmd.Parameters.AddWithValue("@fName", fName.Text);
                            cmd.Parameters.AddWithValue("@lName", lName.Text);
                            cmd.Parameters.AddWithValue("@Quantity", amount);
                            cmd.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));


                            cmd.Connection.Open();

                            cmd.ExecuteScalar();
                            cmd.Connection.Close();


                            cmd = new SqlCommand("spBorrow", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("@pName", part);
                            cmd.Parameters.AddWithValue("@quantity", borrowAmount);

                            cmd.Connection.Open();
                            cmd.ExecuteScalar();
                            cmd.Connection.Close();

                           
                            //  
                        }
                    }
                    else 
                    {
                        MessageBox.Show("There are not enough parts to borrow " + quantityArray[arrayCounter] + " of " +
                                        part);
                    }
                    arrayCounter++;
                }
                Close();
            }


            else
            {
                Console.WriteLine("In unchecked");
                cmd = new SqlCommand("spCheckIfExists", new SqlConnection(conString));
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
                        cmd = new SqlCommand("spFindAmount", new SqlConnection(conString))
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@searchString", pName.Text);
                        cmd.Connection.Open();
                        var pAmount = cmd.ExecuteScalar();
                        cmd.Connection.Close();
                        var borrowAmount = Convert.ToInt32(pAmount) - Convert.ToInt32(Quantity.Text);
                        // MessageBox.Show(borrowAmount.ToString());

                        if (borrowAmount >= 0)
                        {
                            cmd = new SqlCommand("spLogExists", new SqlConnection(conString))
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("@pName", pName.Text);
                            cmd.Parameters.AddWithValue("@fName", fName.Text);
                            cmd.Parameters.AddWithValue("@lName", lName.Text);
                            cmd.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));

                            cmd.Connection.Open();

                            var check2 = cmd.ExecuteScalar();

                            if (check2 == null)
                            {
                                var ID = listOfPeople.Max(log => log.Id);

                                var day = DateTime.Now.ToString("M/d/yyyy");

                                // int mp = listOfPeople.Max(log => log.Marking_Period);

                                cmd = new SqlCommand("spMP", new SqlConnection(conString))
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                cmd.Parameters.AddWithValue("@id", ID);

                                //  ID += 1;

                                cmd.Connection.Open();

                                var check1 = cmd.ExecuteScalar();

                                cmd.Connection.Close();

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

                                cmd = new SqlCommand("spTakenOutTimes", new SqlConnection(conString))
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                cmd.Parameters.AddWithValue("@pName", pName.Text);

                                cmd.Connection.Open();

                                var check3 = Convert.ToInt32(cmd.ExecuteScalar());

                                check3 += Convert.ToInt32(Quantity.Text);

                                cmd.Connection.Close();

                                cmd = new SqlCommand("spUpdateTakenOut", new SqlConnection(conString))
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                cmd.Parameters.AddWithValue("@pName", pName.Text);
                                cmd.Parameters.AddWithValue("@Out", check3);

                                cmd.Connection.Open();

                                var check4 = Convert.ToInt32(cmd.ExecuteScalar());

                                cmd.Connection.Close();

                                // MessageBox.Show(borrowAmount.ToString());
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

                            }
                            else
                            {
                                var amount = Convert.ToInt32(Quantity.Text);
                                var amount2 = Convert.ToInt32(check2);
                                amount += amount2;

                                cmd = new SqlCommand("returnSome", new SqlConnection(conString))
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                cmd.Parameters.AddWithValue("@pName", pName.Text);
                                cmd.Parameters.AddWithValue("@fName", fName.Text);
                                cmd.Parameters.AddWithValue("@lName", lName.Text);
                                cmd.Parameters.AddWithValue("@Quantity", amount);
                                cmd.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Value));


                                cmd.Connection.Open();

                                cmd.ExecuteScalar();
                                cmd.Connection.Close();


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
                                //  
                            }
                        }
                        else
                        {
                            MessageBox.Show("There are not enough parts to borrow " + Quantity.Text + " of " +
                                            pName.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantity is not a valid number!");
                    }
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
                cmd = new SqlCommand("SELECT PartName FROM Parts", con);
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
                cmd = new SqlCommand("SELECT FirstName FROM Log WHERE Grade = @grade", con);
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
                cmd = new SqlCommand("SELECT LastName FROM Log WHERE FirstName = @fName AND Grade = @grade", con);
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

        public void clearMultipleCheck()
        {
            checkBoxMultiple.Checked = false;
        }
        public void setMultipleCheck()
        {
            checkBoxMultiple.Checked = true;
            
        }

        public void setMultipleText()
        {
            pName.Text = "multiple";
            Quantity.Text = "multiple";
        }

        private void checkBoxMultiple_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxMultiple.Checked) return;
            if (form2 == null)
            {
                form2 = new Multiple_Parts(this);
                form2.Show();
                Console.WriteLine("Multiple Parts is null");
            }
            else
                form2.Show();
           
            Console.WriteLine("Opening multiple parts form");
        }

     
    }
}