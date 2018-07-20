using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Results : System.Web.UI.Page
    {
        int firstSatCounter;        //local variable on teh form not preserved
        int secondSatCounter;
        int thirdSatCounter;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page previous = Page.PreviousPage;      //static property which keeps track of where the page came from
            if(previous != null)
            {
                TextBox tb = (TextBox)previous.FindControl("txtInput");    //text box from previous page
                lblResults.Text = tb.Text;     //copy text from this text box into the label on this page
            }


            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;

            DateTime nextSaturday = today.AddDays(daysUntilSaturday);
            DateTime secondSaturday = today.AddDays(daysUntilSaturday + 7);
            DateTime thirdSaturday = today.AddDays(daysUntilSaturday + 14);
            lblNextSaturday.Text = nextSaturday.ToLongDateString();
            lblSecondSaturday.Text = secondSaturday.ToLongDateString();
            lblThridSaturday.Text = thirdSaturday.ToLongDateString(); 

            //session state counter

            if(Session["count"] != null)
            {
                firstSatCounter = (int)Session["count"];

            }
            


        }
    }
}