using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _LoginPageMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == "Manager")
        {
            Response.Redirect("ManagerMaster.aspx");
        }
        else if (Session["role"] == "Customer")
        {
            Response.Redirect("CustomerMaster.aspx");
        }


    }

    protected void login_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
        string result = obj.checkCredentials(userId.Text, password.Text);
        if (result == "Manager")
        {
            Session["role"] = "Manager";
            Session["userId"] = userId.Text;
            Response.Redirect("ManagerMaster.aspx");
        }
        else if (result == "Customer")
        {
            Session["role"] = "Customer";
            Session["userId"] = userId.Text;
            Response.Redirect("Customermaster.aspx");

        }
        else
        {
            Label4.Text = result;
        }
    }
}