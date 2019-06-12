using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _AddCustomerMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"].ToString() != "Manager")
            {
                Response.Redirect("LoginPageMaster.aspx");
            }
        }
    }
    protected void addCustomerDetails(ServiceReference1.customer customer)
    {
        //customer.CustomerID = int.Parse(custId.Text);
        customer.CustomerName = custName1.Text;
        if (male.Checked)
            customer.Gender = 'M';
        else
            customer.Gender = 'F';
        customer.Dob = dob.SelectedDate.ToShortDateString();
        customer.Address = address.Text;
        customer.State = state.SelectedValue;
        customer.City = city.SelectedValue;
        customer.Pincode = pinCode.Text;
        customer.PhoneNo = phoneNumber.Text;
        customer.Email = email2.Text;
        customer.CreatedDate = DateTime.Now.ToShortDateString();
        customer.EditedDate = DateTime.Now.ToShortDateString();
        customer.UserID = email2.Text;
    }

    protected void addCustomerBtn_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
        ServiceReference1.customer customer = new ServiceReference1.customer();
        addCustomerDetails(customer);
        sc.addLogin(customer.Email, "123456", "Customer");
        int rows_affected = sc.addCustomer(customer);
        if (rows_affected == 0)
        {
            Label2.Text = System.Configuration.ConfigurationManager.AppSettings["customerAddingError"];

        }
        else
        {
            Label2.Text = System.Configuration.ConfigurationManager.AppSettings["customerAdded"];
        }
    }
    protected void state_SelectedIndexChanged(object sender, EventArgs e)
    {
        city.Items.Clear();
        switch (state.SelectedValue)
        {
            case "Andhra Pradesh":
                city.Items.Add(new ListItem("Vijayawada", "Vijayawada"));
                city.Items.Add(new ListItem("Visakapatnam", "Visakapatnam"));
                city.Items.Add(new ListItem("Tirupathi", "Tirupathi"));
                break;
            case "Arunachal Pradesh":
                city.Items.Add(new ListItem("Itanagar", "Itanagar"));
                city.Items.Add(new ListItem("Khonsa", "Khonsa"));
                city.Items.Add(new ListItem("Roing", "Roing"));
                break;
            case "Assam":
                city.Items.Add(new ListItem("Assam", "Assam"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Bihar":
                city.Items.Add(new ListItem("Bihar", "Bihar"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Chhattisgarh":
                city.Items.Add(new ListItem("Chhattisgarh", "Chhattisgarh"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Goa":
                city.Items.Add(new ListItem("Goa", "Goa"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Gujarat":
                city.Items.Add(new ListItem("Gujarat", "Gujarat"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Haryana":
                city.Items.Add(new ListItem("Haryana", "Haryana"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Himachal Pradesh":
                city.Items.Add(new ListItem("Himachal Pradesh", "Himachal Pradesh"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Jammu and Kashmir":
                city.Items.Add(new ListItem("Jammu and Kashmir", "Jammu and Kashmir"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Jharkhand":
                city.Items.Add(new ListItem("Jharkhand", "Jharkhand"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Karnataka":
                city.Items.Add(new ListItem("Karnataka", "Karnataka"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Kerala":
                city.Items.Add(new ListItem("Kerala", "Kerala"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Madhya Pradesh":
                city.Items.Add(new ListItem("Madhya Pradesh", "Madhya Pradesh"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Maharashtra":
                city.Items.Add(new ListItem("Maharashtra", "Maharashtra"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Manipur":
                city.Items.Add(new ListItem("Manipur", "Manipur"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Meghalaya":
                city.Items.Add(new ListItem("Meghalaya", "Meghalaya"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Mizoram":
                city.Items.Add(new ListItem("Mizoram", "Mizoram"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Nagaland":
                city.Items.Add(new ListItem("Nagaland", "Nagaland"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Odisha":
                city.Items.Add(new ListItem("Odisha", "Odisha"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Punjab":
                city.Items.Add(new ListItem("Punjab", "Punjab"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Rajasthan":
                city.Items.Add(new ListItem("Rajasthan", "Rajasthan"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Sikkim":
                city.Items.Add(new ListItem("Sikkim", "Sikkim"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Tamil Nadu":
                city.Items.Add(new ListItem("Tamil Nadu", "Tamil Nadu"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Telangana":
                city.Items.Add(new ListItem("Telangana", "Telangana"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Tripura":
                city.Items.Add(new ListItem("Tripura", "Tripura"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Uttar Pradesh":
                city.Items.Add(new ListItem("Uttar Pradesh", "Uttar Pradesh"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "Uttarakhand":
                city.Items.Add(new ListItem("Uttarakhand", "Uttarakhand"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
            case "West Bengal":
                city.Items.Add(new ListItem("West Bengal", "West Bengal"));
                city.Items.Add(new ListItem("Khonsa", "khonsa"));
                city.Items.Add(new ListItem("Roing", "roing"));
                break;
        }
    }






    protected void custName_TextChanged(object sender, EventArgs e)
    {

    }
}