using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_BrianLiang
{
    public static class TechSupportDB
    {
        public static SqlConnection GetConnection()
        {
            //getting connection string from web.config
            string connString = ConfigurationManager.ConnectionStrings["TechSupportConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
