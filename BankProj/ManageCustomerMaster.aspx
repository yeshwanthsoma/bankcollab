<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.master" AutoEventWireup="true" CodeFile="ManageCustomerMaster.aspx.cs" Inherits="_ManageCustomerMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:Label ID="Label1" runat="server" Text="Enter Customer ID: "></asp:Label>
        &nbsp &nbsp &nbsp 
        <asp:TextBox ID="custId" runat="server"></asp:TextBox>
        &nbsp &nbsp &nbsp
        <asp:Button ID="check" runat="server" Text="Submit" OnClick="check_Click" />
        &nbsp &nbsp &nbsp
        <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>

    <div>
    <asp:GridView ID="result" runat="server">
        </asp:GridView>
         <asp:Button ID="add" runat="server" OnClick="add_Click" text = "Add"/>
        &nbsp &nbsp &nbsp
        <asp:Button ID="edit" runat="server" OnClick="edit_Click" text = "Edit"/>
        &nbsp &nbsp &nbsp
        <asp:Button ID="delete" runat="server" OnClick="deleteCustomerBtn_Click" text = "Delete"/>
        &nbsp &nbsp &nbsp
        <asp:Button ID="showAllCustomersBtn" runat="server" Text="Show all" OnClick="showAllCustomersBtn_Click" />


        <br />
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        <br />


    </div>
</asp:Content>

