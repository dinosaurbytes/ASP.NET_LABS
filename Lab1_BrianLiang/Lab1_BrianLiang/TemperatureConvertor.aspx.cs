using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Lab1_BrianLiang
{
    public partial class TemperatureConvertor : System.Web.UI.Page
    {
        
        const decimal CON_FACTOR_FROM_FAHRENHEIT = 5/9m;     //converstion factor calculating to fahrenheit     
        const decimal CON_FACTOR_TO_FAHRENHEIT = 9/5m;       //conversion factor calculating from fahrenheit
        const decimal ABSOLUTE_ZERO_F = 32;        //32F is absolute zero in K
        const decimal ABSOLUTE_ZERO_C= 273.15m;     //273.15C is absolute zero in K



        protected void ddlFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            decimal input = Convert.ToDecimal(txtInput.Text);       //sets the txtInput value to the variable input
            decimal output = 0;                 //output variable set to zero to start

            if (ddlFrom.Text == "Celsius" && ddlTo.Text == "Fahrenheit")        //dropdown celsius and fahrenheit
            {
                output = (input * 9 / 5) + ABSOLUTE_ZERO_F;     //converts celsius to fahrenheit
                txtOutput.Text = output.ToString("F2");         //displays fahrenheit
            }
            else if (ddlFrom.Text == "Celsius" && ddlTo.Text == "Kelvin")       //dropdown celsius to kelvin
            {
                output = input + ABSOLUTE_ZERO_C;               //converts celsius to kelvin
                txtOutput.Text = output.ToString("F2");         //displays kelvin
            }
            else if (ddlFrom.Text == "Fahrenheit" && ddlTo.Text == "Celsius")   //dropdown fahrenheit to celsius
            {
                output = (input - ABSOLUTE_ZERO_F) * CON_FACTOR_FROM_FAHRENHEIT;     //(F - 32) * 5/9
                txtOutput.Text = output.ToString("F2");         //displays celsius
            }
            else if (ddlFrom.Text == "Fahrenheit" && ddlTo.Text == "Kelvin")    //dropdown fahrenheit to kelvin
            {
                output = (input - ABSOLUTE_ZERO_F) * CON_FACTOR_FROM_FAHRENHEIT + ABSOLUTE_ZERO_C;               //(F - 32) * 5/9 + 273.15
                txtOutput.Text = output.ToString("F2");         //displays kelvin
            }
            else if (ddlFrom.Text == "Kelvin" && ddlTo.Text == "Celsius")       //dropdown kelivn to celsius
            {
                output = input - ABSOLUTE_ZERO_C;         //K - 273.15
                txtOutput.Text = output.ToString("F2");   //diplays celsius
            }
            else if (ddlFrom.Text == "Kelvin" && ddlTo.Text == "Fahrenheit")    //dropwon kelivn to fahrenheit
            {
                output = (input - ABSOLUTE_ZERO_C) * CON_FACTOR_TO_FAHRENHEIT + ABSOLUTE_ZERO_F;                   //(K - 273.15) * 9/5 + 32
                txtOutput.Text = output.ToString("F2");     //displays fahrenheit
            }
            else
            {           //if the input drop down is the same as the output dropdown
                output = Convert.ToDecimal(txtInput.Text);
                txtOutput.Text = output.ToString("F2");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";         //clears input textbox
            txtOutput.Text = "";        //clears output text box
            txtInput.Focus();           //focus on input text field
            ddlFrom.Text = "Celsius";   //resets the dropdown box
            ddlTo.Text = "Fahrenheit";  //resets the dropdown box
        }
    }
}
