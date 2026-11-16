# Salary Loan Calculator – ASP.NET Web Forms

A web app where employees register with their monthly salary, log in and work out a salary loan: how much they can borrow, the interest, service charge, take-home amount and monthly payment for a term of 1–25 months.

Built with **C#, ASP.NET Web Forms (.NET Framework 4.7.2) and SQL Server LocalDB**.

> Individual project for an application development course (BIT, 2nd year, 2025).

<!-- Add screenshots here, e.g. ![Loan calculator](docs/screenshots/calculator.png) -->

## Features

- **Accounts:** register, log in and edit your profile (name, salary and an optional new password). Duplicate emails and passwords under 8 characters are rejected.
- **Loan calculation** based on the user's stored salary:

  | Item | Rule |
  |---|---|
  | Loan amount | 2.5 × basic monthly salary |
  | Interest | loan amount × months × monthly rate |
  | Monthly rate | 0.62% (1–5 months), 0.65% (6–10), 0.68% (11–15), 0.75% (16–20), 0.80% (21–25) |
  | Service charge | 2% of the loan amount |
  | Take-home loan | loan amount − interest − service charge |
  | Monthly amortization | loan amount ÷ months |

- **Input checks** on every form: required fields, numeric salary and term, and the 1–25 month range.

**Under the hood**
- **Layered design:** the web project (`PintorFinal1Lec`) uses a separate class library (`DataAccess`, assembly `DataHelper`) for all database work and the loan logic.
- **Stored procedures with typed parameters** for every query, which prevents SQL injection.
- **Password security:** passwords are stored as salted **PBKDF2-SHA256** hashes (`DataAccess/PasswordHasher.cs`). Older plain-text accounts are upgraded the first time they log in.
- **Session-based access:** the calculator and profile pages require a login, and users can only edit their own account.

## Project structure

```
PintorFinal1Lec.sln
├── DataAccess/            Class library: database calls, loan calculation, password hashing
│   ├── DBDataAccess.cs
│   └── PasswordHasher.cs
└── PintorFinal1Lec/       ASP.NET Web Forms site
    ├── Registration.aspx, Login.aspx
    ├── LoanCalculatorPage.aspx   Loan calculation
    ├── EditModule.aspx           Edit profile
    └── App_Data/Database1.mdf    SQL Server LocalDB database
```

## Running it locally

**Requirements:** Windows, Visual Studio 2022 with the *ASP.NET and web development* workload (includes IIS Express and SQL Server Express LocalDB).

1. Clone the repository and open `PintorFinal1Lec.sln`.
2. Set `PintorFinal1Lec` as the startup project.
3. Press **F5**, register an account, and log in.

> **Note:** the database file (`App_Data/Database1.mdf`) is not included in this repository because it held real user data from the class project. The app expects a LocalDB database with a users table and the stored procedures that `DataAccess/DBDataAccess.cs` calls (`SaveNewRecord`, `GetUserByEmail`, `UpdateUserDetails`), connected through the `Database1` connection string in `Web.config`.

## Tech stack

C# · ASP.NET Web Forms · .NET Framework 4.7.2 · SQL Server LocalDB · T-SQL stored procedures · HTML/CSS
