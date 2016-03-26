using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TowerSearch
{
    public partial class LogView : Form
    {

        int buttonClickClose = 0;

        //string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Parts.mdf;Integrated Security=True";
      
        string conString = ConString.conString;

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
     

        public LogView()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            showData();


            /* using (DataClasses1DataContext databaseLogs = new DataClasses1DataContext())
             {
                 dataGridView1.DataSource = databaseLogs.PartsOuts.Where(w => w.isOut == 1).Select(s => new {Date = s.Date ,Quantity = s.Quantity.ToString(), Grade = s.Grade.ToString(), LastName = s.LastName, PartName = s.PartName, FirstName = s.FirstName }).ToList();
             }*/
        }

        private void showData()
        {
            
          /*  DataSet DS = new DataSet();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM PartsOut", con);
            DA.Fill(DS, "PartsOut");
            dataGridView1.DataSource = DS.Tables["PartsOut"];
            con.Close();*/

            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM PartsOut", con);


            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void LogView_Load(object sender, EventArgs e)
        {
            showData();
            //this.dataGridView1.Sort(this.gradeDataGridViewTextBoxColumn, ListSortDirection.Ascending);
           // this.dataGridView1.Sort(this.firstNameDataGridViewTextBoxColumn, ListSortDirection.Ascending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Password().Show();
            buttonClickClose++;
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new SqlCommandBuilder(sda);
                sda.Update(dt);

                MessageBox.Show("Saved");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            showData();
        }

        private void LogView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (buttonClickClose == 0)
            {
                new MainWindow().Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM PartsOut WHERE Grade = 9", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM PartsOut WHERE Grade = 10", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM PartsOut WHERE Grade = 11", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM PartsOut WHERE Grade = 12", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showData();

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Do you want to return this part?","Return Part", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                try
                {
                    string fName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string lName = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    string pName = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    string Quantity = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();


                    SqlCommand cmd1 = new SqlCommand("return", new SqlConnection(conString));
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@pName", pName);
                    cmd1.Parameters.AddWithValue("@fName", fName);
                    cmd1.Parameters.AddWithValue("@lName", lName);

                    cmd1.Connection.Open();

                    cmd1.ExecuteScalar();

                    cmd1.Connection.Close();


                    cmd1 = new SqlCommand("spFindAmount", new SqlConnection(conString));
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("searchString", pName);

                    cmd1.Connection.Open();
                    var amount = cmd1.ExecuteScalar();
                    cmd1.Connection.Close();

                    int returnPart = Convert.ToInt32(amount) + Convert.ToInt32(Quantity);


                    cmd1 = new SqlCommand("spReturn", new SqlConnection(conString));
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@pName", pName);
                    cmd1.Parameters.AddWithValue("@quantity", returnPart);

                    cmd1.Connection.Open();
                    cmd1.ExecuteScalar();
                    cmd1.Connection.Close();

                    MessageBox.Show("Successfully returned items!");
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Could not return parts!");
                }
            }
            else
            {
               
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(s);
        }
    }
}
