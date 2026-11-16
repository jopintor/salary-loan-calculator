using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PintorFinal1Lec
{
    public partial class EditModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only the logged-in user can edit their own details.
            if (Session["Email"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                string email = Session["Email"].ToString();
                lblEmail.Text = email;

                DBDataAccess db = new DBDataAccess();
                bool found = db.GetUserByEmail(email);

                if (found)
                {
                    txteditFN.Text = db.FirstName;
                    txteditLN.Text = db.LastName;
                    txteditSalary.Text = db.BasicMonthlySalary.ToString("0.00");
                }
                else
                {
                    lblReminder.Text = "User not found. Please try again.";
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txteditFN.Text.Trim();
            string lastName = txteditLN.Text.Trim();
            string password = txteditPassword.Text.Trim(); // optional: blank keeps the current password
            string email = Session["Email"].ToString();

            double salary;
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                !double.TryParse(txteditSalary.Text.Trim(), out salary) || salary <= 0)
            {
                lblReminder.Text = "Please fill in all fields correctly.";
                return;
            }

            if (password.Length > 0 && password.Length < 8)
            {
                lblReminder.Text = "New password must be at least 8 characters.";
                return;
            }

            DBDataAccess db = new DBDataAccess();
            bool updated = db.UpdateUserDetails(firstName, lastName, email, salary, password);

            if (updated)
            {
                Session["FirstName"] = firstName;
                Session["LastName"] = lastName;
                Session["BasicMonthlySalary"] = salary;

                lblReminder.Text = "Details successfully updated.";
                lblReminder.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblReminder.Text = "Update failed. Please try again.";
                lblReminder.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}