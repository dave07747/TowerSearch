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
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Common;

namespace TowerSearch
{
    public partial class EditParts : Form
    {
        const string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=X:\TowerSearch\TowerSearch\Parts.mdf;Integrated Security=True";
        static DataClasses1DataContext PartsLog = new DataClasses1DataContext(conString);
        static Table<Part> listOfParts = PartsLog.GetTable<Part>();

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        public EditParts()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            //Start binding
           

           /* Table<Part> parts = PartsLog.GetTable<Part>();

            var allParts = from Part in parts select Part;

            partBindingSource.DataSource = allParts;

            dataGridView1.DataSource = partBindingSource;*/

        }

        private void showData()
        {
           /* DataSet DS = new DataSet();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Parts", con);
            DA.Fill(DS, "Parts");
            dataGridView1.DataSource = DS.Tables["Parts"];
            con.Close();*/

            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM Parts", con);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void EditParts_Load(object sender, EventArgs e)
        {
           showData();

        
        }

        private void button1_Click(object sender, EventArgs e)
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
