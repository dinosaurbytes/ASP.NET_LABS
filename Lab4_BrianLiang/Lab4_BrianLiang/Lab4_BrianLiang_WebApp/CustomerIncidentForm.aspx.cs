using Lab4_BrianLiang_WebApp.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4_BrianLiang_WebApp
{
    public partial class CustomerIncidentForm : System.Web.UI.Page
    {
        IncidentServiceClient proxy = new IncidentServiceClient(); // create proxy object for the WCF service

        Incident[] customerID;          //array of customerID's
        Incident[] customerIncidents;   //array of customer incidents

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // first time
            {
            // load the combo box
            customerID = proxy.GetCustomerID();
            Session["cIDs"] = customerID;
            //ddlCustomerID.DataTextField = "CustomerID";   //not necessary as we cause use the value    
            ddlCustomerID.DataValueField = "CustomerID";
            ddlCustomerID.DataSource = customerID;          //setting the datasource of customerID to the drop down
            ddlCustomerID.DataBind();           //databinding the drop down list
            }
            else // retrieve from session
            {
                customerID = (Incident[])Session["cIDs"];
            }

            customerIncidents = proxy.GetAllCustIncidents(Convert.ToInt32(ddlCustomerID.Text));     //useing the text value in dropdown list for the customerID

            gvCustomerIncidents.DataSource = customerIncidents;     //setting the datasource for customerIncident to the dropdown
            gvCustomerIncidents.DataBind();     //databinding the dropdown list
            
        }
    }
}
        
