using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();

        string loginstatus = null;
        if (Session["Role"] != null)
        {
            string sessionstatus = Session["Role"].ToString();
            
            if (sessionstatus != null)
                loginstatus = "Logout";
        }
        else
        {
            loginstatus = "Login";
            
        }
        Button2.Text = loginstatus;
        if (Session["role"] == null)
        {
            MasterButton1.Visible = false;
            MasterButton2.Visible = false;
            MasterButton3.Visible = false;
            MasterButton4.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            

        }
        else if(Session["role"].ToString()=="Customer")
        {
            MasterButton1.Text = "Fund Transfer";
            MasterButton2.Text = "MiniStatement";
            MasterButton3.Text = "Change Password";
            MasterButton4.Text = "Balance Enquiry";
          //  HeaderName.Text = sc.getCustomerName(Session["userId"].ToString());

        }
        else if(Session["role"].ToString() == "Manager")
        {
            MasterButton1.Text = "Withdrawal";
            MasterButton2.Text = "Deposit";
            MasterButton3.Text = "Customer";
            MasterButton4.Text = "Account";
            HeaderName.Text = Session["userId"].ToString();

        }
        else
        {
            
        }
       
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["Role"] != null)
        {
            if (Session["role"].Equals("Manager"))
            {
                Response.Redirect("ManagerMaster.aspx");
            }
            else
            {
                Response.Redirect("Customermaster.aspx");
            }
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("LoginPageMaster.aspx");
        
    }

   

    protected void MasterButton1_Click(object sender, EventArgs e)
    {
        if(Session["role"].ToString()=="Manager")
        {
            Response.Redirect("WithdrawMaster.aspx");
        }
        else
        {
            Session["type"] = "FundTransfer";
            Response.Redirect("FundTransferMaster.aspx");
        }
    }

    protected void MasterButton2_Click(object sender, EventArgs e)
    {
        if (Session["role"].ToString() == "Manager")
        {
            Response.Redirect("DepositMaster.aspx");
        }
        else
        {
            Response.Redirect("MiniStatementMaster.aspx");
        }
    }


    protected void MasterButton3_Click(object sender, EventArgs e)
    {
        if (Session["role"].ToString() == "Manager")
        {
            Response.Redirect("CustomerMaster.aspx");
        }
        else
        {
            Response.Redirect("ChangePasswordMaster.aspx");
        }
    }

    protected void MasterButton4_Click(object sender, EventArgs e)
    {
        if (Session["role"].ToString() == "Manager")
        {
            Response.Redirect("ManageAccountMaster.aspx");
        }
        else
        {
            Response.Redirect("BalanceEnquiryMaster.aspx");
        }
    }
}
