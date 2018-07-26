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
        Incident[] customerIncidents;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // first time
            {
            // load the combo box
            customerID = proxy.GetCustomerID();
            Session["cIDs"] = customerID;
            ddlCustomerID.DataTextField = "CustomerID";
            ddlCustomerID.DataValueField = "CustomerID";
            ddlCustomerID.DataSource = customerID;
            ddlCustomerID.DataBind();
            }
            else // retrieve from session
            {
                customerID = (Incident[])Session["cIDs"];
            }

            customerIncidents = proxy.GetAllCustIncidents(Convert.ToInt32(ddlCustomerID.Text));

            gvCustomerIncidents.DataSource = customerIncidents;
            gvCustomerIncidents.DataBind();

            //dvCustomerIncidents.DataSource = customerIncidents;
            //dvCustomerIncidents.DataBind();
            




        }


    }
}
        
