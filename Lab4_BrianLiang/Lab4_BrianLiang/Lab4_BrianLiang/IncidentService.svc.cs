using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab4_BrianLiang
{
    [ServiceContract]
    public interface IncidentService
    {
        [OperationContract]
        List<Incident> GetIncidentByTechnician(int techID);
        
    }

    [DataContract]
    public class Incident
    {
        [DataMember]
        public int IncidentID { get; set; }     //incidentID getter setter
        [DataMember]
        public int CustomerID { get; set; }     //customerID getter setter
        [DataMember]
        public string ProductCode { get; set; } //productCode getter setter
        [DataMember]
        public int? TechID { get; set; }        //techID getter setter
        [DataMember]
        public DateTime DateOpened { get; set; }    //DateOpened getter setter
        [DataMember]
        public DateTime? DateClosed { get; set; }   //DateClosed getter setter
        [DataMember]
        public string Title { get; set; }       //Title getter setter
        [DataMember]
        public string Description { get; set; }     //Description getter setter
        [DataMember]
        public string Name { get; set; }            //Customer name from inner join of customer table
    }
    
    
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IncidentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IncidentService.svc or IncidentService.svc.cs at the Solution Explorer and start debugging.
    //public class IncidentService : IIncidentService
    //{
    //    public void DoWork()
    //    {
    //    }
    //}
}
