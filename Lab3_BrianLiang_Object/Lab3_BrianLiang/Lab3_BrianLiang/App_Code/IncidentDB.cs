using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    [DataObject(true)]          //Allows it to be visible as a data object
    public static class IncidentDB
    {

        [DataObjectMethod(DataObjectMethodType.Select)]     //data object method attribute for select
        public static List<Incident> GetIncidentByTechnician(int techID)        //Get based on techID parameter
        {
            List<Incident> incidents = new List<Incident>(); // empty list
            Incident tech = null; // reference for reading 
            
            SqlConnection connection = TechSupportDB.GetConnection(); // define connection

            // define the select query command
            string selectQuery = "select IncidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                 "from Incidents " +
                                 "where TechID = @TechID";
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
                    if(sqlDateTime == System.DBNull.Value)              //if DateClosed is null
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

/*
 * NOTE:
 * The following is based on the code written in the object source demo. The code below is for selecting, updating
 * and deleting. If we decide to advance the app to include those features we can use the below code.
 */


//        // retrieves customer with given ID
//        [DataObjectMethod(DataObjectMethodType.Select)]
//        public static Incident GetIncident(int incidentID)
//        {
//            Incident incid = null; // found customer
//            // define connection
//            SqlConnection connection = TechSupportDB.GetConnection();

//            // define the select query command
//            string selectQuery = "select IncidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
//                                  "from Incidents " +
//                                  "where IncidentID = @IncidentID";
//            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
//            selectCommand.Parameters.AddWithValue("@IncidentID", incidentID);
//            try
//            {
//                // open the connection
//                connection.Open();

//                // execute the query
//                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

//                // process the result if any
//                if (reader.Read()) // if there is customer
//                {
//                    incid = new Incident();
//                    incid.IncidentID = (int)reader["IncidentID"];
//                    incid.CustomerID = (int)reader["CustomerID"];
//                    incid.ProductCode = reader["ProductCode"].ToString();
//                    incid.TechID = (int)reader["TechID"];
//                    incid.DateOpened = (DateTime)reader["DateOpened"];
//                    incid.DateClosed = (DateTime?)reader["DateClosed"];
//                    incid.Title = reader["Title"].ToString();
//                    incid.Description = reader["Description"].ToString();
//                }
//            }
//            catch(Exception ex)
//            {
//                throw ex; // let the form handle it
//            }
//            finally
//            {
//                connection.Close(); // close connecto no matter what
//            }

//            return incid;
//        }

//        [DataObjectMethod(DataObjectMethodType.Insert)]
//        // inserts new customer record
//        public static int AddIncident(Incident incid) // returns generated customer id
//        {
//            int incidID = 0;
//            // prepare connection
//            SqlConnection connection = TechSupportDB.GetConnection();

//            // prepare the statement
//            string insertString = "insert into Incidents " +
//                                  "(CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description) " +
//                                  "values(@CustomerID, @ProductCode, @TechID, @DateOpened, @DateClosed, @Title, @Description)";
//            SqlCommand insertCommand = new SqlCommand(insertString, connection);
//            insertCommand.Parameters.AddWithValue("@CustomerID", incid.CustomerID);
//            insertCommand.Parameters.AddWithValue("@ProductCode", incid.ProductCode);
//            insertCommand.Parameters.AddWithValue("@TechID", incid.TechID);
//            insertCommand.Parameters.AddWithValue("@DateOpened", incid.DateOpened);
//            insertCommand.Parameters.AddWithValue("@DateClosed", incid.DateClosed);
//            insertCommand.Parameters.AddWithValue("@Title", incid.Title);
//            insertCommand.Parameters.AddWithValue("@Description", incid.Description);

//            try
//            {
//                // open connection
//                connection.Open();

//                // execute the statement
//                int i = insertCommand.ExecuteNonQuery();
//                if (i == 1) // one record inserted
//                {
//                    // retrieve customer id from the added record
//                    string selectString = "select ident_current('Incidents') " +
//                                          "from Incidents";
//                    SqlCommand selectCommand = new SqlCommand(selectString, connection);
//                    incidID = Convert.ToInt32(selectCommand.ExecuteScalar()); // (int) does not work!!!
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex; // pass the buck
//            }
//            finally
//            {
//                connection.Close();
//            }
//            return incidID;
//        }

//        // updates existing customer record and returns bool success flag
//        [DataObjectMethod(DataObjectMethodType.Update)]
//        public static bool UpdateIncident(Incident original_Incident, Incident incident)
//        {
//            bool successful = false;
//            SqlConnection connection = TechSupportDB.GetConnection();
//            string updateString = "update Incidents set " +
//                                  "IncidentID = @IncidentID, " +
//                                  "CustomerID = @CustomerID, " +
//                                  "ProductCode = @ProductCode, " +
//                                  "TechID = @TechID," +
//                                  "DateOpened = @DateOpened " +
//                                  "DateClosed = @DateClosed " +
//                                  "Title = @Title " +
//                                  "Description = @Description " +
//                                  "where " + // update succeeds only if record not changed by other users
//                                  "CustomerID  = @OldCustomerID and " +
//                                  "ProductCode = @OldProductCode and " +
//                                  "TechID = @OldTechID and " +
//                                  "DateOpened = @OldDateOpened and " +
//                                  "DateClosed = @OldDateClosed and " +
//                                  "Title = @OldTitle and " +
//                                  "Description = @OldDescription";
//            SqlCommand updateCommand = new SqlCommand(updateString, connection);
//            updateCommand.Parameters.AddWithValue("@OldCustomerID", original_Incident.CustomerID);
//            updateCommand.Parameters.AddWithValue("@OldProductCode", original_Incident.ProductCode);
//            updateCommand.Parameters.AddWithValue("@OldTechID", original_Incident.TechID);
//            updateCommand.Parameters.AddWithValue("@OldDateOpened", original_Incident.DateOpened);
//            updateCommand.Parameters.AddWithValue("@OldDateClosed", original_Incident.DateClosed);
//            updateCommand.Parameters.AddWithValue("@OldTitle", original_Incident.Title);
//            updateCommand.Parameters.AddWithValue("@OldDescription", original_Incident.Description);
//            updateCommand.Parameters.AddWithValue("@NewCustomerID", incident.CustomerID);
//            updateCommand.Parameters.AddWithValue("@NewProductCode", incident.ProductCode);
//            updateCommand.Parameters.AddWithValue("@NewTechID", incident.TechID);
//            updateCommand.Parameters.AddWithValue("@NewDateOpened", incident.DateOpened);
//            updateCommand.Parameters.AddWithValue("@NewDateClosed", incident.DateClosed);
//            updateCommand.Parameters.AddWithValue("@NewTitle", incident.Title);
//            updateCommand.Parameters.AddWithValue("@NewDescription", incident.Description);

//            try
//            {
//                connection.Open();
//                int count = updateCommand.ExecuteNonQuery();
//                if (count == 1)
//                    successful = true;
//            }
//            catch(Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                //connection.Close();
//            }
//            return successful;
//        }

//        // Delete operation returns bool success flag
//        [DataObjectMethod(DataObjectMethodType.Delete)]
//        static public bool DeleteIncident(Incident incident)
//        {
//            bool successful = false;

//            SqlConnection connection = TechSupportDB.GetConnection();
//            string deleteString = "delete from incidents " +
//                                  "where " + // checking for optimistic concurrency
//                                  "CustomerID = @CustomerID and " +
//                                  "ProductCode = @ProductCode and " +
//                                  "TechID = @TechID and " +
//                                  "DateOpened = @DateOpened and " +
//                                  "DateClosed = @DateClosed and " +
//                                  "DateTitle = @DateTitle and " +
//                                  "Description = @Description";
//            SqlCommand deleteCommand = new SqlCommand(deleteString, connection);
//            deleteCommand.Parameters.AddWithValue("@CustomerID", incident.CustomerID);
//            deleteCommand.Parameters.AddWithValue("@ProductCode", incident.ProductCode);
//            deleteCommand.Parameters.AddWithValue("@TechID", incident.TechID);
//            deleteCommand.Parameters.AddWithValue("@DateOpened", incident.DateOpened);
//            deleteCommand.Parameters.AddWithValue("@DateClosed", incident.DateClosed);
//            deleteCommand.Parameters.AddWithValue("@Title", incident.Title);
//            deleteCommand.Parameters.AddWithValue("@Description", incident.Description);

//            try
//            {
//                connection.Open();
//                int count = deleteCommand.ExecuteNonQuery();
//                if (count == 1)
//                {
//                    successful = true;
//                }
//            }
//            catch(Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                connection.Close();
//            }
//            return successful;
//        }

//    } // end class
//} // end namespace
