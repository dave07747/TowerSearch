using System;
using System.Windows;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Net.Mail;
using System.Windows.Forms;
using System.ComponentModel;
using MessageBox = System.Windows.MessageBox;

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string minAmountFile = @"C:\TowerSearch\min";
        private int min;

        static bool firstOpen = true;
        public MainWindow()
        {
            InitializeComponent();
            // this.WindowState = WindowState.Maximized;
            if (!Directory.Exists("C:\\TowerSearch"))
            {
                Directory.CreateDirectory("C:\\TowerSearch");
            }

            if(firstOpen)
                SendMail();

            makeCodeFolders();
        }

        private void makeCodeFolders()
        {
            //ProgressBar progress = new ProgressBar(); 
            //progress.Text = ("Doing some start up stuff");

            if (!Directory.Exists("C:\\TowerSearch\\Do Not Enter"))
            {

                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs args)
                {


          
                            for (int w = 0; w < 10; ++w)
                            {
                                for (int e = 0; e < 10; ++e)
                                {
                                    for (int r = 0; r < 10; ++r)
                                    {
                                        for (int t = 0; t < 10; ++t)
                                        {
                                            for (int y = 0; y < 10; ++y)
                                            {
                                                for (int u = 0; u < 10; ++u)
                                                {
                                                    Directory.CreateDirectory("C:\\TowerSearch\\Do Not Enter\\" + w + "\\" + e + "\\" + r +
                                                                              "\\" + t + "\\" + y + "\\" + u);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                    

                });

                bw.RunWorkerAsync();
            }
        }

        private void SendMail()
        {
            string messageToSend =
                "If you are getting this, there was an error in the system. Please have it checked out!";

            try
            {
                StreamReader minReader = new StreamReader(minAmountFile);
                min = Convert.ToInt32(minReader.ReadLine());
               // MessageBox.Show("File present");

                SqlCommand comm = new SqlCommand();
                comm.Connection = new SqlConnection(ConString.conString);
                String sql = @"SELECT * FROM Parts WHERE Quantity < " + min;

                comm.CommandText = sql;
                comm.Connection.Open();

                SqlDataReader sqlReader = comm.ExecuteReader();
                if (sqlReader == null)
                {
                  
                }
                else
                {


                    messageToSend = "Part Name\tQuantity\n*******************************\n\n";

                    while (sqlReader.Read())
                    {
                        messageToSend += (sqlReader["PartName"] + "\t\t" + sqlReader["Quantity"] + "\n");
                    }
                    sqlReader.Close();
                    comm.Connection.Close();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to the internet to send email of parts needed...");
            }


            try
            {
                if (File.Exists(@"C:\TowerSearch\min"))
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("dave07747@gmail.com");
                    mail.To.Add("dave07747@gmail.com");
                    mail.Subject = "Parts are low!";
                    mail.Body = messageToSend;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("weneedsomeparts@gmail.com", "Academy123");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                   // MessageBox.Show("Sent Mail!");
                }
            }
            catch
                (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
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
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs args)
            {
                if (firstOpen)
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
                        MessageBox.Show("There was a uh-oh when connecting to the database\t:(");
                        this.Close();
                    }
                    firstOpen = false;
                }
            });
            bw.RunWorkerAsync();
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
                string backupDir = @"C:\TowerSearch\";

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
