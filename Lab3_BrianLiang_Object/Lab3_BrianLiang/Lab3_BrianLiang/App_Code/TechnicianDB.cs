using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Lab3 ASP.NET
 * Author: Brian Liang
 * Date: July 2018
 */


namespace Lab3_BrianLiang
{
    [DataObject(true)]          //allows technicianDB to be seen as data object
    public static class TechnicianDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]     //data object method select attribute
        public static List<Technician> GetTechnicians()
        {
            List<Technician> technicians = new List<Technician>(); // make an empty list
            Technician tech; // reference to new state object
            
            SqlConnection connection = TechSupportDB.GetConnection(); // create connection

            // create select command
            string selectString = "select TechID, Name from Technicians " +
                                  "order by Name";
            SqlCommand selectCommand = new SqlCommand(selectString, connection);
            try
            {
                // open connection
                connection.Open();
                // run the select command and process the results adding states to the list
                SqlDataReader reader = selectCommand.ExecuteReader();
                while(reader.Read())// process next row
                {
                    tech = new Technician();
                    tech.TechID = (int) reader["TechID"];       //TechID
                    tech.Name = reader["Name"].ToString();      //Tech Name
                    technicians.Add(tech);      //adding them to technician list
                }
                reader.Close();     // close reader
            }
            catch (Exception ex)
            {
                throw ex; // throw it to the form to handle
            }
            finally
            {
                connection.Close();     //close connection
            }
            return technicians;     // returns the technicans list
        }
    }
}
