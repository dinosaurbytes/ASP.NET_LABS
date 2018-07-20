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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

      
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;

            DateTime nextSaturday = today.AddDays(daysUntilSaturday);
            DateTime secondSaturday = today.AddDays(daysUntilSaturday + 7);
            DateTime thirdSaturday = today.AddDays(daysUntilSaturday + 14);
            txtInput.Text = Convert.ToString(daysUntilSaturday);
        }
    }
}