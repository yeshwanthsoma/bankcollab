<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.master" AutoEventWireup="true" CodeFile="Customermaster.aspx.cs" Inherits="_Customermaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">

        function RadioCheck(rb) {

            var gv = document.getElementById("<%=GridView1.ClientID%>");
         var rbs = gv.getElementsByTagName("input");
         var row = rb.parentNode.parentNode;
         for (var i = 0; i < rbs.length; i++) {
             if (rbs[i].type == "radio") {
                 if (rbs[i].checked && rbs[i] != rb) {
                     rbs[i].checked = false;
                     break;
                 }
             }
         }
     }

    </script>
    
    <div>
    
      <h1>  <asp:Label ID="Role" runat="server" Text="Label"></asp:Label></h1>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>

                        <ItemTemplate>

                           
                            <%--<asp:RadioButton ID="RadioButton1" runat="server" value="<%# Eval("sno") %>" onclick="RadioCheck(this);" />--%>
                            <input name="RadioButton1" type="radio"  value="<%# Eval("accountNo") %>" onclick="RadioCheck(this);" />
                        </ItemTemplate>

                    </asp:TemplateField>
              <%--  <asp:HyperLinkField DataNavigateUrlFields="accountNo" DataNavigateUrlFormatString="Customer2.aspx?accountNo={0}" DataTextField="accountNo" HeaderText="AccountNo" />
               --%> 
                <asp:BoundField  DataField="accountNo" HeaderText="AccountNo"/>
                <asp:BoundField DataField="accountType" HeaderText="AccountType" />
                <asp:BoundField DataField="status" HeaderText="Status" />
            </Columns>
        </asp:GridView>
    
        <br />
        <asp:Button ID="submit" runat="server" OnClick="Button2_Click" Text="Submit" />
    
        <br />
        <br />
        <asp:Label ID="ErrorMsg" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Custom Statement" />
    
        <br />
    
    </div>
    





</asp:Content>

