using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using DataHelper;

namespace PintorFinal1Lec
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DBDataAccess myData = new DBDataAccess();
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string salaryText = txtBasicMonthlySalary.Text.Trim();

            if (firstName == "" || lastName == "" || email == "" || password == "" || salaryText == "")
            {
                lblReminder.Text = "All fields are required.";
                return;
            }

          
            if (password.Length < 8)
            {
                lblReminder.Text = "Password must be at least 8 characters.";
                return;
            }

            decimal basicSalary;
            if (!decimal.TryParse(salaryText, out basicSalary) || basicSalary <= 0)
            {
                lblReminder.Text = "Basic monthly salary must be a valid positive number.";
                return;
            }

            if (myData.EmailExists(email))
            {
                lblReminder.Text = "An account with this email already exists. Please log in.";
                return;
            }

            double salaryDouble = (double)basicSalary;
            myData.SaveNewRecord(
                LastName: lastName,
                FirstName: firstName,
                BasicMonthlySalary: salaryDouble,
                Email: email,
                Password:password
            );
   
            Response.Redirect("Login.aspx");

        }
    }
}