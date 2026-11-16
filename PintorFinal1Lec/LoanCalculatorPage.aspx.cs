using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DataHelper.DBDataAccess;

namespace PintorFinal1Lec
{
    public partial class LoanCalculatorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Visitors who aren't logged in go to the login page instead of crashing.
            if (Session["Email"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            lblFirstName.Text = Session["FirstName"].ToString();
            lblLastName.Text = Session["LastName"].ToString();
            lblEmail.Text = Session["Email"].ToString();
            
            decimal salary = Convert.ToDecimal(Session["BasicMonthlySalary"]);
            lblBasicMonthlySalary.Text = salary.ToString("N2");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditModule.aspx");

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            int monthsToPay;
            if (!int.TryParse(txtMonths.Text.Trim(), out monthsToPay))
            {
                lblReminder.Text = "Please enter a valid number of months.";
                return;
            }

            
            if (Session["BasicMonthlySalary"] == null)
            {
                lblReminder.Text = "User salary data not found. Please register or log in again.";
                return;
            }

            double basicSalary;
            if (!double.TryParse(Session["BasicMonthlySalary"].ToString(), out basicSalary))
            {
                lblReminder.Text = "Stored salary is invalid.";
                return;
            }

            DBDataAccess myData = new DBDataAccess();
            myData.BasicMonthlySalary = basicSalary;

            LoanCalculationResult result = myData.CalculateLoan(monthsToPay);

            if (result.Interest == -1)
            {
                lblReminder.Text = "Number of months must be between 1 and 25.";
                return;
            }

          
            lblLoanAmount.Text = result.LoanAmount.ToString("N2");
            lblInterest.Text = result.Interest.ToString("N2");
            lblServiceCharge.Text = result.ServiceCharge.ToString("N2");
            lblTakeHomeLoan.Text = result.TakeHomeLoan.ToString("N2");
            lblMonthlyAmortization.Text = result.MonthlyAmortization.ToString("N2");
        }
    }
}