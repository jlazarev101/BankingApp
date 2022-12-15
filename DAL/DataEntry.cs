using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DAL
{
    public class DataEntry : DAO
    {
        SqlDataReader dr;

        string savingsBalance = string.Empty;

        public void RegistrationALL(string FirstName, string SurName, string Email, string Phone, string Address1, string Address2, string City, string County, string username, string password, string acctype, float initDep, int SortCode, int Overdraft)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "upsOneButtonForAll";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fn", FirstName);
            cmd.Parameters.AddWithValue("@sn", SurName);
            cmd.Parameters.AddWithValue("@em", Email);
            cmd.Parameters.AddWithValue("@ph", Phone);
            cmd.Parameters.AddWithValue("@add1", Address1);
            cmd.Parameters.AddWithValue("@add2", Address2);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.Parameters.AddWithValue("@cy", County);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@accType", acctype);
            cmd.Parameters.AddWithValue("@initDep", initDep);
            cmd.Parameters.AddWithValue("@sortcode", SortCode);
            cmd.Parameters.AddWithValue("@overdraft", Overdraft);
            cmd.ExecuteNonQuery();
            CloseCon();
        }

        public string GetCurrentBalance(int cID)
        {
            string currentBalance = "";
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspLGetCurrentBalance";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientID", cID);
      
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                currentBalance = dr["Balance"].ToString();
            }
            

            CloseCon();
            return currentBalance;

        }

        public string GetSavingsBalance(int cID)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspLGetSavingsBalance";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientID", cID);
            int count = Convert.ToInt32(cmd.ExecuteScalar());


            if (count >= 0)
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    savingsBalance = dr["Balance"].ToString();
                }
            }
            else
            {
                savingsBalance = "Error No Account";
            }
            CloseCon();
            return savingsBalance;
        }

        public DataTable GetCurrentTransaction(int clientid)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspGetCurrentTransaction";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientid", clientid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CloseCon();
            return dt;
        }

        public DataTable GetSavingsTransaction(int clientID)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspGetSavingsTransaction";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", clientID);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CloseCon();
            return dt;
        }

        public void UpdateCurrentClientID(int currentclientid, int clientid)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspUpdateCurrentClientIDtable";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@currentclientid", currentclientid);
            cmd.Parameters.AddWithValue("@clientid", clientid);
            cmd.ExecuteNonQuery();
            CloseCon();
        }

        public int GetCurrentClientIDwithoutFn(int currentclientid)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspGetClientID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@currentclientid", currentclientid);
            int clientid = Convert.ToInt32(cmd.ExecuteScalar());
            CloseCon();

            return clientid;
        }

        public List<string> GetAccountDetails(int clientID)
        {
            List<string> names = new List<string>();
            SqlDataReader dr;
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspGetClientDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientid", clientID);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();

                
                names.Add(fn);
                names.Add((sn));
                
                
            }
            CloseCon();
            return names;
        }

        public DataTable ViewAllAccounts(int clientID)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspViewAllAccounts";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientid", clientID);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CloseCon();
            return dt;
        }

        public void UpdateClientDetails(string user, string pass, string em, string phone, string add1, string add2, string city, string cy, int cid)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "upsUpdatePersonalLoginDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@em", em);
            cmd.Parameters.AddWithValue("@ph", phone);
            cmd.Parameters.AddWithValue("@add1", add1);
            cmd.Parameters.AddWithValue("@add2", add2);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@cy", cy);
            cmd.Parameters.AddWithValue("@clientID", cid);

            cmd.ExecuteNonQuery();
            CloseCon();
        }

        public bool GetUser(string user, string pass)
        {
            bool loginSuccessful;

            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspLogin";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            CloseCon();
            if (count > 0)
            {
                loginSuccessful = true;
                return loginSuccessful;
            }
            else
            {
                loginSuccessful = false;

                return loginSuccessful;
            }
            

        }

        public int GetClientIDLoginDetails(string user, string pass)
        {
           

            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspGetClientIDLoginTable";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            int clientID = Convert.ToInt32(cmd.ExecuteScalar());
            CloseCon();
            return clientID; 
            
        }

        public void RegistrationSavingsAccount(string Acc, int sc, int odl, float Dep, int cid)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "upsCreateSavingsAccount";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Acc", Acc);
            cmd.Parameters.AddWithValue("@sc", sc);
            cmd.Parameters.AddWithValue("@odl", odl);
            cmd.Parameters.AddWithValue("@Dep", Dep);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.ExecuteNonQuery();
            CloseCon();
        }

        public string GetBalance(string accNo)
        {

            string balance = "";
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspGetBalance";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountno", accNo);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                balance = dr["Balance"].ToString();

            }
            CloseCon();
            return balance;

        }

        public void UpdateBalance(float newbal, string accNo)
        {

            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspWithdraw";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nb", newbal);
            cmd.Parameters.AddWithValue("@id", accNo);
            cmd.ExecuteNonQuery();


            CloseCon();

        }

        public string GetOverdraftlimit(string accNo)
        {
            string overdraftlimit = "";
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspGetoverdraftlimit";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountno", accNo);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                overdraftlimit = dr["OverdraftLimit"].ToString();



            }
            CloseCon();

            return overdraftlimit;

        }

        public void RegistrationTransaction(string transType, float amount, string accType, string sender, string receiver, int clientid)
        {

            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "upsRegistrationTransaction";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@transtype", transType);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@acctype", accType);
            cmd.Parameters.AddWithValue("@sender", sender);
            cmd.Parameters.AddWithValue("@receiver", receiver);
            cmd.Parameters.AddWithValue("@clientid", clientid);
            cmd.ExecuteNonQuery();
            CloseCon();
        }

        public string GetAccountType(string accNo)
        {
            string accType = "";
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspGetAccountType";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountno", accNo);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                accType = dr["AccountType"].ToString();



            }
            CloseCon();

            return accType;

        }
    }
}
