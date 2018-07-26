
using Lbar4_BrianLiang_WebClient.CustomerWebClientServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lbar4_BrianLiang_WebClient
{
    public partial class CustomerWebForm : System.Web.UI.Page
    {
        // create proxy object for the WCF service
        IncidentServiceClient proxy = new IncidentServiceClient();
        Incident[] customerID;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) // first time
            {
                // load the combo box with customerID
                customerID = proxy.GetCustomerID();
                //    Session["cats"] = categories;
                //    ddlCategories.DataSource = categories;
                //    ddlCategories.DataTextField = "LongName";
                //    ddlCategories.DataValueField = "CategoryID";
                //    ddlCategories.DataBind();
                //}
                //else // retrieve from session
                //{
                //    categories = (Category[])Session["cats"];
                //}
                //DisplayCategory(0);
            }

 
        }
    }

