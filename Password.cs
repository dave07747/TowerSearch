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

          string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=X:\TowerSearch\TowerSearch\Parts.mdf;Integrated Security=True";


          public Pass()
          {
              SqlCommand cmd1 = new SqlCommand("spCheckPass", new SqlConnection(conString));
              cmd1.CommandType = CommandType.StoredProcedure;

              cmd1.Connection.Open();
              password = cmd1.ExecuteScalar().ToString();
              cmd1.Connection.Close();
          }

        public bool checkPass(string testPass)
        {
            if (testPass == password)
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
    }
}
