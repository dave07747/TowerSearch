using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using Microsoft.VisualBasic;

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for CheckPartAmount.xaml
    /// </summary>
    public partial class CheckPartAmount : Window
    {
        public CheckPartAmount()
        {
            InitializeComponent();
        }


        private Font verdana10Font;
        private StreamReader reader;
        private readonly string adminEmail = @"C:\TowerSearch\Do Not Enter\1\1\2\0\Admin Email";
        string dbFile = @"C:\TowerSearch\ListOfPartsNeeded.txt";
        private string minAmountFile = @"C:\TowerSearch\Do Not Enter\1\1\2\0\min";

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                ThresholdAmountLabel.Text = Convert.ToString(Convert.ToInt32(slider1.Value));
            }
            catch (Exception ee)
            {

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter minWriter = File.CreateText(minAmountFile);
            minWriter.WriteLine(Convert.ToInt32(slider1.Value).ToString());
            minWriter.Close();

            SqlCommand comm = new SqlCommand();
            comm.Connection = new SqlConnection(ConString.conString);
            String sql = @"SELECT * FROM Parts WHERE Quantity < " + Convert.ToInt32(slider1.Value);

            comm.CommandText = sql;
            comm.Connection.Open();

            SqlDataReader sqlReader = comm.ExecuteReader();
            if (sqlReader == null)
            {
                System.Windows.Forms.MessageBox.Show("There are no parts in the table below threshold!");
            }
            else
            {
                StreamWriter writer = File.CreateText(dbFile);

                writer.WriteLine("Part Name\tQuantity\n******************************\n\n");

                while (sqlReader.Read())
                {
                    writer.WriteLine(sqlReader["PartName"] + "\t\t" + sqlReader["Quantity"] + "\n");
                }
                writer.Close();
                sqlReader.Close();
                comm.Connection.Close();

                DialogResult result = System.Windows.Forms.MessageBox.Show("Do you want to print the list?", "Print?", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    reader = new StreamReader(dbFile);
                    verdana10Font = new Font("Verdana", 16);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.PrintTextFileHandler);
                    pd.Print();
                    if (reader != null)
                    {
                        reader.Close();
                    }

                    Close();
                }
                else if (result == System.Windows.Forms.DialogResult.No)
                {
                    System.Windows.Forms.MessageBox.Show("The list has been generated.");
                    Close();
                }


                //  MessageBox.Show("The list has been generated.");
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new Admin().Show();
        }

        private void PrintTextFileHandler(object sender, PrintPageEventArgs ppeArgs)
        {
            //Get the Graphics object
            Graphics g = ppeArgs.Graphics;
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;

            //Read margins from PrintPageEventArgs
            float leftMargin = ppeArgs.MarginBounds.Left;
            float topMargin = ppeArgs.MarginBounds.Top;
            string line = null;

            //Calculate the lines per page on the basis of the height of the page and the height of the font
            linesPerPage = ppeArgs.MarginBounds.Height /
            verdana10Font.GetHeight(g);

            //Now read lines one by one, using StreamReader
            while (count < linesPerPage &&
            ((line = reader.ReadLine()) != null))
            {

                //Calculate the starting position
                yPos = topMargin + (count *
                verdana10Font.GetHeight(g));

                //Draw text
                g.DrawString(line, verdana10Font, Brushes.Black,
                leftMargin, yPos, new StringFormat());

                //Move to next line
                count++;
            }

            //If PrintPageEventArgs has more pages to print
            if (line != null)
            {
                ppeArgs.HasMorePages = true;
            }
            else
            {
                ppeArgs.HasMorePages = false;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var email = Interaction.InputBox("What is the admin's email?", "Admin Email Needed");
            //MessageBox.Show(email);
            var writer = new StreamWriter(adminEmail);
            writer.WriteLine(email);
            writer.Close();
        }
    }
}
