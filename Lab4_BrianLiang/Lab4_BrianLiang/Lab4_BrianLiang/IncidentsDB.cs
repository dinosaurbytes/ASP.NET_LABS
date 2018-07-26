using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/*
 * Lab4 ASP.NET
 * Author: Brian Liang
 * Date: July 2018
 */

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
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);     //selectcommand object
            selectCommand.Parameters.AddWithValue("@TechID", techID);
            try
            {
                connection.Open();  // open the connection

                SqlDataReader reader = selectCommand.ExecuteReader();       //execute query

                
                while (reader.Read()) // process while there are techID's
                {
                    tech = new Incident(); 

                    object sqlDateTime = reader["DateClosed"];
                    if (sqlDateTime == System.DBNull.Value)              //check if DateClosed is null
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
            catch (Exception ex)        //catch any exceptions
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
        public static List<Incident> GetIncidentByCustomer(int custID)        //Get based on custID parameter
        {
            List<Incident> incidents = new List<Incident>(); // empty list
            Incident cust = null; // reference for reading 

            SqlConnection connection = TechSupportDB.GetConnection(); // define connection

            // define the select query command
            string selectQuery = "select IncidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                 "from Incidents " +
                                 "where CustomerID = @CustomerID " +
                                 "order by DateOpened";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);     //selectCommand object
            selectCommand.Parameters.AddWithValue("@CustomerID", custID);
            try
            {
                connection.Open();   // open the connection
                
                SqlDataReader reader = selectCommand.ExecuteReader(); // execuates query

                // process the results
                while (reader.Read()) // while there are custIDs
                {
                    cust = new Incident();
                   
                        cust.IncidentID = (int)reader["IncidentID"];            //incidentID
                        cust.CustomerID = (int)reader["CustomerID"];            //CustomerID
                        cust.ProductCode = reader["ProductCode"].ToString();    //ProductCode

                    object sqlTechID = reader["TechID"];
                    cust.TechID = (sqlTechID == System.DBNull.Value)            //if there are null TechIDs
                    ? (int?)null
                    : Convert.ToInt32(reader["TechID"]);
                    
                        cust.DateOpened = (DateTime)reader["DateOpened"];       //DateOpened

                        object sqlDateTime = reader["DateClosed"];
                        cust.DateClosed = (sqlDateTime == System.DBNull.Value)  //if there are null DateClosed
                        ? (DateTime?)null
                        : Convert.ToDateTime(reader["DateClosed"]);

                        cust.Title = reader["Title"].ToString();                //Title
                        cust.Description = reader["Description"].ToString();    //Description
                        incidents.Add(cust);            //adds the customer incidents parameters to incidents list
                }
            }
            catch (Exception ex)        //checks for exceptions
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
         * Creates a list of all distint customer IDs
         */

        public static List<Incident> GetCustomerID()        //Gets list of all customer IDs
        {
            List<Incident> customerID = new List<Incident>(); // empty list
            Incident cust = null; // reference for reading 

            SqlConnection connection = TechSupportDB.GetConnection(); // define connection

            // define the select query command
            string selectQuery = "select distinct CustomerID " +        //used DISTINCT to eliminate repeated IDs
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
                    cust.CustomerID = (int)reader["CustomerID"];       //CustomerID
                    customerID.Add(cust);      //adding the customerIDs to the list
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
            return customerID;     // returns the customerID list
        }


    }
}