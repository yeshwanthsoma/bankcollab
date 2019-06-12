using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ServiceReference1;

public partial class _Customermaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"].ToString() =="Customer")
        {
            Role.Text = Session["role"].ToString();
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            string id = Session["userId"].ToString();
            //var v = obj.accountFromCustomer(id);
            //obj.
            //SqlDataReader dr = v;
            IList<Account>aobj= obj.accountFromCustomer(id);

           
            if (aobj.Count!=0)
            {
                GridView1.DataSource = aobj;
                GridView1.DataBind();
            }
            else
            {
                submit.Visible = false;
                ErrorMsg.Text = System.Configuration.ConfigurationManager.AppSettings["accountNotFound"];
            }
        }
        else
        {
            Response.Redirect("LoginPageMaster.aspx");
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomStatementMaster.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string selectedRecord;
        int serialNum = Convert.ToInt32(Request.Form["RadioButton1"]);
        selectedRecord = serialNum.ToString();
        if (selectedRecord == "0")
        {

            ErrorMsg.Text = System.Configuration.ConfigurationManager.AppSettings["accountError"];

            ErrorMsg.Visible = true;
        }

        else
        {
            Session["accountNo"] = selectedRecord;
            Response.Redirect("CustomerMenuMaster.aspx");
            //Response.Write("<script>alert("+selectedRecord+")</script>");
        }
    }
}