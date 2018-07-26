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
        // create proxy object for the WCF service
        IncidentServiceClient proxy =
            new IncidentServiceClient();
        Incident[] customerID;
        protected void Page_Load(object sender, EventArgs e)
        {
            // load the combo box
            customerID = proxy.GetCustomerID();
            Session["cIDs"] = customerID;
            ddlCustomerID.DataTextField = "CustomerID";
            ddlCustomerID.DataValueField = "CustomerID";
            ddlCustomerID.DataSource = customerID;

            ddlCustomerID.DataBind();
        }
    }
}
        
