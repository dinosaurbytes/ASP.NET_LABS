using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Lab3 APS.NET
 * Author: Brian Liang
 * Date: July 2018 
 */

namespace Lab3_BrianLiang
{
    public static class TechSupportDB       //connection to the TechSupport Database
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
