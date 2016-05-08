using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerSearch
{
    public partial class Multiple_Parts : Form
    {
        private Borrow borrow;
        public Multiple_Parts(Borrow ParentForm)
        {
            InitializeComponent();
            borrow = ParentForm;
            borrow.clearMultipleCheck();
            
        }
        private const string conString = ConString.conString;
        private bool buttonClickClose = false;
        private static bool firstCopy = true;
        public static string[] partArray = new string[6];
        public static string[] quantityArray = new string[6];
        private static Multiple_Parts form2;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; ++i)
            {
                partArray[i] = "";
                quantityArray[i] = "";
            }

            var cmd = new SqlCommand("spCheckIfExists", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pName", textBox1.Text);

            cmd.Connection.Open();

            var check = cmd.ExecuteScalar();

            double n;
            if (double.TryParse(quantity1.Text, out n) && n >= 0 || string.IsNullOrWhiteSpace(quantity1.Text))
            {
                if (double.TryParse(quantity2.Text, out n) && n >= 0 || string.IsNullOrWhiteSpace(quantity2.Text))
                {
                    if (double.TryParse(quantity3.Text, out n) && n >= 0 || string.IsNullOrWhiteSpace(quantity3.Text))
                    {
                        if (double.TryParse(quantity4.Text, out n) && n >= 0 || string.IsNullOrWhiteSpace(quantity4.Text))
                        {
                            if (double.TryParse(quantity5.Text, out n) && n >= 0 || string.IsNullOrWhiteSpace(quantity5.Text))
                            {
                                if (double.TryParse(quantity6.Text, out n) && n >= 0 || string.IsNullOrWhiteSpace(quantity6.Text))
                                {

                                    if (check == null && !string.IsNullOrWhiteSpace(textBox1.Text))
                                    {
                                        MessageBox.Show(textBox1.Text + @" does not exist!");
                                        //this.Close();
                                        Console.WriteLine("textbox1 blank");
                                    }
                                    else
                                    {
                                        cmd = new SqlCommand("spCheckIfExists", new SqlConnection(conString));
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@pName", textBox2.Text);

                                        cmd.Connection.Open();

                                        check = cmd.ExecuteScalar();

                                        if (check == null && !string.IsNullOrWhiteSpace(textBox2.Text))
                                        {
                                            MessageBox.Show(textBox2.Text + @" does not exist!");
                                            //this.Close();
                                            Console.WriteLine("textbox2 blank");
                                        }
                                        else
                                        {
                                            cmd = new SqlCommand("spCheckIfExists", new SqlConnection(conString));
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@pName", textBox3.Text);

                                            cmd.Connection.Open();

                                            check = cmd.ExecuteScalar();

                                            if (check == null && !string.IsNullOrWhiteSpace(textBox3.Text))
                                            {
                                                MessageBox.Show(textBox3.Text + @" does not exist!");
                                                //this.Close();
                                                Console.WriteLine("textbox3 blank");
                                            }
                                            else
                                            {
                                                cmd = new SqlCommand("spCheckIfExists", new SqlConnection(conString));
                                                cmd.CommandType = CommandType.StoredProcedure;
                                                cmd.Parameters.AddWithValue("@pName", textBox4.Text);

                                                cmd.Connection.Open();

                                                check = cmd.ExecuteScalar();

                                                if (check == null && !string.IsNullOrWhiteSpace(textBox4.Text))
                                                {
                                                    MessageBox.Show(textBox4.Text + @" does not exist!");
                                                    //this.Close();
                                                    Console.WriteLine("textbox4 blank");
                                                }
                                                else
                                                {
                                                    cmd = new SqlCommand("spCheckIfExists", new SqlConnection(conString));
                                                    cmd.CommandType = CommandType.StoredProcedure;
                                                    cmd.Parameters.AddWithValue("@pName", textBox5.Text);

                                                    cmd.Connection.Open();

                                                    check = cmd.ExecuteScalar();

                                                    if (check == null && !string.IsNullOrWhiteSpace(textBox5.Text))
                                                    {
                                                        MessageBox.Show(textBox5.Text + @" does not exist!");
                                                        //this.Close();
                                                        Console.WriteLine("textbox5 blank");
                                                    }
                                                    else
                                                    {
                                                        cmd = new SqlCommand("spCheckIfExists",
                                                            new SqlConnection(conString));
                                                        cmd.CommandType = CommandType.StoredProcedure;
                                                        cmd.Parameters.AddWithValue("@pName", textBox6.Text);

                                                        cmd.Connection.Open();

                                                        check = cmd.ExecuteScalar();

                                                        if (check == null && !string.IsNullOrWhiteSpace(textBox6.Text))
                                                        {
                                                            MessageBox.Show(textBox6.Text + @" does not exist!");
                                                            //this.Close();
                                                            Console.WriteLine("textbox6 blank");
                                                        }
                                                        else
                                                        {



                                                            partArray[0] = textBox1.Text;
                                                            partArray[1] = textBox2.Text;
                                                            partArray[2] = textBox3.Text;
                                                            partArray[3] = textBox4.Text;
                                                            partArray[4] = textBox5.Text;
                                                            partArray[5] = textBox6.Text;

                                                            quantityArray[0] = quantity1.Text;
                                                            quantityArray[1] = quantity2.Text;
                                                            quantityArray[2] = quantity3.Text;
                                                            quantityArray[3] = quantity4.Text;
                                                            quantityArray[4] = quantity5.Text;
                                                            quantityArray[5] = quantity6.Text;
                                                            borrow.setMultipleCheck();
                                                            borrow.setMultipleText();
                                                            
                                                            Hide();

                                                            firstCopy = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please enter a valid quantity!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid quantity!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid quantity!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid quantity!");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity!");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
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
                textBox1.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
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
                textBox2.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
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
                textBox3.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
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
                textBox4.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
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
                textBox5.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
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
                textBox6.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        private void Multiple_Parts_Shown(object sender, EventArgs e)
        {
            if (!firstCopy)
            {
                Hide();
                Console.WriteLine("Closing");
            }
            firstCopy = false;
        }

        private void Multiple_Parts_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            firstCopy = true;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
           
        }

        private void quantity1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
           
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
        
        }

        private void quantity2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
        
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            
        }

        private void quantity3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            
        }

        private void quantity4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
           
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            
        }

        private void quantity5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
           
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            
        }

        private void quantity6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            
        }

        private void Multiple_Parts_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            borrow.clearMultipleCheck();
            firstCopy = true;
            e.Cancel = true;
            Hide();

        }
    }
}
