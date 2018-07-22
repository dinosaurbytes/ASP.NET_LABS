using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Lab2 ASP.NET
 * Author: Brian Liang
 * 792783
 * Date: July 2018
 */

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       
        public static DateTime today = DateTime.Today;          //Todays date

        public static int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;     //days until next sat

        DateTime firstSaturday = today.AddDays(daysUntilSaturday);      //Next approaching Saturday
        DateTime secondSaturday = today.AddDays(daysUntilSaturday + 7); //The second approaching Saturday
        DateTime thirdSaturday = today.AddDays(daysUntilSaturday + 14); //The third approaching Saturday

        int firstSatCount;      //counter for first saturday votes
        int secondSatCount;     //counter for second saturday votes
        int thirdSatCount;      //counter for third saturday votes

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["countFrirstSat"] != null) // if it is in the application state
            {
                firstSatCount = (int)Application["countFirstSat"];      //first sat count
            }
            if (Application["countSecondSat"] != null) // if it is in the application state
            {
                firstSatCount = (int)Application["countSecondSat"];     //second sat count
            }
            if (Application["countThirdSat"] != null) // if it is in the application state
            {
                thirdSatCount = (int)Application["countThirdSat"];      //thir sat count
            }
        }


        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            

            //ref used to get the calender range:https://stackoverflow.com/questions/33126320/set-range-of-date-to-display-in-calendar
            //ref used to change the calendar color:https://forums.asp.net/t/1415259.aspx?Change+Calendar+Cell+Color+Based+on+Retrieved+Field+Value
            e.Day.IsSelectable = false;         //make dates unselectable
            e.Cell.ForeColor = System.Drawing.Color.Gray;       //change background to grey
            if (e.Day.Date == firstSaturday || e.Day.Date == secondSaturday || e.Day.Date == thirdSaturday)     //if dates are one of the three next saturdays
            {
                e.Day.IsSelectable = true;          //make that date selectable
                e.Cell.BackColor = System.Drawing.Color.Blue;       //change backcolor to blue
                e.Cell.ForeColor = System.Drawing.Color.White;      //change text color to white          
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Calendar.SelectedDate == firstSaturday)     //if date is equal to first sat
            {
                Application.Lock(); // lock before changing shared data
                if (Application["countFirstSat"] != null)
                    firstSatCount = (int)Application["countFirstSat"];
                firstSatCount++;        //increment counter
                Application["countFirstSat"] = firstSatCount; // add it to the application state
                Application.UnLock(); // release the lock
                Response.Redirect("Results.aspx");
            }
            else if (Calendar.SelectedDate == secondSaturday)       //if date is equal to second sat
            {
                Application.Lock(); // lock before changing shared data
                if (Application["countSecondSat"] != null)
                    secondSatCount = (int)Application["countSecondSat"];
                secondSatCount++;       //increment counter
                Application["countSecondSat"] = secondSatCount; // add it to the application state
                Application.UnLock(); // release the lock
                Response.Redirect("Results.aspx");
            }
            else if (Calendar.SelectedDate == thirdSaturday)        //if date is equal to third sat
            {
                Application.Lock(); // lock before changing shared data
                if (Application["countThirdSat"] != null)
                    thirdSatCount = (int)Application["countThirdSat"];
                thirdSatCount++;        //increment counter
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