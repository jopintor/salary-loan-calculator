<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PintorFinal1Lec.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style2 {
        text-align: left;
    }
    .auto-style3 {
        width: 100%;
    }
    .auto-style4 {
        width: 164px;
    }
    .auto-style5 {
        width: 164px;
        height: 26px;
    }
    .auto-style6 {
        height: 26px;
    }
    .auto-style7 {
        width: 164px;
        height: 29px;
    }
    .auto-style8 {
        height: 29px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style2">
    <strong>Login Page</strong><table class="auto-style3">
        <tr>
            <td class="auto-style7">Email</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Password</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6">
                <asp:Label ID="lblReminder" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6"></td>
        </tr>
    </table>
</div>
</asp:Content>
