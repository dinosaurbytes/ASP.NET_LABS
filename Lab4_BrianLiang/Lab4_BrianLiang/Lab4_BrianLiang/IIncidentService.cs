using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab4_BrianLiang
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIncidentService" in both code and config file together.
    [ServiceContract]
    public interface IIncidentService
    {
        [OperationContract]
        void DoWork();
    }
}
