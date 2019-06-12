using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        String ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string checkCredentials(string userId, string password)
        {
            string role = "00", pwd = "oo";
            int flag = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "checkCre";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@uid", userId);
            command.Parameters.Add(param1);

            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                role = dr.GetString(1);
                pwd = dr.GetString(0);

                if (password.Equals(pwd))
                {
                    con.Close();
                    return role;


                }
                else
                {
                    con.Close();
                    return System.Configuration.ConfigurationManager.AppSettings["wrongPassword"];
                }

            }
            else
            {
                con.Close();
                return System.Configuration.ConfigurationManager.AppSettings["userNotFound"];
            }

        }

        



        public int addCustomer(customer customer)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string procedure_name = "addCustomer";
            SqlCommand command = new SqlCommand(procedure_name, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter _name = new SqlParameter("@custName", customer.CustomerName);
            command.Parameters.Add(_name);
            SqlParameter _gender = new SqlParameter("@gender", customer.Gender);
            command.Parameters.Add(_gender);
            SqlParameter _dob = new SqlParameter("@dob", customer.Dob);
            command.Parameters.Add(_dob);
            SqlParameter _address = new SqlParameter("@state", customer.State);
            command.Parameters.Add(_address);
            SqlParameter _state = new SqlParameter("@address", customer.Dob);
            command.Parameters.Add(_state);
            SqlParameter _city = new SqlParameter("@city", customer.City);
            command.Parameters.Add(_city);
            SqlParameter _pincode = new SqlParameter("@pincode", customer.Pincode);
            command.Parameters.Add(_pincode);
            SqlParameter _phoneNo = new SqlParameter("@phoneNo", customer.PhoneNo);
            command.Parameters.Add(_phoneNo);
            SqlParameter _email = new SqlParameter("@email", customer.Email);
            command.Parameters.Add(_email);
            SqlParameter _createdDate = new SqlParameter("@createdDate", customer.CreatedDate);
            command.Parameters.Add(_createdDate);
            SqlParameter _editedDate = new SqlParameter("@editedDate", customer.EditedDate);
            command.Parameters.Add(_editedDate);
            SqlParameter _userId = new SqlParameter("@userId", customer.UserID);
            command.Parameters.Add(_userId);
            int rows_affected = command.ExecuteNonQuery();
            conn.Close();
            return rows_affected;
        }
        public List<customer> getSpecificCustomer(int custId)
        {
            
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            //string procedure_name = "getSpecificCustomer";
            SqlCommand command = new SqlCommand("select * from Customer where customerId = " + custId, conn);
            
            SqlDataAdapter reader = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            customer cobj=new WcfService.customer();
            reader.Fill(ds);
            conn.Close();
            List<customer> clist = new List<customer>();
            int noofrows = ds.Tables[0].Rows.Count;
           
            int i = 0;
            while (noofrows != 0)
            {
                customer obj = new customer();
                noofrows--;

                obj.CustomerID = int.Parse(ds.Tables[0].Rows[i]["CustomerID"].ToString());
                obj.CustomerName = ds.Tables[0].Rows[i]["CustomerName"].ToString();
                obj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString().ElementAt(0);
                obj.Dob = ds.Tables[0].Rows[i]["Dob"].ToString();
                obj.Address = (ds.Tables[0].Rows[i]["Address"].ToString());
                obj.State = ds.Tables[0].Rows[i]["State"].ToString();
                obj.Pincode = ds.Tables[0].Rows[i]["Pincode"].ToString();
                obj.PhoneNo = ds.Tables[0].Rows[i]["PhoneNo"].ToString();
                obj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                obj.CreatedDate = ds.Tables[0].Rows[i]["CreatedDate"].ToString();
                obj.EditedDate = ds.Tables[0].Rows[i]["EditedDate"].ToString();
                obj.UserID = ds.Tables[0].Rows[i]["UserID"].ToString();
                clist.Add(obj);
                i++;
            }
            return clist;



        }
        public int deleteCustomer(int custId)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string procedure_name = "deleteCustomer";
            SqlCommand command = new SqlCommand(procedure_name, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@custId", custId);
            command.Parameters.Add(id);
            int rows_affected = command.ExecuteNonQuery();
            conn.Close();
            return rows_affected;
        }
        public int updateCustomer(customer customer)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string procedure_name = "updateCustomer";
            SqlCommand command = new SqlCommand(procedure_name, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@custId", customer.CustomerID);
            command.Parameters.Add(id);
            SqlParameter _name = new SqlParameter("@custName", customer.CustomerName);
            command.Parameters.Add(_name);
            SqlParameter _gender = new SqlParameter("@gender", customer.Gender);
            command.Parameters.Add(_gender);
            SqlParameter _dob = new SqlParameter("@dob", customer.Dob);
            command.Parameters.Add(_dob);
            SqlParameter _address = new SqlParameter("@state", customer.State);
            command.Parameters.Add(_address);
            SqlParameter _state = new SqlParameter("@address", customer.Dob);
            command.Parameters.Add(_state);
            SqlParameter _city = new SqlParameter("@city", customer.City);
            command.Parameters.Add(_city);
            SqlParameter _pincode = new SqlParameter("@pincode", customer.Pincode);
            command.Parameters.Add(_pincode);
            SqlParameter _phoneNo = new SqlParameter("@phoneNo", customer.PhoneNo);
            command.Parameters.Add(_phoneNo);
            SqlParameter _email = new SqlParameter("@email", customer.Email);
            command.Parameters.Add(_email);
            SqlParameter _editedDate = new SqlParameter("@editedDate", customer.EditedDate);
            command.Parameters.Add(_editedDate);
            SqlParameter _userId = new SqlParameter("@userId", customer.UserID);
            command.Parameters.Add(_userId);
            int rows_affected = command.ExecuteNonQuery();
            conn.Close();
            return rows_affected;
        }
        public int addLogin(string userId, string password, string userType)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string procedure_name = "addLogin";
            SqlCommand command = new SqlCommand(procedure_name, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@userId", userId);
            command.Parameters.Add(id);
            SqlParameter pass = new SqlParameter("@password", password);
            command.Parameters.Add(pass);
            SqlParameter role = new SqlParameter("@role", userType);
            command.Parameters.Add(role);
            int rows_affected = command.ExecuteNonQuery();
            conn.Close();
            return rows_affected;
        }
        public List<customer> showAll()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("select * from Customer", conn);
            SqlDataAdapter reader = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            reader.Fill(ds);
            List<customer> showobj = new List<customer>();
            conn.Close();
            List<customer> clist = new List<customer>();
            int noofrows = ds.Tables[0].Rows.Count;

            int i = 0;
            while (noofrows != 0)
            {
                customer obj = new customer();
                noofrows--;

                obj.CustomerID = int.Parse(ds.Tables[0].Rows[i]["CustomerID"].ToString());
                obj.CustomerName = ds.Tables[0].Rows[i]["CustomerName"].ToString();
                obj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString().ElementAt(0);
                obj.Dob = ds.Tables[0].Rows[i]["Dob"].ToString();
                obj.Address = (ds.Tables[0].Rows[i]["Address"].ToString());
                obj.State = ds.Tables[0].Rows[i]["State"].ToString();
                obj.Pincode = ds.Tables[0].Rows[i]["Pincode"].ToString();
                obj.PhoneNo = ds.Tables[0].Rows[i]["PhoneNo"].ToString();
                obj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                obj.CreatedDate = ds.Tables[0].Rows[i]["CreatedDate"].ToString();
                obj.EditedDate = ds.Tables[0].Rows[i]["EditedDate"].ToString();
                obj.UserID = ds.Tables[0].Rows[i]["UserID"].ToString();
                clist.Add(obj);
                i++;
            }
            return clist;
        }
        public int updateUserId(string newUserID, string oldUserID)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string procedure_name = "updateUserID";
            SqlCommand command = new SqlCommand(procedure_name, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter newId = new SqlParameter("@newuserId", newUserID);
            command.Parameters.Add(newId);
            SqlParameter oldId = new SqlParameter("@olduserId", oldUserID);
            command.Parameters.Add(oldId);
            int rows_affected = command.ExecuteNonQuery();
            return rows_affected;
        }
        public List<Transaction> customstatement(int acc, DateTime start, DateTime end)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "datecheck";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc", acc);
            command.Parameters.Add(param1);
            DateTime Start = start.Date.Date;
            SqlParameter param2 = new SqlParameter("@start", Start);
            command.Parameters.Add(param2);
            DateTime End = end.Date.Date;
            SqlParameter param3 = new SqlParameter("@end", End);
            command.Parameters.Add(param3);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
 
            con.Close();
            int noofrows = ds.Tables[0].Rows.Count;
            int i = 0;
            List<Transaction> tlist = new List<Transaction>();
            while (noofrows != 0)
            {
                Transaction obj = new Transaction();
                noofrows--;
                obj.transactionId = long.Parse(ds.Tables[0].Rows[i]["transactionId"].ToString());
                obj.fromAccountNo = long.Parse(ds.Tables[0].Rows[i]["fromAccountNo"].ToString());
                obj.toAccountNo = long.Parse(ds.Tables[0].Rows[i]["toAccountNo"].ToString());
                obj.transactionDate = ds.Tables[0].Rows[i]["transactionDate"].ToString();
                obj.amount = int.Parse(ds.Tables[0].Rows[i]["amount"].ToString());
                obj.transactiontype = ds.Tables[0].Rows[i]["transactiontype"].ToString();
                obj.comments = ds.Tables[0].Rows[i]["comments"].ToString();
                tlist.Add(obj);
                i++;
            }
            return tlist;
         



        }
        public List<Account> accountFromCustomer(string id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "prints";

            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@id", id);
            command.Parameters.Add(param1);



            command.CommandType = CommandType.StoredProcedure;
           // SqlDataReader dr = command.ExecuteReader();
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            List<Account> accobj = new List<Account>();
            int i = 0;
            int noofrows = ds.Tables[0].Rows.Count;
            while (noofrows!=0)
            {
                Account obj = new Account();
                noofrows--;
                obj.accountNo = long.Parse(ds.Tables[0].Rows[i]["accountNo"].ToString());
                obj.accountType = ds.Tables[0].Rows[i]["accountType"].ToString();
                obj.status = ds.Tables[0].Rows[i]["status"].ToString();
                i++;

                accobj.Add(obj);

            }
         
            return accobj;
        }
        public string withdraw(long acc, int amt)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "checkAccount";

            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc", acc);


            command.Parameters.Add(param1);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int res, res1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                res = (int)ds.Tables[0].Rows[0]["customerId"];
                string sql1 = "checkAmount";

                SqlCommand command1 = new SqlCommand(sql1, con);
                SqlParameter param2 = new SqlParameter("@acc", acc);


                command1.Parameters.Add(param2);
                command1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da1 = new SqlDataAdapter(command1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    res1 = (int)ds1.Tables[0].Rows[0]["amount"];
                    if (res1 >= amt)
                    {
                        string sql3 = "withdraw";

                        SqlCommand command2 = new SqlCommand(sql3, con);
                        SqlParameter param3 = new SqlParameter("@acc", acc);


                        command2.Parameters.Add(param3);
                        SqlParameter param4 = new SqlParameter("@amt", amt);


                        command2.Parameters.Add(param4);

                        command2.CommandType = CommandType.StoredProcedure;
                        command2.ExecuteNonQuery();
                    }
                    else
                    {
                        return System.Configuration.ConfigurationManager.AppSettings["amountNotSufficient"];
                    }
                }
            }
            else
            {
                return System.Configuration.ConfigurationManager.AppSettings["accountNotFound"];
            }

            con.Close();
            return System.Configuration.ConfigurationManager.AppSettings["success"];

        }
        public string deposit(long acc, int amt)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "checkAccount";

            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc", acc);


            command.Parameters.Add(param1);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //int res, res1;
            if (ds.Tables[0].Rows.Count > 0)
            {

                string sql3 = "deposit";

                SqlCommand command2 = new SqlCommand(sql3, con);
                SqlParameter param3 = new SqlParameter("@acc", acc);


                command2.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter("@amt", amt);


                command2.Parameters.Add(param4);

                command2.CommandType = CommandType.StoredProcedure;
                command2.ExecuteNonQuery();



            }
            else
            {
                con.Close();
                return System.Configuration.ConfigurationManager.AppSettings["accountNotFound"];

            }

            con.Close();
            return System.Configuration.ConfigurationManager.AppSettings["success"];

        }
        public void insTrans(long acc1, long acc2, int amt, string type, string comment)
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insTrans";
            string date = DateTime.Now.ToString();

            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc1", acc1);
            command.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@acc2", acc2);
            command.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@Date", date);
            command.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@amt", amt);
            command.Parameters.Add(param4);
            SqlParameter param5 = new SqlParameter("@type", type);
            command.Parameters.Add(param5);
            SqlParameter param6 = new SqlParameter("@comment", comment);
            command.Parameters.Add(param6);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            con.Close();


        }
        public int balanceEnquiry(long acc)
        {
            int res;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "balanceEnq";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc", acc);
            command.Parameters.Add(param1);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                res = (int)ds.Tables[0].Rows[0]["amount"];
                con.Close();

                return res;
            }
            con.Close();
            return -100;



        }
        public long checkAccount(long acc1)
        {
            long res = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "checkAcc";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc", acc1);
            command.Parameters.Add(param1);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                res = (int)ds.Tables[0].Rows[0]["CustomerId"];
                return res;
            }

            con.Close();
            return -100;
        }

        public int checkAmount(long acc1)
        {
            int res = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "checkAmo";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc", acc1);
            command.Parameters.Add(param1);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);



            if (ds.Tables[0].Rows.Count > 0)
            {
                res = (int)ds.Tables[0].Rows[0]["amount"];
                return res;
            }

            con.Close();
            return -100;


        }
        public List<Transaction> ministatement(long acc)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "ministategen";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc", acc);
            command.Parameters.Add(param1);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            int noofrows = ds.Tables[0].Rows.Count;
            int i = 0;
            List<Transaction> tlist = new List<Transaction>();
            while (noofrows != 0)
            {
                Transaction obj = new Transaction();
                noofrows--;
                obj.transactionId = long.Parse(ds.Tables[0].Rows[i]["transactionId"].ToString());
                obj.fromAccountNo = long.Parse(ds.Tables[0].Rows[i]["fromAccountNo"].ToString());
                obj.toAccountNo = long.Parse(ds.Tables[0].Rows[i]["toAccountNo"].ToString());
                obj.transactionDate = ds.Tables[0].Rows[i]["transactionDate"].ToString();
                obj.amount = int.Parse(ds.Tables[0].Rows[i]["amount"].ToString());
                obj.transactiontype = ds.Tables[0].Rows[i]["transactiontype"].ToString();
                obj.comments =ds.Tables[0].Rows[i]["comments"].ToString();
                tlist.Add(obj);
                i++;
            }
            return tlist;

        }
        public void transferAdd(int amount, long acc)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "transferAdd";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc", acc);
            command.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@amt", amount);
            command.Parameters.Add(param2);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            con.Close();


        }

        public string changePassword(string old, string new1, string new2, string uid)
        {
            string res = "aa";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "changePass";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@uid", uid);
            command.Parameters.Add(param1);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                res = ds.Tables[0].Rows[0]["password"].ToString();
                if (res.Equals(old))
                {
                    if (new1.Equals(new2))
                    {
                        if (new1.Equals(old))
                        {
                            return System.Configuration.ConfigurationManager.AppSettings["sameOldPassword"];
                        }
                        else
                        {
                            string sql1 = "updatePass";
                            SqlCommand command1 = new SqlCommand(sql1, con);
                            SqlParameter param2 = new SqlParameter("@uid", uid);
                            command1.Parameters.Add(param2);
                            SqlParameter param3 = new SqlParameter("@pass", new1);
                            command1.Parameters.Add(param3);
                            command1.CommandType = CommandType.StoredProcedure;
                            command1.ExecuteNonQuery();
                            con.Close();
                            return System.Configuration.ConfigurationManager.AppSettings["passwordChanged"];
                        }


                    }
                    else
                    {
                        con.Close();
                        return System.Configuration.ConfigurationManager.AppSettings["passwordMismatch"];
                    }
                }
                con.Close();
                return System.Configuration.ConfigurationManager.AppSettings["oldPasswordMismatch"];

            }
            con.Close();
            return System.Configuration.ConfigurationManager.AppSettings["passwordNotFound"];

        }
        public void transferSub(int amount, long acc)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "transferSub";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@acc", acc);
            command.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@amt", amount);
            command.Parameters.Add(param2);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            con.Close();
        }
        public List<Account> GetCustomerId(int customerEnteredId)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();


            SqlCommand cmd = new SqlCommand("SELECT * from Account where customerId=" + customerEnteredId, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            int i = 0;
            sda.Fill(ds);
            List<Account> aobj = new List<Account>();
            int rows = ds.Tables[0].Rows.Count;
            if(rows== 0)
            {
                SqlCommand cmd2 = new SqlCommand("SELECT customerId from Customer where customerId=" + customerEnteredId, con);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                sda2.Fill(ds2);
                Account obj = new Account();
                obj.customerId = int.Parse(ds.Tables[0].Rows[0]["customerId"].ToString());

                aobj.Add(obj);
                return aobj;


            }
            while(rows!=0)
            {
                Account obj = new Account();
                obj.accountNo = long.Parse(ds.Tables[0].Rows[i]["accountNo"].ToString());
                obj.customerId = int.Parse(ds.Tables[0].Rows[i]["customerId"].ToString());
                obj.accountType = ds.Tables[0].Rows[i]["accountType"].ToString();
                obj.DateOfOpen = ds.Tables[0].Rows[i]["DateOfOpen"].ToString();
                obj.status = ds.Tables[0].Rows[i]["status"].ToString();
                obj.dateOfEdited = ds.Tables[0].Rows[i]["dateOfEdited"].ToString();
                obj.ClosingDate = ds.Tables[0].Rows[i]["ClosingDate"].ToString();
                obj.amount = int.Parse(ds.Tables[0].Rows[i]["amount"].ToString());
                aobj.Add(obj);
                i++;
                rows--;

            }

            return aobj ;

        }

        //This add an account into database
        public bool AddAccount(string[] EnteredDetails)
        {
            int res=-100,result=0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("checkCust", con);
            cmd1.Parameters.AddWithValue("@customerId", EnteredDetails[0]);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
           
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                SqlCommand cmd = new SqlCommand("addDetails", con);


                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@customerId", EnteredDetails[0]);
                cmd.Parameters.AddWithValue("@accountType", EnteredDetails[1]);
                cmd.Parameters.AddWithValue("@DateOfOpen", EnteredDetails[2]);
                cmd.Parameters.AddWithValue("@status", EnteredDetails[3]);
                cmd.Parameters.AddWithValue("@dateOfEdited", EnteredDetails[4]);
                cmd.Parameters.AddWithValue("@ClosingDate", EnteredDetails[5]);
                cmd.Parameters.AddWithValue("@amount", EnteredDetails[6]);


                 result = cmd.ExecuteNonQuery();

                con.Close();

            }

            else
            {
                return false;
            }
            return true;
            

        }

        //This updates edited values into database
        public bool EditAccount(Account selectedAccount)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("editedDetails", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@accountNo", selectedAccount.accountNo);
            cmd.Parameters.AddWithValue("@customerId", selectedAccount.customerId);
            cmd.Parameters.AddWithValue("@accountType", selectedAccount.accountType);
            cmd.Parameters.AddWithValue("@DateOfOpen", selectedAccount.DateOfOpen);
            cmd.Parameters.AddWithValue("@status", selectedAccount.status);
            cmd.Parameters.AddWithValue("@dateOfEdited", selectedAccount.dateOfEdited);
            cmd.Parameters.AddWithValue("@ClosingDate", selectedAccount.ClosingDate);
            cmd.Parameters.AddWithValue("@amount", selectedAccount.amount);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result == 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        //This deletes row in the database
        public bool DeleteAccount(long accountNoToDelete)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("deleteDetails", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@accountNo", accountNoToDelete);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result == 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
