using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_BrianLiang
{
    [DataObject(true)]  //providing an annotation to make it a target for an object data source

    public static class IncidentDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieves customer with given ID
        public static List<Incident> GetIncident(int technicianID)
        {
            List<Incident> incidents = new List<Incident>();
            Incident tech = null; // found customer
            // define connection
            SqlConnection connection = TechSupportDB.GetConnection();

            // define the select query command
            string selectQuery = "select InsidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                 "from Incidents " +
                                 "where TechID = @TechID";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@TechID", technicianID);
            try
            {
                // open the connection
                connection.Open();

                // execute the query
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result if any
                while (reader.Read()) // while there are matching technicians
                {
                    tech = new Incident();
                    tech.IncidentID = (int) reader["IncidentID"];
                    tech.CustomerID = (int) reader["CustomerID"];
                    tech.ProductCode = reader["Address"].ToString();
                    tech.TechID = reader["City"].ToString();
                    tech.DateOpened = reader["State"].ToString();
                    tech.DateClosed = reader["ZipCode"].ToString();
                    incidents.Add(tech);
                }
            }
            catch(Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close(); // close connecto no matter what
            }

            return incidents;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        // inserts new customer record
        public static int AddCustomer(Incident cust) // returns generated customer id
        {
            
        int custID = 0;
            // prepare connection
            SqlConnection connection = TechSupportDB.GetConnection();

            // prepare the statement
            string insertString = "insert into Customers " +
                                  "(Name, Address, City, State, ZipCode) " +
                                  "values(@Name, @Address, @City, @State, @ZipCode)";
            SqlCommand insertCommand = new SqlCommand(insertString, connection);
            insertCommand.Parameters.AddWithValue("@Name", cust.Name);
            insertCommand.Parameters.AddWithValue("@Address", cust.Address);
            insertCommand.Parameters.AddWithValue("@City", cust.City);
            insertCommand.Parameters.AddWithValue("@State", cust.State);
            insertCommand.Parameters.AddWithValue("@ZipCode", cust.ZipCode);

            try
            {
                // open connection
                connection.Open();

                // execute the statement
                int i = insertCommand.ExecuteNonQuery();
                if (i == 1) // one record inserted
                {
                    // retrieve customer id from the added record
                    string selectString = "select ident_current('Customers') " +
                                          "from Customers";
                    SqlCommand selectCommand = new SqlCommand(selectString, connection);
                    custID = Convert.ToInt32(selectCommand.ExecuteScalar()); // (int) does not work!!!
                }
            }
            catch (Exception ex)
            {
                throw ex; // pass the buck
            }
            finally
            {
                connection.Close();
            }
            return custID;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        // updates existing customer record and returns bool success flag
        public static bool UpdateCustomer(Incident original_customer, Incident customer)
        {
    
            bool successful = false;
            SqlConnection connection = TechSupportDB.GetConnection();
            string updateString = "update Customers set " +
                                  "Name = @NewName, " +
                                  "Address = @NewAddress, " +
                                  "City = @NewCity, " +
                                  "State = @NewState," +
                                  "ZipCode = @NewZipCode " +
                                  "where " + // update succeeds only if record not changed by other users
                                  "Name  = @OldName and " +
                                  "Address = @OldAddress and " +
                                  "City = @OldCity and " +
                                  "State = @OldState and " +
                                  "ZipCode = @OldZipCode";
            SqlCommand updateCommand = new SqlCommand(updateString, connection);
            updateCommand.Parameters.AddWithValue("@OldName", original_customer.Name);
            updateCommand.Parameters.AddWithValue("@OldAddress", original_customer.Address);
            updateCommand.Parameters.AddWithValue("@OldCity", original_customer.City);
            updateCommand.Parameters.AddWithValue("@OldState", original_customer.State);
            updateCommand.Parameters.AddWithValue("@OldZipCode", original_customer.ZipCode);
            updateCommand.Parameters.AddWithValue("@NewName", customer.Name);
            updateCommand.Parameters.AddWithValue("@NewAddress", customer.Address);
            updateCommand.Parameters.AddWithValue("@NewCity", customer.City);
            updateCommand.Parameters.AddWithValue("@NewState", customer.State);
            updateCommand.Parameters.AddWithValue("@NewZipCode", customer.ZipCode);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count == 1)
                    successful = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                //connection.Close();
            }
            return successful;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        // Delete operation returns bool success flag
        static public bool DeleteCustomer(Incident customer)
        {
            bool successful = false;

            SqlConnection connection = TechSupportDB.GetConnection();
            string deleteString = "delete from Customers " +
                                  "where " + // checking for optimistic concurrency
                                  "Name = @Name and " +
                                  "Address = @Address and " +
                                  "City = @City and " +
                                  "State = @State and " +
                                  "ZipCode = @Zipcode";
            SqlCommand deleteCommand = new SqlCommand(deleteString, connection);
            deleteCommand.Parameters.AddWithValue("@Name", customer.Name);
            deleteCommand.Parameters.AddWithValue("@Address", customer.Address);
            deleteCommand.Parameters.AddWithValue("@City", customer.City);
            deleteCommand.Parameters.AddWithValue("@State", customer.State);
            deleteCommand.Parameters.AddWithValue("@ZipCode", customer.ZipCode);

            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count == 1)
                {
                    successful = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return successful;
        }

    } // end class
} // end namespace

/*Notes: 
 * remember to build solution
 * states = technicians
 * customers = incidents
 * create an object data source draging over drop down or grid
 * Choose a method should show GetStates(), returns List<State>
 * displays and then name, and don't forget to enable autopost back
 * For Incidents, need to do select, update, insert, and delete
 * Payattention to the oldvalue parameter format in the parameters, as well as the typeName parameter
 */