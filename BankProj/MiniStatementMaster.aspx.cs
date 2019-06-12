using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ServiceReference1;
public partial class _MiniStatementMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != "Customer")
        {
            Response.Redirect("LoginPageMaster.aspx");
        }
        else
        {
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            Ministate.DataSource = obj.ministatement(long.Parse(Session["accountNo"].ToString()));
           
            
            Ministate.DataBind();
        }



    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}