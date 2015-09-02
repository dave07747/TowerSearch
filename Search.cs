using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace TowerSearch
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        string s;

        string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=X:\TowerSearch\TowerSearch\Parts.mdf;Integrated Security=True";

        private void Search_Load(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT PartName FROM Parts", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
                while(reader.Read())
                {
                    myCollection.Add(reader.GetString(0));
                }
                partName.AutoCompleteCustomSource = myCollection;
                con.Close();
            }
        }

        public void findTower()
        {
            SqlCommand cmd = new SqlCommand("spFindTower", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@searchString", partName.Text);

            cmd.Connection.Open();

            if (cmd.ExecuteScalar() == null)
            {
                s = "No part available";
            }
            else
            {
                s += cmd.ExecuteScalar().ToString();
            }
        }

        public void findSide()
        {
            SqlCommand cmd = new SqlCommand("spFindSide", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@searchString", partName.Text);

            cmd.Connection.Open();

            if (cmd.ExecuteScalar() != null)
            {
                s += "\nSide: ";
                s += cmd.ExecuteScalar().ToString();
            }
        }

        public void findX()
        {
            SqlCommand cmd = new SqlCommand("spFindX", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@searchString", partName.Text);

            cmd.Connection.Open();

            if (cmd.ExecuteScalar() != null)
            {
                s += "\nX: ";
                s += cmd.ExecuteScalar().ToString();
            }
        }

        public void findY()
        {
            SqlCommand cmd = new SqlCommand("spFindY", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@searchString", partName.Text);

            cmd.Connection.Open();

            if (cmd.ExecuteScalar() != null)
            {
                s += "\nY: ";
                s += cmd.ExecuteScalar().ToString();
            }
        }

        public void findAmount()
        {
            SqlCommand cmd = new SqlCommand("spFindAmount", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@searchString", partName.Text);

            cmd.Connection.Open();

            if (cmd.ExecuteScalar() != null)
            {
                s += "\nQuantity: ";
                s += cmd.ExecuteScalar().ToString();
            }
        }

        public void findPart()
        {
           
                            SqlCommand cmd = new SqlCommand("spFindPart", new SqlConnection(conString));
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Tower", Tower.Text);
                            cmd.Parameters.AddWithValue("@Side", Side.Text);
                            cmd.Parameters.AddWithValue("@X", xCoordinate.Text);
                            cmd.Parameters.AddWithValue("@Y", yCoordinate.Text);

                            cmd.Connection.Open();

                            if (cmd.ExecuteScalar() != null)
                            {
                                s += cmd.ExecuteScalar().ToString();
                            }
                            else
                            {
                                s = "No part available";
                            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            s = partName.Text + " is located at:\nTower: ";
            if (!string.IsNullOrWhiteSpace(partName.Text))
            {
                findTower();
                findSide();
                findX();
                findY();
                findAmount();
                MessageBox.Show(s);

                this.Close();
            }
            else
            {
                double n;
                if (double.TryParse(Tower.Text, out n))
                {
                    if (double.TryParse(Side.Text, out n))
                    {
                        if (double.TryParse(xCoordinate.Text, out n))
                        {
                            if (double.TryParse(yCoordinate.Text, out n))
                            {
                                s = "The part at:\nTower: " + Tower.Text + "\nSide: " + Side.Text + "\nX: " + xCoordinate.Text + "\nY: " + yCoordinate.Text + "\n\n";
                                findPart();
                                MessageBox.Show(s);
                                this.Close();
                            }

                            else
                            {
                                MessageBox.Show("Error: Please enter number for Y Coordinate!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: Please enter number for X Coordinate!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Please enter number for side!");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Please enter a number for Tower!");
                }
            }

        }

        private void partName_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                button1_Click(sender, e);
            }
        }

        private void Tower_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Side_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void xCoordinate_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void yCoordinate_KeyUp(object sender, KeyEventArgs e)
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
    }
}
