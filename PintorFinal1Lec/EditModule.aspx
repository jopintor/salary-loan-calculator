<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="EditModule.aspx.cs" Inherits="PintorFinal1Lec.EditModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        text-align: left;
    }
    .auto-style4 {
        width: 100%;
    }
    .auto-style5 {
        width: 190px;
    }
    .auto-style6 {
        width: 190px;
        height: 35px;
    }
    .auto-style7 {
        height: 35px;
    }
        .auto-style8 {
            width: 190px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
        }
        .auto-style10 {
            width: 190px;
            height: 40px;
        }
        .auto-style11 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style3">
    <strong>Edit Module</strong><table class="auto-style4">
        <tr>
            <td class="auto-style6">First Name:</td>
            <td class="auto-style7">
                <asp:TextBox ID="txteditFN" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Last Name:</td>
            <td>
                <asp:TextBox ID="txteditLN" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Basic Monthly Salary:</td>
            <td class="auto-style9">
                <asp:TextBox ID="txteditSalary" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">New Password:</td>
            <td class="auto-style9">
                <asp:TextBox ID="txteditPassword" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;&nbsp;&nbsp; (<asp:Label ID="Label1" runat="server" Text="Optional – leave blank to keep your current password"></asp:Label>
                )</td>
        </tr>
        <tr>
            <td class="auto-style8">Email Address:</td>
            <td class="auto-style9">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style11">
                <asp:Button ID="btnSave" runat="server" Height="27px" Text="Save" Width="48px" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>
                <asp:Label ID="lblReminder" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
