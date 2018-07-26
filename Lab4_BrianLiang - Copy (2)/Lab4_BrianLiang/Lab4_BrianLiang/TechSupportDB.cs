using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab4_BrianLiang
{
    public class TechSupportDB
    {
        public static SqlConnection GetConnection()     //GetConnection 
        {
            //getting connection string from web.config
            string connString = ConfigurationManager.ConnectionStrings["TechSupportConnectionString"].ConnectionString; //techsupport connection string
            SqlConnection conn = new SqlConnection(connString);
            return conn;        //return the connection string
        }
    }
}