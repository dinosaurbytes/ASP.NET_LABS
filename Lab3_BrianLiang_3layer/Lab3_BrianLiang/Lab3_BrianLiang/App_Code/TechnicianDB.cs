using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_BrianLiang
{
    [DataObject(true)]  //providing an annotation to make it a target for an object data source

    public static class TechnicianDB
    {   


        //[DataObjectMethod(DataObjectMethodType.Select)]
        //public static List<Technician> GetTechnicians()
        //{
        //    List<Technician> states = new List<Technician>(); // make an empty list
        //    Technician tech; // reference to new state object
        //    // create connection
        //    SqlConnection connection = TechSupportDB.GetConnection();

        //    // create select command
        //    string selectString = "select TechID, Name from Technicians " +
        //                          "order by Name";
        //    SqlCommand selectCommand = new SqlCommand(selectString, connection);
        //    try
        //    {
        //        // open connection
        //        connection.Open();
        //        // run the select command and process the results adding states to the list
        //        SqlDataReader reader = selectCommand.ExecuteReader();
        //        while(reader.Read())// process next row
        //        {
        //            tech = new Technician();
        //            tech.TechID = (int) reader["TechID"];
        //            tech.Name = reader["Name"].ToString();
        //            states.Add(tech);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex; // throw it to the form to handle
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return states;
        //}

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Technician> GetTechnician()
        {
            List<Technician> technicians = new List<Technician>(); // make an empty list
            Technician tech; // reference to new state object
            // create connection
            SqlConnection connection = TechSupportDB.GetConnection();

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
                while (reader.Read())// process next row
                {
                    tech = new Technician();
                    tech.TechID = (int) reader["TechID"];
                    tech.Name = reader["StateName"].ToString();
                    technicians.Add(tech);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex; // throw it to the form to handle
            }
            finally
            {
                connection.Close();
            }
            return technicians;
        }
    }
}
