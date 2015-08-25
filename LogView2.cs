using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerSearch
{
    public partial class LogView2 : Form
    {
        public LogView2()
        {
            InitializeComponent();

            DataClasses1DataContext databaseLogs = new DataClasses1DataContext();
            dataGridView1.DataSource = databaseLogs.PartsOuts; // databaseLogs.Logs;
        }
    }
}
