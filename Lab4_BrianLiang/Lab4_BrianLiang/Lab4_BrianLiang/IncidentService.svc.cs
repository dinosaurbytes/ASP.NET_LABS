using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab4_BrianLiang
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IncidentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IncidentService.svc or IncidentService.svc.cs at the Solution Explorer and start debugging.
    public class IncidentService : IIncidentService
    {
        public List<Incident> GetAllIncidents(int techID)
        {
            return IncidentsDB.GetIncidentByTechnician(techID);
        }
    }
}
