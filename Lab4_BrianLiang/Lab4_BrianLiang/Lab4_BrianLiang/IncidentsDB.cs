using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab4_BrianLiang
{
    public class IncidentsDB
    {
        public static List<Incident> GetIncidentByTechnician(int techID)        //Get based on techID parameter
        {
            List<Incident> incidents = new List<Incident>(); // empty list
            Incident tech = null; // reference for reading 

            SqlConnection connection = TechSupportDB.GetConnection(); // define connection

            // define the select query command
            string selectQuery = "select IncidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                 "from Incidents " +
                                 "where TechID = @TechID " +
                                 "order by DateOpened";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@TechID", techID);
            try
            {
                // open the connection
                connection.Open();

                // execute the query
                SqlDataReader reader = selectCommand.ExecuteReader(); // can be multiple records

                // process the results
                while (reader.Read()) // while there are customers
                {
                    tech = new Incident();

                    object sqlDateTime = reader["DateClosed"];
                    if (sqlDateTime == System.DBNull.Value)              //if DateClosed is null
                    {
                        tech.IncidentID = (int)reader["IncidentID"];            //incidentID
                        tech.CustomerID = (int)reader["CustomerID"];            //CustomerID
                        tech.ProductCode = reader["ProductCode"].ToString();    //ProductCode
                        tech.TechID = (int?)reader["TechID"];                   //TechID
                        tech.DateOpened = (DateTime)reader["DateOpened"];       //DateOpened
                        tech.DateClosed = (DateTime?)null;                      //DateClosed
                        tech.Title = reader["Title"].ToString();                //Title
                        tech.Description = reader["Description"].ToString();    //Description
                        incidents.Add(tech);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close(); // close connecto no matter what
            }

            return incidents;   //return the incidents list
        }


    }
}