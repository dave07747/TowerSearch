using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerSearch
{
   public static class ConString
    {
       // public  const string conString = @"Data Source=DAVIDS_LAPTOP;Initial Catalog=X:\PARTS.MDF;Integrated Security=True";
      //  public const string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Parts.mdf;Integrated Security=True";
       public const string conString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Parts.mdf;Integrated Security=True";
      
    }
}
