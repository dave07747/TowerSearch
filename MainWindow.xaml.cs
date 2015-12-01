using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* string xCoordinate;
         string yCoordinate;
         string tower;
         string side;
         string partNameforSearch;
         string quantity;
         */

        static int firstOpen = 0;
        public MainWindow()
        {
            InitializeComponent();
            // this.WindowState = WindowState.Maximized;

        }



        //Search
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Search().Show();
            this.Hide();
        }

        //View Logs
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new LogView().Show();
            this.Hide();
        }

        //Borrow
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Borrow().Show();
            this.Hide();
        }

        //Return
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new Return().Show();
            this.Hide();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (firstOpen == 0)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConString.conString);
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Successfully connected to server!");

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a uh-oh:\t\t\t :(\n\n\n\n\n" + ex);
                    MessageBox.Show(ex.InnerException.ToString());
                    MessageBox.Show(ex.StackTrace);
                    this.Close();
                }
                firstOpen++;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\TowerSearch"))
            {
                Directory.CreateDirectory("C:\\TowerSearch");
            }
            try
            {
                //const string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Parts.mdf;Integrated Security=True";
                // string conString = @"Data Source=DAVIDS_LAPTOP;Initial Catalog=X:\PARTS.MDF;Integrated Security=True";
                string conString = ConString.conString;
                string backupDir = @"C:\TowerSearch";

                BackupService backup = new BackupService(conString, backupDir);
                backup.BackupAllUserDatabases();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }

            // Close the app
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }


        // Help Button
        private const uint WS_EX_CONTEXTHELP = 0x00000400;
        private const uint WS_MINIMIZEBOX = 0x00020000;
        private const uint WS_MAXIMIZEBOX = 0x00010000;
        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_FRAMECHANGED = 0x0020;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_CONTEXTHELP = 0xF180;


        [DllImport("user32.dll")]
        private static extern uint GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, uint newStyle);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height, uint flags);


        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            uint styles = GetWindowLong(hwnd, GWL_STYLE);
            styles &= 0xFFFFFFFF ^ (WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
            SetWindowLong(hwnd, GWL_STYLE, styles);
            styles = GetWindowLong(hwnd, GWL_EXSTYLE);
            styles |= WS_EX_CONTEXTHELP;
            SetWindowLong(hwnd, GWL_EXSTYLE, styles);
            SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
            ((HwndSource)PresentationSource.FromVisual(this)).AddHook(HelpHook);
        }

        private IntPtr HelpHook(IntPtr hwnd,
                int msg,
                IntPtr wParam,
                IntPtr lParam,
                ref bool handled)
        {
            if (msg == WM_SYSCOMMAND &&
                    ((int)wParam & 0xFFF0) == SC_CONTEXTHELP)
            {
                new HelpAboutWindow().Show();
                handled = true;
            }
            return IntPtr.Zero;
        }

    }
}
