using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//celsius fahrenheit kelvin

namespace Lab1_BrianLiang
{
    public partial class TemperatureConvertor : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        const decimal CON_FACTOR_FROM_FAHRENHEIT = 5/9m;     //converstion factor calculating to fahrenheit     
        const decimal CON_FACTOR_TO_FAHRENHEIT = 9/5m;       //conversion factor calculating from fahrenheit
        const decimal ABSOLUTE_ZERO_F = 32;        //32F is absolute zero in K
        const decimal ABSOLUTE_ZERO_C= 273.15m;     //273.15C is absolute zero in K



        protected void ddlFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            decimal input = Convert.ToDecimal(txtInput.Text);
            decimal output = 0;

            if (ddlFrom.Text == "Celsius" && ddlTo.Text == "Fahrenheit")
            {
                output = (input * 9 / 5) + ABSOLUTE_ZERO_F;
                txtOutput.Text = output.ToString("F2");
            }
            else if (ddlFrom.Text == "Celsius" && ddlTo.Text == "Kelvin")
            {
                output = input + ABSOLUTE_ZERO_C;
                txtOutput.Text = output.ToString("F2");
            }
            else if (ddlFrom.Text == "Fahrenheit" && ddlTo.Text == "Celsius")
            {
                output = (input - ABSOLUTE_ZERO_F) * CON_FACTOR_FROM_FAHRENHEIT;     //(F - 32) * 5/9
                txtOutput.Text = output.ToString("F2");
            }
            else if (ddlFrom.Text == "Fahrenheit" && ddlTo.Text == "Kelvin")
            {
                output = (input - ABSOLUTE_ZERO_F) * CON_FACTOR_FROM_FAHRENHEIT + ABSOLUTE_ZERO_C;               //(F - 32) * 5/9 + 273.15
                txtOutput.Text = output.ToString("F2");
            }
            else if (ddlFrom.Text == "Kelvin" && ddlTo.Text == "Celsius")
            {
                output = input - ABSOLUTE_ZERO_C;         //K - 273.15
                txtOutput.Text = output.ToString("F2");
            }
            else if (ddlFrom.Text == "Kelvin" && ddlTo.Text == "Fahrenheit")
            {
                output = (input - ABSOLUTE_ZERO_C) * CON_FACTOR_TO_FAHRENHEIT + ABSOLUTE_ZERO_F;                   //(K - 273.15) * 9/5 + 32
                txtOutput.Text = output.ToString("F2");
            }
            else
            {
                output = Convert.ToDecimal(txtInput.Text);
                txtOutput.Text = output.ToString("F2");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
            txtInput.Focus();
            
        }
    }
}