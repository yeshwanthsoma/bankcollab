using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ServiceReference1;

public partial class _CustomStatementGridMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"].ToString() != "Customer")
        {
            Response.Redirect("LoginPageMaster.aspx");
        }
        else
        {
            try
            {
                ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
                int acc = int.Parse(Session["accountNo"].ToString());
                DateTime start = DateTime.Parse(Session["startdate"].ToString());
                DateTime end = DateTime.Parse(Session["enddate"].ToString());

                IList<Transaction> sobj = obj.customstatement(acc, start, end);

                GridView1.DataSource = sobj;
                GridView1.DataBind();

            }

            catch (Exception exe)
            {
                Label1.Text = System.Configuration.ConfigurationManager.AppSettings["invalidDetails"];
            }
        }
    }
}