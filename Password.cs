using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TowerSearch
{
    class Pass
    {
        string password;
        string master;

        //string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Parts.mdf;Integrated Security=True";
        string conString = ConString.conString;
            //    ConnectionString = @"metadata=res://*/bazaRMS.csdl|res://*/bazaRMS.ssdl|res://*/bazaRMS.msl;provider=System.Data.SqlClient;provider connection string=""data source=" + DbIP + @";initial catalog=" + DbName + @";persist security info=True;user id=" + DbLogin + @";password=" + DbPassword + @";MultipleActiveResultSets=True;App=EntityFramework""";
    //Data Source=DAVIDS_LAPTOP;Initial Catalog=X:\PARTS.MDF;Integrated Security=True

          public Pass()
          {
              
            
              SqlCommand cmd1 = new SqlCommand("spCheckPass", new SqlConnection(conString));
              cmd1.Parameters.AddWithValue("@ID", 1);
              cmd1.CommandType = CommandType.StoredProcedure;

              cmd1.Connection.Open();
              password = cmd1.ExecuteScalar().ToString();
              cmd1.Connection.Close();


              cmd1 = new SqlCommand("spCheckPass", new SqlConnection(conString));
              cmd1.Parameters.AddWithValue("@ID", 2);
              cmd1.CommandType = CommandType.StoredProcedure;

              cmd1.Connection.Open();
              master = cmd1.ExecuteScalar().ToString();
              cmd1.Connection.Close();
          }

        public bool checkPass(string testPass)
        {
            if (testPass == password || testPass == master)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkPassMaster(string testPass)
        {
            if (testPass == master)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void changePassword(string newPass)
        {
           
            SqlCommand cmd = new SqlCommand("spUpdatePassword", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Password", newPass);

            cmd.Connection.Open();
            cmd.ExecuteScalar();
            cmd.Connection.Close();
        }

        public void changeSU(string newPass)
        {
            SqlCommand cmd = new SqlCommand("spUpdateMasterPassword", new SqlConnection(conString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Password", newPass);

            cmd.Connection.Open();
            cmd.ExecuteScalar();
            cmd.Connection.Close();
        }
    }
}
