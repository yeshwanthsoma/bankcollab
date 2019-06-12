<%@ Page Title="" Language="C#" MasterPageFile="masterPage.master" AutoEventWireup="true" CodeFile="LoginPageMaster.aspx.cs" Inherits="_LoginPageMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    
        <h1><asp:Label ID="Label1" runat="server" Text="Login"></asp:Label></h1>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Enter UserId"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="userId" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Enter Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="password" runat="server" type="password"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="login" runat="server" OnClick="login_Click" Text="Login" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <br />
        <br />
        <asp:Label ID="Label4" runat="server"></asp:Label>
    
    </div>
</asp:Content>

