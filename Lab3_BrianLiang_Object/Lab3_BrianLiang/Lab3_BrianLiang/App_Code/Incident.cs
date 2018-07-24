using System;
using System.Collections.Generic;
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
    public class Incident
    {
        public Incident() { }                   //incident constructor

        public int IncidentID { get; set; }     //incidentID getter setter

        public int CustomerID { get; set; }     //customerID getter setter

        public string ProductCode { get; set; } //productCode getter setter

        public int? TechID { get; set; }        //techID getter setter

        public DateTime DateOpened { get; set; }    //DateOpened getter setter

        public DateTime? DateClosed { get; set; }   //DateClosed getter setter

        public string Title { get; set; }       //Title getter setter

        public string Description { get; set; }     //Description getter setter

        public string Name { get; set; }            //Customer name from inner join of customer table
    }
}
