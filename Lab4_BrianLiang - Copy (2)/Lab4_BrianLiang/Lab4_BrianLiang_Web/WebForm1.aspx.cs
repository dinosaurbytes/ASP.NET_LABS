//using Lab4_BrianLiang_Web.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4_BrianLiang_Web
{ }
//{
//    public partial class WebForm1 : System.Web.UI.Page
//    {
//        // create proxy object for the WCF service
//        IncidentServiceClient proxy =
//            new IncidentServiceClient();
//        Incident[] customerIDs;
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack) // first time
//            {
//                // load the combo box
//                customerIDs = proxy.GetCustomerID();
//                Session["cID"] = customerIDs;
//                ddlCustomerID.DataSource = customerIDs;
//                ddlCustomerID.DataBind();
//            }
//            else // retrieve from session
//            {
//                customerIDs = (Incident[])Session["cID"];
//            }
//            DisplayCustomerID(0);
//        }
//        // display details of the selected category
//        protected void ddlCustomerID_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            DisplayCustomerID(ddlCustomerID.SelectedIndex);
//        }

//        private void DisplayCustomerID(int index)
//        {
//            Incident cID = customerIDs[index]; // selected category


//        }
//    }
//}