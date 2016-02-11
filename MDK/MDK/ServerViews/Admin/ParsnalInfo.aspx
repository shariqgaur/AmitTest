<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParsnalInfo.aspx.cs" Inherits="MDK.ServerViews.Admin.ParsnalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 64px;
        }
        .auto-style2 {
            width: 361px;
        }
        .auto-style3 {
            height: 64px;
            width: 361px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   
    <h3>Personal Information    </h3>
    
     <table>
        <tr>
            <th>First Name
            </th>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxFirstName" runat="server" Width="300px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxFirstName" ErrorMessage="Enter First Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                Middile Name
            </th>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxMiddileName" runat="server" Width="300px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxMiddileName" ErrorMessage="Enter Middile Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                Last Name
            </th>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxLastName" runat="server" Width="300px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxLastName" ErrorMessage="Enter Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                Address
            </th>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxAddress" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxAddress" ErrorMessage="Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                Contact No
            </th>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxContactNo" runat="server" Width="300px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxContactNo" ErrorMessage="Enter Contact No" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th class="auto-style1">
                Email-ID
            </th>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxEmailID" runat="server" TextMode="Email" Width="300px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxEmailID" ErrorMessage="Enter Email Id" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                Date Of Birth
            </th>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxDOB" runat="server" Width="300px" TextMode="Date"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxDOB" ErrorMessage="Enter Date Of Birth" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="errorMessage" runat="server" ForeColor="Red" Text="Record not save..!"></asp:Label>
                <asp:Label ID="successMessage" runat="server" ForeColor="#00CC00" Text="Record is save ....!"></asp:Label>
            </td>
        </tr>
        <tr><td></td>
            <td class="auto-style2">
            <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" Width="129px" />
            </td></tr>
    </table>
</asp:Content>
