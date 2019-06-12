using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Account.Text = Session["accountNo"].ToString();
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            int balance = obj.balanceEnquiry(long.Parse(Account.Text));
            Balance.Text = System.Configuration.ConfigurationManager.AppSettings["message"] + balance.ToString();
        }
        catch(Exception exp)
        {
            Response.Redirect("LoginPageMaster.aspx");
        }

    }
}