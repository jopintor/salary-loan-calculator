<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="LoanCalculatorPage.aspx.cs" Inherits="PintorFinal1Lec.LoanCalculatorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        text-align: left;
    }
    .auto-style4 {
        width: 100%;
    }
    .auto-style5 {
        width: 191px;
    }
    .auto-style6 {
        width: 191px;
        height: 35px;
    }
    .auto-style7 {
        height: 35px;
    }
    .auto-style8 {
        width: 191px;
        height: 33px;
    }
    .auto-style9 {
        height: 33px;
    }
    .auto-style10 {
        width: 191px;
        height: 26px;
    }
    .auto-style11 {
        height: 26px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style3">
    <strong>Loan Calculator Page</strong><table class="auto-style4">
        <tr>
            <td class="auto-style5"><strong>User Info</strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">First Name:</td>
            <td class="auto-style7">
                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Last Name:</td>
            <td>
                <asp:Label ID="lblLastName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Basic Monthly Salary:</td>
            <td>
                <asp:Label ID="lblBasicMonthlySalary" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Email Address:</td>
            <td class="auto-style11">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style9">
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit Info" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">No. of Months to Pay:</td>
            <td class="auto-style9">
                <asp:TextBox ID="txtMonths" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCalculate" runat="server" Height="24px" OnClick="btnCalculate_Click" Text="Calculate" Width="80px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style9">
                <asp:Label ID="lblReminder" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"><strong>Loan Details</strong></td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style8">Loan Amount</td>
            <td class="auto-style9">
                <asp:Label ID="lblLoanAmount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Interest</td>
            <td class="auto-style9">
                <asp:Label ID="lblInterest" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Take Home Loan</td>
            <td class="auto-style9">
                <asp:Label ID="lblTakeHomeLoan" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Service Charge</td>
            <td class="auto-style9">
                <asp:Label ID="lblServiceCharge" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Monthly Amortization</td>
            <td class="auto-style9">
                <asp:Label ID="lblMonthlyAmortization" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
