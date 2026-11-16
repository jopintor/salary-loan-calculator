using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataHelper
{
    public class DBDataAccess
    {
        // Read from Web.config so the app runs from any folder; |DataDirectory| resolves to App_Data.
        static string myConnStr = ConfigurationManager.ConnectionStrings["Database1"] != null
            ? ConfigurationManager.ConnectionStrings["Database1"].ConnectionString
            : @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        SqlConnection myConn = new SqlConnection(myConnStr);

        string lastName, firstName, email, password;
        double basicMonthlySalary;

        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public double BasicMonthlySalary { get => basicMonthlySalary; set => basicMonthlySalary = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public void SaveNewRecord(string LastName, string FirstName, string Email, double BasicMonthlySalary, string Password)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("SaveNewRecord", myConn);
            saveCmd.CommandType = CommandType.StoredProcedure;

            saveCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
            saveCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
            saveCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
            saveCmd.Parameters.Add("@BasicMonthlySalary", SqlDbType.Float).Value = BasicMonthlySalary;
            saveCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = PasswordHasher.Hash(Password);

            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }
        public LoanCalculationResult CalculateLoan(int monthsToPay)
        {
            double interestRate = GetInterestRate(monthsToPay);
            if (interestRate == -1)
            {
                return new LoanCalculationResult { Interest = -1 };
            }

            double loanAmount = BasicMonthlySalary * 2.5;
            double interest = loanAmount * monthsToPay * interestRate;
            double serviceCharge = loanAmount * 0.02;
            double takeHomeLoan = loanAmount - (interest + serviceCharge);
            double monthlyAmortization = loanAmount / monthsToPay;

            return new LoanCalculationResult
            {
                LoanAmount = Math.Round(loanAmount, 2),
                Interest = Math.Round(interest, 2),
                ServiceCharge = Math.Round(serviceCharge, 2),
                TakeHomeLoan = Math.Round(takeHomeLoan, 2),
                MonthlyAmortization = Math.Round(monthlyAmortization, 2)
            };

        }
        public double GetInterestRate(int months)
        {
            if (months >= 1 && months <= 5)
                return 0.0062;
            else if (months >= 6 && months <= 10)
                return 0.0065;
            else if (months >= 11 && months <= 15)
                return 0.0068;
            else if (months >= 16 && months <= 20)
                return 0.0075;
            else if (months >= 21 && months <= 25)
                return 0.0080;
            else
                return -1;
        }
        public class LoanCalculationResult
        {
            public double LoanAmount { get; set; }
            public double Interest { get; set; }
            public double ServiceCharge { get; set; }
            public double TakeHomeLoan { get; set; }
            public double MonthlyAmortization { get; set; }
        }
        /// <summary>
        /// Looks the user up by email and checks the password against the stored hash.
        /// Accounts that still hold a plain-text password are upgraded to a hash on
        /// their first successful login.
        /// </summary>
        public bool CheckUserAccount(string email, string password)
        {
            if (!GetUserByEmail(email)) return false;
            if (!PasswordHasher.Verify(password, Password)) return false;

            if (!PasswordHasher.IsHashed(Password))
            {
                SaveUserRow(FirstName, LastName, Email, BasicMonthlySalary, PasswordHasher.Hash(password));
            }

            Password = null; // don't keep the stored hash around in memory
            return true;
        }

        public bool EmailExists(string email)
        {
            return new DBDataAccess().GetUserByEmail(email);
        }

        /// <summary>
        /// Updates a user's details. Leave newPassword empty to keep the current password.
        /// </summary>
        public bool UpdateUserDetails(string firstName, string lastName, string email, double salary, string newPassword)
        {
            try
            {
                string storedPassword;
                if (string.IsNullOrEmpty(newPassword))
                {
                    if (!GetUserByEmail(email)) return false;
                    storedPassword = Password;
                }
                else
                {
                    storedPassword = PasswordHasher.Hash(newPassword);
                }

                return SaveUserRow(firstName, lastName, email, salary, storedPassword);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool SaveUserRow(string firstName, string lastName, string email, double salary, string storedPassword)
        {
            try
            {
                myConn.Open();
                SqlCommand cmd = new SqlCommand("UpdateUserDetails", myConn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@BasicMonthlySalary", salary);
                cmd.Parameters.AddWithValue("@Password", storedPassword);
                cmd.Parameters.AddWithValue("@Email", email);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                myConn.Close();
            }
        }
        public bool GetUserByEmail(string email)
        {
            try
            {
                myConn.Open();
                SqlCommand cmd = new SqlCommand("GetUserByEmail", myConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    FirstName = dr["FirstName"].ToString();
                    LastName = dr["LastName"].ToString();
                    Email = dr["Email"].ToString();
                    BasicMonthlySalary = Convert.ToDouble(dr["BasicMonthlySalary"]);
                    Password = dr["Password"].ToString();
                    return true;
                }

                return false;
            }
            finally
            {
                myConn.Close();
            }
        }
    }
}

