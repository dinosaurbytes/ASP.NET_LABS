using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
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
            if (Application["countFrirstSat"] != null) // if it is in the application state
            {
                firstSatCount = (int)Application["countFirstSat"];
            }
            if (Application["countSecondSat"] != null) // if it is in the application state
            {
                firstSatCount = (int)Application["countSecondSat"];
            }
            if (Application["countThirdSat"] != null) // if it is in the application state
            {
                thirdSatCount = (int)Application["countThirdSat"];
            }
        }


        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;

            DateTime nextSaturday = today.AddDays(daysUntilSaturday);
            DateTime secondSaturday = today.AddDays(daysUntilSaturday + 7);
            DateTime thirdSaturday = today.AddDays(daysUntilSaturday + 14);


            //ref used to get the calender range:https://stackoverflow.com/questions/33126320/set-range-of-date-to-display-in-calendar
            //ref used to change the calendar color:https://forums.asp.net/t/1415259.aspx?Change+Calendar+Cell+Color+Based+on+Retrieved+Field+Value
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
            if (e.Day.Date == nextSaturday || e.Day.Date == secondSaturday || e.Day.Date == thirdSaturday)
            {
                e.Day.IsSelectable = true;
                e.Cell.BackColor = System.Drawing.Color.Blue;
                e.Cell.ForeColor = System.Drawing.Color.White;                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Calendar.SelectedDate == firstSaturday)
            {
                Application.Lock(); // lock before changing shared data
                if (Application["countFirstSat"] != null)
                    firstSatCount = (int)Application["countFirstSat"];
                firstSatCount++;
                Application["countFirstSat"] = firstSatCount; // add it to the application state
                Application.UnLock(); // release the lock
                Response.Redirect("Results.aspx");
            }
            else if (Calendar.SelectedDate == secondSaturday)
            {
                Application.Lock(); // lock before changing shared data
                if (Application["countSecondSat"] != null)
                    secondSatCount = (int)Application["countSecondSat"];
                secondSatCount++;
                Application["countSecondSat"] = secondSatCount; // add it to the application state
                Application.UnLock(); // release the lock
                Response.Redirect("Results.aspx");
            }
            else if (Calendar.SelectedDate == thirdSaturday)
            {
                Application.Lock(); // lock before changing shared data
                if (Application["countThirdSat"] != null)
                    thirdSatCount = (int)Application["countThirdSat"];
                thirdSatCount++;
                Application["countThirdSat"] = thirdSatCount; // add it to the application state
                Application.UnLock(); // release the lock   
                Response.Redirect("Results.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a date before voting.');</script>");
            }
        }
    }
}