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
        /**************************************************************************************/
        // Hey fam                                                                            \\
        // So, like I said, this is horribly documented                                       \\
        // To get a feel for the program I want you guys to recreate the effect of this form  \\
        // I'll guide you through this, don't worry                                           \\
        // Here you have the skeleton of this, with the buttons and form loads and all        \\
        // I'll put comments in all these aspects so you know what to do                      \\
        // But it will be YOUR job to figure out how to make it work                          \\
        // If you need any help at all, feel free to contact me on facebook                   \\
        // But I'll only guide you, not actually give you the answer.                         \\
        // This is a learning experience, so do your best to immerse yourself in C#           \\
        // Cheers, David                                                                      \\
        /**************************************************************************************/

        // P.S. Feel free to explore the rest of this project for ideas on how to implement different things
        // P.P.S. Stackoverflow.com is your best friend
        // P.P.P.S. If stackoverflow fails, then just google it. 
        // P.P.P.P.S Make sure you put every set of info in the string on a new line

        public Search()
        {
            InitializeComponent();
        }
        string s;

        string conString = ConString.conString;

        private void Search_Load(object sender, EventArgs e)
        {
            // Here you will be making the auto-complete feature, where when you type, the part shows up
            // Note, the form is already set up correctly, just the code-behind is needed
        }

        public void findTower()
        {
            // Here you will implement the spFindTower stored procedure
            // If there is no part (i.e. spFindTower == null) then display a message box saying "No part available"
            // Else add the tower to string s
        }

        public void findSide()
        {
            // Here you will implement the spFindSide stored procedure
            // Add the side to string s
           
        }

        public void findX()
        {
            // Here you will implement the spFindX stored procedure
            // Add the X-coordinate to string s
            
        }

        public void findY()
        {
            // Here you will implement the spFindY stored procedure
            // Add the y-coorinate to string s
    
        }

        public void findAmount()
        {
            // Here you will implement the spFindAmount stored procedure
            // Add the quantity to string s
            // If there are 0 parts, add "**This part is currently unavailable**" to string s
           
        }

        public void findPart()
        {
            // Here you will implement the spFindPart stored procedure
            // If there is such a part, add it to string s
            // Else make string s = "No part available"
        
        }


        private void button1_Click(object sender, EventArgs e)
        {
        // Now comes the real fun...
        // Here you have to figure out how to distinguish if info is in the pName box or other boxes
            // If all boxes are filled with text, default to just searching the part name
        // Figure out how and where to run all the methods
        // Make sure you protect against invalid characters and againsts characters if it is a number field
        // Happy hacking
   
            s = partName.Text + " is located at:\nTower: ";

        }


        // This is just tab control. If you wanna look through it, go right ahead

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

        private void Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
