using System;
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
    public partial class Full_Log : Form
    {

        string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=X:\TowerSearch\TowerSearch\Parts.mdf;Integrated Security=True";


        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;


        public Full_Log()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void showData()
        {
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM Log", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Full_Log_Load(object sender, EventArgs e)
        {
            showData();
            this.dataGridView1.Sort(this.dateDataGridViewTextBoxColumn, ListSortDirection.Ascending);
        }

        //9th Grade
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM Log WHERE Grade = 9", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //10th Grade
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM Log WHERE Grade = 10", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //11th Grade
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM Log WHERE Grade = 11", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //12th Grade
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM Log WHERE Grade = 12", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showData();
        }

    }
}
