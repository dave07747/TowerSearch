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

namespace TowerSearch
{
    public partial class LogView : Form
    {
        public LogView()
        {
            InitializeComponent();

            using (DataClasses1DataContext databaseLogs = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = databaseLogs.PartsOuts.Where(w => w.isOut == 1).Select(s => new
                { Quantity = s.Quantity.ToString(), Grade = s.Grade.ToString(), LastName = s.LastName, PartName = s.PartName, FirstName = s.FirstName }).ToList();
                //dataGridView1.DataSource = databaseLogs.PartsOuts.Where(w => w.isOut == 1).Select(s => new { Quantity = s.Quantity }).ToList();
                //dataGridView1.DataSource = databaseLogs.PartsOuts.Where(w => w.isOut == 1).Select(s => new { LastName = s.LastName }).ToList();

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext databaseLogs = new DataClasses1DataContext())
            {
                databaseLogs.Refresh(RefreshMode.OverwriteCurrentValues, databaseLogs.PartsOuts);

                dataGridView1.DataSource = databaseLogs.PartsOuts.Where(w => w.isOut == 1).Select(s => new { Quantity = s.Quantity.ToString(), Grade = s.Grade.ToString(), LastName = s.LastName, PartName = s.PartName, FirstName = s.FirstName }).ToList();

            }

        }

    }
}
