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
    public partial class PartsStats : Form
    {
        string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=X:\TowerSearch\TowerSearch\Parts.mdf;Integrated Security=True";

        public PartsStats()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            using (DataClasses1DataContext databaseLogs = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = databaseLogs.Logs.ToList();
            }
        }

        private void showData()
        {
            DataSet DS = new DataSet();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Parts", con);
            DA.Fill(DS, "Parts");
            dataGridView1.DataSource = DS.Tables["Parts"];
            con.Close();
        }

        private void PartsStats_Load(object sender, EventArgs e)
        {
            showData();
            this.dataGridView1.Sort(this.timesTakenOutDataGridViewTextBoxColumn, ListSortDirection.Descending);
        }
    }
}