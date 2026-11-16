using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PintorFinal1Lec
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblReminder.Text = "Please enter both Email and Password.";
                return;
            }

            DBDataAccess db = new DBDataAccess();
            bool isValidUser = db.CheckUserAccount(email, password);

            if (isValidUser)
            {

                Session["FirstName"] = db.FirstName;
                Session["LastName"] = db.LastName;
                Session["Email"] = db.Email;
                Session["BasicMonthlySalary"] = db.BasicMonthlySalary;

                Response.Redirect("LoanCalculatorPage.aspx");
            }
            else
            {
                lblReminder.Text = "Invalid email or password. Please try again.";
            }
        }
    }
}