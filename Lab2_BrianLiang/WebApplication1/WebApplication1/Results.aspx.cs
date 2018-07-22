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
        public static DateTime today = DateTime.Today;

        public static int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;

        DateTime firstSaturday = today.AddDays(daysUntilSaturday);
        DateTime secondSaturday = today.AddDays(daysUntilSaturday + 7);
        DateTime thirdSaturday = today.AddDays(daysUntilSaturday + 14);


        int firstSatCount;
        int secondSatCount;
        int thirdSatCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page previous = Page.PreviousPage;      //static property which keeps track of where the page came from
            
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;

            DateTime nextSaturday = today.AddDays(daysUntilSaturday);
            DateTime secondSaturday = today.AddDays(daysUntilSaturday + 7);
            DateTime thirdSaturday = today.AddDays(daysUntilSaturday + 14);
            lblNextSaturday.Text = nextSaturday.ToLongDateString();
            lblSecondSaturday.Text = secondSaturday.ToLongDateString();
            lblThridSaturday.Text = thirdSaturday.ToLongDateString();

            //session state counter


            if (Application["countFirstSat"] != null) // if it is in the application state
            {
                firstSatCount = (int)Application["countFirstSat"];
            }
            txtFirstSatCount.Text = firstSatCount.ToString();
            if (Application["countSecondSat"] != null) // if it is in the application state
            {
                secondSatCount = (int)Application["countSecondSat"];
            }
            txtSecondSatCount.Text = secondSatCount.ToString();
            if (Application["countThirdSat"] != null) // if it is in the application state
            {
                thirdSatCount = (int)Application["countThirdSat"];
            }
            txtThirdSatCount.Text = thirdSatCount.ToString();


            
            


        }
    }
}