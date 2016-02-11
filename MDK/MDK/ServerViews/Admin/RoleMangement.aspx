<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleMangement.aspx.cs" Inherits="MDK.ServerViews.Admin.RoleMangement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>Role Name
            </th>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxRoleName" runat="server"></asp:TextBox>
            </td>
        </tr>

             <tr>
            <td>
             <asp:Label runat="server" ID="lblSuccessMSG" Text="Role added successfully !" ForeColor="Green"></asp:Label>
             <asp:Label runat="server" ID="lblErrorMSG" Text="Record not saved !" ForeColor="red"></asp:Label>
            
            </td>
        </tr>
        <tr>

            <td>
                <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" />
                <asp:Button ID="BTnClear" runat="server" Text="Clear" />
            </td>
            <td></td>
        </tr>

    </table>


</asp:Content>
