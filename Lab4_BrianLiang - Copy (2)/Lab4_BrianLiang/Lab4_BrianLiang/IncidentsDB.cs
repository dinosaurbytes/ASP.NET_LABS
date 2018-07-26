using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab4_BrianLiang
{
    public class IncidentsDB
    {
        /*
         * Searching for only incidents by TechID
         */
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

        /*
        * Searching for all incidents by CustomerID
        */
        public static List<Incident> GetIncidentByCustomer(int custID)        //Get based on techID parameter
        {
            List<Incident> incidents = new List<Incident>(); // empty list
            Incident cust = null; // reference for reading 

            SqlConnection connection = TechSupportDB.GetConnection(); // define connection

            // define the select query command
            string selectQuery = "select IncidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                 "from Incidents " +
                                 "where CustomerID = @CustomerID " +
                                 "order by DateOpened";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", custID);
            try
            {
                // open the connection
                connection.Open();

                // execute the query
                SqlDataReader reader = selectCommand.ExecuteReader(); // can be multiple records

                // process the results
                while (reader.Read()) // while there are customers
                {
                    cust = new Incident();

                    
                        cust.IncidentID = (int)reader["IncidentID"];            //incidentID
                        cust.CustomerID = (int)reader["CustomerID"];            //CustomerID
                        cust.ProductCode = reader["ProductCode"].ToString();    //ProductCode

                    object sqlTechID = reader["TechID"];
                    cust.TechID = (sqlTechID == System.DBNull.Value)
                    ? (int?)null
                    : Convert.ToInt32(reader["TechID"]);

                    //cust.TechID = (int?)reader["TechID"];                   //TechID
                        cust.DateOpened = (DateTime)reader["DateOpened"];       //DateOpened

                        object sqlDateTime = reader["DateClosed"];
                        cust.DateClosed = (sqlDateTime == System.DBNull.Value)
                        ? (DateTime?)null
                        : Convert.ToDateTime(reader["DateClosed"]);


                        //cust.DateClosed = (DateTime?)null;                      //DateClosed
                        cust.Title = reader["Title"].ToString();                //Title
                        cust.Description = reader["Description"].ToString();    //Description
                        incidents.Add(cust);
                    
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

        public static List<Incident> GetCustomerID()        //Get based on techID parameter
        {
            List<Incident> customerID = new List<Incident>(); // empty list
            Incident cust = null; // reference for reading 

            SqlConnection connection = TechSupportDB.GetConnection(); // define connection

            // define the select query command
            string selectQuery = "select distinct CustomerID " +
                                 "from Incidents " +
                                 "order by CustomerID";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            try
            {
                // open connection
                connection.Open();
                // run the select command and process the results adding states to the list
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())// process next row
                {
                    cust = new Incident();
                    cust.CustomerID = (int)reader["CustomerID"];       //TechID
                    customerID.Add(cust);      //adding them to technician list
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
            return customerID;     // returns the technicans list
        }


    }
}