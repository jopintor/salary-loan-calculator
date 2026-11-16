<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PintorFinal1Lec.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        text-align: left;
        font-family: Arial, Helvetica, sans-serif;
        color: #EE8E00;
    }
    .auto-style4 {
        width: 100%;
    }
    .auto-style5 {
        width: 179px;
        font-size: small;
    }
    .auto-style6 {
        width: 179px;
        color: #666666;
        height: 27px;
        font-size: small;
    }
    .auto-style8 {
        height: 27px;
    }
    .auto-style9 {
        width: 179px;
        color: #666666;
        font-size: small;
    }
    .auto-style10 {
        color: #666666;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style3">
        <strong>Registration</strong><table class="auto-style4">
            <tr>
                <td class="auto-style6">First Name</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Last Name</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Basic Monthly Salary</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtBasicMonthlySalary" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Email Address</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Password</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Label ID="lblReminder" runat="server" CssClass="auto-style10"></asp:Label>
                </td>
            </tr>
        </table>
</div>
</asp:Content>
