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

        string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=X:\TowerSearch\TowerSearch\Parts.mdf;Integrated Security=True";


        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;


        public LogView()
        {
            InitializeComponent();

          this.WindowState = FormWindowState.Maximized;

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

    }
}
