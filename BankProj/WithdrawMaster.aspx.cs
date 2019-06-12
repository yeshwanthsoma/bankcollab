using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _WithdrawMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != "Manager")
        {
            Response.Redirect("LoginPageMaster.aspx");
        }
    }

    protected void withdra_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
        try
        {
            string res = obj.withdraw(long.Parse(account.Text), int.Parse(amt.Text));
            Res.Text = res;
        }
        catch(Exception exc)
        {
            Res.Text = "Enter valid details!!";
        }
       
    }
}