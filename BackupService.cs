using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace TowerSearch
{
    class BackupService
    {
        private readonly string _connectionString;
        private readonly string _backupFolderFullPath;
        private readonly string[] _systemDatabaseNames = { "master", "tempdb", "model", "msdb" };

        public BackupService(string connectionString, string backupFolderFullPath)
        {
            _connectionString = connectionString;
            _backupFolderFullPath = backupFolderFullPath;
        }

        public void BackupAllUserDatabases()
        {
            foreach (string databaseName in GetAllUserDatabases())
            {
              //  MessageBox.Show(databaseName);
                BackupDatabase(databaseName);
            }
        }

        public void BackupDatabase(string databaseName)
        {
            string filePath = BuildBackupPathWithFilename(databaseName);

            Console.WriteLine(filePath);

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = String.Format("BACKUP DATABASE [{0}] TO DISK='{1}'", databaseName, filePath);

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RestoreDatabase(string filePath)
        {
            /**
            *TODO: restore databse command
            */

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = String.Format("BACKUP DATABASE [Parts] FROM DISK='{0}' WITH MOVE 'Parts' TO 'C:\\TowerSearch\\Parts.mdf' MOVE 'Parts_Log' TO 'C:\\TowerSearch\\Parts_log.ldf';", filePath);

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private IEnumerable<string> GetAllUserDatabases()
        {
            var databases = new List<String>();

            DataTable databasesTable;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                databasesTable = connection.GetSchema("Databases");

                connection.Close();
            }

            foreach (DataRow row in databasesTable.Rows)
            {
                string databaseName = row["database_name"].ToString();

                if (_systemDatabaseNames.Contains(databaseName))
                    continue;

                databases.Add(databaseName);
            }

            return databases;
        }

        private string BuildBackupPathWithFilename(string databaseName)
        {
            string filename = string.Format("{0}-{1}.bak", databaseName, DateTime.Now.ToString("yyyy-MM-dd"));

            return Path.Combine(_backupFolderFullPath, filename);
        }




        public void BackupDB(string backupDestinationFilePath)
        {
            try
            {

                string filePath = BuildBackupPathWithFilename(backupDestinationFilePath);

                Console.WriteLine(filePath);
                Console.WriteLine("Backup operation started");
                Backup backup = new Backup();
                //Set type of backup to be performed to database
                backup.Action = BackupActionType.Database;
                backup.BackupSetDescription = "BackupDataBase description";
                //Set the name used to identify a particular backup set.
                backup.BackupSetName = "Backup";
                //specify the name of the database to back up
                backup.Database = "TEST";
                //Set up the backup device to use filesystem.
                BackupDeviceItem deviceItem = new BackupDeviceItem(
                                                backupDestinationFilePath,
                                                DeviceType.File);
                backup.Devices.Add(deviceItem);

                // Setup a new connection to the data server
                ServerConnection connection = new
    ServerConnection(@"SERVER_NAME");
                // Log in using SQL authentication
                connection.LoginSecure = false;
                connection.Login = "testuser";
                connection.Password = "testuser";
                Server sqlServer = new Server(connection);
                //Initialize devices associated with a backup operation.
                backup.Initialize = true;
                backup.Checksum = true;
                //Set it to true to have the process continue even
                //after checksum error.
                backup.ContinueAfterError = true;
                //Set the backup expiry date.
                backup.ExpirationDate = DateTime.Now.AddDays(3);
                //truncate the database log as part of the backup operation.
                backup.LogTruncation = BackupTruncateLogType.Truncate;
                //start the back up operation
                backup.SqlBackup(sqlServer);
                Console.WriteLine("Backup operation succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Backup operation failed");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public static void RestoreDB(string backUpFilePath, string databaseName)
        {
            try
            {
                Console.WriteLine("Restore operation started");
                Restore restore = new Restore();
                //Set type of backup to be performed to database
                restore.Database = databaseName;
                restore.Action = RestoreActionType.Database;
                //Set up the backup device to use filesystem.         
                restore.Devices.AddDevice(backUpFilePath, DeviceType.File);
                //set ReplaceDatabase = true to create new database
                //regardless of the existence of specified database
                restore.ReplaceDatabase = true;
                //If you have a differential or log restore to be followed,
                //you would specify NoRecovery = true
                restore.NoRecovery = false;
                //if you want to restore to a different location, specify
                //the logical and physical file names
                restore.RelocateFiles.Add(new RelocateFile("Test",
    @"C:\Temp\Test.mdf"));
                restore.RelocateFiles.Add(new RelocateFile("Test_Log",
    @"C:\Temp\Test_Log.ldf"));
                ServerConnection connection = new
    ServerConnection(@"SERVER_NAME");
                //my SQL user doesnt have sufficient permissions,
                //so i am using my windows account
                connection.LoginSecure = true;
                //connection.LoginSecure = false;
                //connection.Login = "testuser";
                //connection.Password = "testuser";
                Server sqlServer = new Server(connection);
                //SqlRestore method starts to restore database           
                restore.SqlRestore(sqlServer);
                Console.WriteLine("Restore operation succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Restore operation failed");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

    }
}
