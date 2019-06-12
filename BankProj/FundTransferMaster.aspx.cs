using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _FundTransferMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"].ToString() != "Customer")
        {
            Response.Redirect("LoginPageMaster.aspx");
        }
        else
        {
            account1.Text = Session["accountNo"].ToString();
        }
    }

    protected void transfer_Click(object sender, EventArgs e)
    {

        try
        {
            int amt;
            long acc1 = long.Parse(account1.Text);
            long acc2 = long.Parse(account2.Text);
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            if (acc1 == acc2)
            {
                Label6.Text = "Cannot transfer to same account";
                return;
            }
            long res = obj.checkAccount(acc2);

            if (res != -100)
            {
                amt = obj.checkAmount(acc1);
                if (amt > int.Parse(amount.Text))
                {
                    obj.transferAdd(int.Parse(amount.Text), acc2);
                    obj.transferSub(int.Parse(amount.Text), acc1);

                    Label6.Text = "Tranasaction Successful:" + int.Parse(amount.Text);
                    string type = Session["type"].ToString();
                    obj.insTrans(acc1, acc2, int.Parse(amount.Text), type, comment.Text);

                }
                else
                {
                    Label6.Text = "No sufficient amount";
                }
            }
            else
            {
                Label6.Text = "Acc Not existing";
            }
        }

        catch (Exception exp) {
            Label6.Text = "Enter valid details!!";
        }
    }
}