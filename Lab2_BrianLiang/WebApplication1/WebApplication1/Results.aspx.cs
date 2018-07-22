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
    public partial class Results : System.Web.UI.Page
    {
        public static DateTime today = DateTime.Today;          //Figure out todays date

        public static int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;     //Calculate days till next saturday

        DateTime firstSaturday = today.AddDays(daysUntilSaturday);      //Next approaching Saturday
        DateTime secondSaturday = today.AddDays(daysUntilSaturday + 7); //The second approaching Saturday
        DateTime thirdSaturday = today.AddDays(daysUntilSaturday + 14); //The third approaching Saturday

        int firstSatCount;      //counter for first saturday votes
        int secondSatCount;     //counter for second saturday votes
        int thirdSatCount;      //counter for third saturday votes

        protected void Page_Load(object sender, EventArgs e)
        {
            Page previous = Page.PreviousPage;      //static property which keeps track of where the page came from
            
            lblNextSaturday.Text = firstSaturday.ToLongDateString();        //populate label with first sat date
            lblSecondSaturday.Text = secondSaturday.ToLongDateString();     //populate label with second sat date
            lblThridSaturday.Text = thirdSaturday.ToLongDateString();       //populate label with thrid sat date
            
            //Session state
            if (Application["countFirstSat"] != null) // if it is in the application state
            {
                firstSatCount = (int)Application["countFirstSat"];      //first sat count
            }
            txtFirstSatCount.Text = firstSatCount.ToString();           //populate first sat txt count
            if (Application["countSecondSat"] != null) // if it is in the application state
            {
                secondSatCount = (int)Application["countSecondSat"];    //second sat count
            }
            txtSecondSatCount.Text = secondSatCount.ToString();         //populate second sat txt count
            if (Application["countThirdSat"] != null) // if it is in the application state
            {
                thirdSatCount = (int)Application["countThirdSat"];      //third sat count
            }
            txtThirdSatCount.Text = thirdSatCount.ToString();           //populate third sat count
            
        }
    }
}