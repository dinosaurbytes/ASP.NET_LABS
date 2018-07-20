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
        DateTime today = DateTime.Today;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            //Calendar.VisibleDate = new DateTime();
        }




        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;

            DateTime nextSaturday = today.AddDays(daysUntilSaturday);
            DateTime secondSaturday = today.AddDays(daysUntilSaturday + 7);
            DateTime thirdSaturday = today.AddDays(daysUntilSaturday + 14);

            //DateTime rangeStart = new DateTime(2015, 7, 4);
            //DateTime rangeEnd = new DateTime(2016, 3, 15);

            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
            if (e.Day.Date == nextSaturday || e.Day.Date == secondSaturday || e.Day.Date == thirdSaturday)
            {
                e.Day.IsSelectable = true;
                e.Cell.BackColor = System.Drawing.Color.Blue;
                e.Cell.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}