using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

/*
 * Lab4 ASP.NET
 * Author: Brian Liang
 * Date: July 2018
 */


namespace Lab4_BrianLiang
{
    
    public class IncidentService : IIncidentService
    {
        public List<Incident> GetAllIncidents(int techID)           //GetAllIncidents Service
        {
            return IncidentsDB.GetIncidentByTechnician(techID);
        }
        public List<Incident> GetAllCustIncidents(int custID)       //GetAllCustIncidents Service
        {
            return IncidentsDB.GetIncidentByCustomer(custID);
        }
        public List<Incident> GetCustomerID()                       //GetCustomerID service
        {
            return IncidentsDB.GetCustomerID();
        }
    }
}
