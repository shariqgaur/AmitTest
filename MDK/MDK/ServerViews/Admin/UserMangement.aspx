<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserMangement.aspx.cs" Inherits="MDK.ServerViews.Admin.userMangement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>
            User Name
             </th>
            <td><asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="Enter User Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            </tr>
        <tr>
            <th>
              Password
                </th>
            <td><asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                <br /></td>
            </tr>
        <tr>
            <th>
            ConformPassword
                </th>
            <td><asp:TextBox ID="TextBoxConfPass" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPass" ControlToValidate="TextBoxConfPass" ErrorMessage="Conform Password Should Be Same" ForeColor="Red"></asp:CompareValidator>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxConfPass" ErrorMessage="Enter Conform Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            </tr>
        <tr>
            <th>
            Role
                </th>
            <td><asp:DropDownList id="DrpRoles" runat="server" Width="300px" Height="25px"></asp:DropDownList>
                <br />
            </td>
            </tr>
            <tr><td class="auto-style1"></td><td class="auto-style1">
                <asp:Label runat="server" ID="lblSuccessMSG" Text="Role added successfully !" ForeColor="Green"></asp:Label>
             <asp:Label runat="server" ID="lblErrorMSG" Text="Record not saved !" ForeColor="red"></asp:Label>
               
                         </td></tr>
  <td></td>
                      <td>
    <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" /> &nbsp &nbsp &nbsp <asp:Button ID="BtnClear" runat="server" Text="Clear" />
                </td>
             </tr>
    </table>
    
         
</asp:Content>
