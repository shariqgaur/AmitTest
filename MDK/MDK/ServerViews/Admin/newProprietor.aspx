<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newProprietor.aspx.cs" Inherits="MDK.ServerViews.Admin.newProprietor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>First Name</th>
            <td>
                <asp:TextBox ID="TextBoxFirstName" runat="server" Width="180px"></asp:TextBox></td>
        </tr>
        <tr>
            <th>Middle Name</th>
            <td>
                <asp:TextBox ID="TextBoxMiddleName" runat="server" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>Last Name</th>
            <td>
                <asp:TextBox ID="TextBoxLasyName" runat="server" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>Address</th>
            <td>
                <asp:TextBox ID="TextBoxAddress" runat="server" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>Contact No</th>
            <td>
                <asp:TextBox ID="TextBoxContactNo" runat="server" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>Email-ID</th>
            <td>
                <asp:TextBox ID="TextBoxEmaiID" runat="server" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>Date Of Birth</th>
            <td>
                <asp:TextBox ID="TextBoxDOB" runat="server" Width="180px"></asp:TextBox></td>

        </tr>
        <tr>
            <td>
                <asp:Button ID="SAVE" runat="server" Text="Save" /></td>

            <td>
                <asp:Button ID="CLEAR" runat="server" Text="Clear" /></td>
        </tr>
    </table>

</asp:Content>
