using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_BrianLiang
{
    public class Incident
    {
        public Incident() { }

        public int IncidentID { get; set; }

        public int CustomerID { get; set; }

        public string ProductCode { get; set; }

        public int TechID { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime DateClosed { get; set; }
    }
}
