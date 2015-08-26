﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TowerSearch
{
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }

        string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=X:\TowerSearch\TowerSearch\Parts.mdf;Integrated Security=True";


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("spCompare", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Part", pName.Text);
            cmd.Parameters.AddWithValue("@fName", fName.Text);
            cmd.Parameters.AddWithValue("@lName", lName.Text);

            cmd.Connection.Open();

            var check = cmd.ExecuteScalar();


            if (check == null)
            {
                string s = "Error: Could not return part\n\n-Mesage: Never taken out";
                MessageBox.Show(s);
            }
            else if (cmd.ExecuteScalar().ToString() == "0")
            {
                MessageBox.Show("You have nothing to return!");
                SqlCommand cmd1 = new SqlCommand("return", new SqlConnection(conString));
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@pName", pName.Text);
                cmd1.Parameters.AddWithValue("@fName", fName.Text);
                cmd1.Parameters.AddWithValue("@lName", lName.Text);

                cmd1.Connection.Open();

                cmd1.ExecuteScalar();

                cmd1.Connection.Close();
            }
            else
            {
                
                if (Quantity.Text == check.ToString())
                {
                    //MessageBox.Show("1");
                    SqlCommand cmd1 = new SqlCommand("return", new SqlConnection(conString));
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@pName", pName.Text);
                    cmd1.Parameters.AddWithValue("@fName", fName.Text);
                    cmd1.Parameters.AddWithValue("@lName", lName.Text);

                    cmd1.Connection.Open();

                    cmd1.ExecuteScalar();

                    cmd1.Connection.Close();
                }
                else
                {
                    int amountToReturn = Convert.ToInt32(Quantity.Text);
                    int alreadyTakenOut = Convert.ToInt32(check);
                   //check = check.ToString();
                    if (amountToReturn < alreadyTakenOut)
                    {
                        int total = alreadyTakenOut - amountToReturn;

                        SqlCommand cmd1 = new SqlCommand("returnSome", new SqlConnection(conString));
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@pName", pName.Text);
                        cmd1.Parameters.AddWithValue("@fName", fName.Text);
                        cmd1.Parameters.AddWithValue("@lName", lName.Text);
                        cmd1.Parameters.AddWithValue("quantity", total.ToString());

                        cmd1.Connection.Open();

                        cmd1.ExecuteScalar();

                        cmd1.Connection.Close();

                        MessageBox.Show("Successfully returned " + Quantity.Text + "items!\n\n" + total.ToString() + " still borrowed.");
                    }
                    else
                    {
                        MessageBox.Show("You cannot return more than you borrowed!");
                    }
                }
            }
            cmd.Connection.Close();

            this.Close();
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

        private void pName_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
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

        private void fName_Enter(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT FirstName FROM Log WHERE isOut = 1", con);
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
                SqlCommand cmd = new SqlCommand("SELECT LastName FROM Log WHERE FirstName = @firstName AND isOut = 1", con);
                cmd.Parameters.AddWithValue("@firstName", fName.Text);
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

        private void pName_Enter(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT PartName FROM Log WHERE FirstName = @firstName AND LastName = @lastName AND isOut = 1", con);
                cmd.Parameters.AddWithValue("@firstName", fName.Text);
                cmd.Parameters.AddWithValue("@lastName", lName.Text);
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
    }
}