using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Microsoft.VisualBasic;
using Application = System.Windows.Forms.Application;

namespace TowerSearch
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        private static bool firstOpen = true;
        private readonly string adminEmail = @"C:\TowerSearch\Do Not Enter\1\1\2\0\Admin Email";
        private string email;
        private bool goingToMakeAdmin;
        private int min;
        private readonly string minAmountFile = @"C:\TowerSearch\Do Not Enter\1\1\2\0\min";


        public MainWindow()
        {
            InitializeComponent();
            if (!Directory.Exists("C:\\TowerSearch"))
            {
                Directory.CreateDirectory("C:\\TowerSearch");
            }

            makeCodeFolders();
        }

        private void makeAdminEmail()
        {
            email = Interaction.InputBox("What is the admin's email?", "Admin Email Needed");
            //MessageBox.Show(email);
            var writer = new StreamWriter(adminEmail);
            writer.WriteLine(email);
            writer.Close();
        }

        private void makeCodeFolders()
        {
            //ProgressBar progress = new ProgressBar(); 
            //progress.Text = ("Doing some start up stuff");

            if (!Directory.Exists("C:\\TowerSearch\\Do Not Enter\\1\\1\\2\\0"))
            {
                goingToMakeAdmin = true;
                var bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.DoWork += delegate
                {
                    for (var w = 0; w < 10; ++w)
                    {
                        for (var e = 0; e < 10; ++e)
                        {
                            for (var r = 0; r < 10; ++r)
                            {
                                for (var t = 0; t < 10; ++t)
                                {
                                    Directory.CreateDirectory("C:\\TowerSearch\\Do Not Enter\\" + w + "\\" + e + "\\" +
                                                              r + "\\" + t);
                                }
                            }
                        }
                    }
                };
                bw.RunWorkerCompleted += (s3, e3) =>
                {
                    makeAdminEmail();
                    if (File.Exists(adminEmail))
                        SendMail();
                };

                bw.RunWorkerAsync();
            }
        }

        private void SendMail()
        {
            var messageToSend =
                "If you are getting this, there was an error in the system. Please have it checked out!";

            try
            {
                var minReader = new StreamReader(minAmountFile);
                min = Convert.ToInt32(minReader.ReadLine());
                // MessageBox.Show("File present");

                var comm = new SqlCommand();
                comm.Connection = new SqlConnection(ConString.conString);
                var sql = @"SELECT * FROM Parts WHERE Quantity < " + min;

                comm.CommandText = sql;
                comm.Connection.Open();

                var sqlReader = comm.ExecuteReader();
                if (sqlReader == null)
                {
                }
                else
                {
                    messageToSend = "Part Name\tQuantity\n*******************************\n\n";

                    while (sqlReader.Read())
                    {
                        messageToSend += sqlReader["PartName"] + "\t\t" + sqlReader["Quantity"] + "\n";
                    }
                    sqlReader.Close();
                    comm.Connection.Close();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Could not connect to the internet to send email of parts needed...");
            }


            try
            {
                if (File.Exists(adminEmail))
                {
                    var reader = new StreamReader(adminEmail);
                    email = reader.ReadLine();
                    reader.Close();

                    if (File.Exists(@"C:\TowerSearch\Do Not Enter\1\1\2\0\min"))
                    {
                        var mail = new MailMessage();
                        var SmtpServer = new SmtpClient("smtp.gmail.com");

                        mail.From = new MailAddress("weneedsomeparts@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Parts are low!";
                        mail.Body = messageToSend;

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new NetworkCredential("weneedsomeparts@gmail.com",
                            "Academy123");
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                        //MessageBox.Show("Going to send mail");
                    }
                }
                else
                {
                    if (Directory.Exists(@"C:\TowerSearch\Do Not Enter\1\1\2\0") && goingToMakeAdmin)
                    {
                        makeAdminEmail();
                        SendMail();
                    }
                }
            }
            catch
                (Exception exception)
            {
                MessageBox.Show("Could not email admin");
            }
        }


        //Search
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            new Search().Show();
            
        }

        //View Logs
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new LogView().Show();
            
        }

        //Borrow
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Borrow().Show();
            
        }

        //Return
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new Return().Show();
            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += delegate
            {
                if (firstOpen)
                {
                    try
                    {
                        var conn = new SqlConnection(ConString.conString);
                        conn.Open();
                       /* if (conn.State == ConnectionState.Open)
                        {
                            MessageBox.Show("Successfully connected to server!");
                        }*/
                        if (!File.Exists(adminEmail) && !goingToMakeAdmin)
                            makeAdminEmail();

                        SendMail();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was a uh-oh when connecting to the database\t:(");
                        Close();
                    }
                    firstOpen = false;
                }
            };
            bw.RunWorkerAsync();
        }

        private void Window_Closed(object sender, CancelEventArgs e)
        {
            if (!Directory.Exists("C:\\TowerSearch"))
            {
                Directory.CreateDirectory("C:\\TowerSearch");
            }
            try
            {
                //const string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Parts.mdf;Integrated Security=True";
                // string conString = @"Data Source=DAVIDS_LAPTOP;Initial Catalog=X:\PARTS.MDF;Integrated Security=True";
                var conString = ConString.conString;
                var backupDir = @"C:\TowerSearch\Do Not Enter\1\1\2\0\";

                var backup = new BackupService(conString, backupDir);
                backup.BackupAllUserDatabases();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Close the app
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }


        [DllImport("user32.dll")]
        private static extern uint GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, uint newStyle);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height,
            uint flags);


        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;
            var styles = GetWindowLong(hwnd, GWL_STYLE);
            styles &= 0xFFFFFFFF ^ (WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
            SetWindowLong(hwnd, GWL_STYLE, styles);
            styles = GetWindowLong(hwnd, GWL_EXSTYLE);
            styles |= WS_EX_CONTEXTHELP;
            SetWindowLong(hwnd, GWL_EXSTYLE, styles);
            SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
            ((HwndSource) PresentationSource.FromVisual(this)).AddHook(HelpHook);
        }

        private IntPtr HelpHook(IntPtr hwnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam,
            ref bool handled)
        {
            if (msg == WM_SYSCOMMAND &&
                ((int) wParam & 0xFFF0) == SC_CONTEXTHELP)
            {
                new HelpAboutWindow().Show();
                handled = true;
            }
            return IntPtr.Zero;
        }

     
    }
}