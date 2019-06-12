<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.master" AutoEventWireup="true" CodeFile="DepositMaster.aspx.cs" Inherits="_DepositMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    
        <asp:Label ID="accountNo" runat="server" Text="Account NO"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="account" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="amount" runat="server" Text="Amount"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="amt" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="withdra" runat="server" OnClick="deposit_Click" Text="Deposit" />
        <br />
        <br />
        <asp:Label ID="Res" runat="server"></asp:Label>
        <br />
    
    </div>
</asp:Content>

