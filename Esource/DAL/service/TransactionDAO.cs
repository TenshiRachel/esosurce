using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Esource.BL.service;

namespace Esource.DAL.service
{
    public class TransactionDAO
    {
        public int Insert(Transaction trans)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO [Transaction] (serviceProvider, service, currency, price, date, uid)" +
                "VALUES (@paraFreelance, @paraService, @paraCurr, @paraPrice, @paraDate, @paraUid)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraFreelance", trans.serviceProvider);
            sqlCmd.Parameters.AddWithValue("@paraService", trans.service);
            sqlCmd.Parameters.AddWithValue("@paraCurr", trans.currency);
            sqlCmd.Parameters.AddWithValue("@paraPrice", trans.price);
            sqlCmd.Parameters.AddWithValue("@paraDate", trans.date);
            sqlCmd.Parameters.AddWithValue("@paraUid", trans.uid);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public Transaction SelectById(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM [Transaction] WHERE Id=@paraId";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Transaction obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string serviceProvider = row["serviceProvider"].ToString();
                string service = row["service"].ToString();
                string curr = row["currency"].ToString();
                decimal price = decimal.Parse(row["price"].ToString());
                string date = row["date"].ToString();
                int uid = int.Parse(row["uid"].ToString());

                obj = new Transaction(serviceProvider, service, curr, price, uid, date, int.Parse(id));
            }

            return obj;
        }

        public List<Transaction> SelectByUid(string uid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM [Transaction] WHERE uid=@paraUid";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraUid", uid);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Transaction obj = null;
            List<Transaction> trans = new List<Transaction>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string serviceProvider = row["serviceProvider"].ToString();
                    string service = row["service"].ToString();
                    string curr = row["currency"].ToString();
                    decimal price = decimal.Parse(row["price"].ToString());
                    string date = row["date"].ToString();
                    int Id = int.Parse(row["Id"].ToString());

                    obj = new Transaction(serviceProvider, service, curr, price, int.Parse(uid), date, Id);
                    trans.Add(obj);
                }
            }

            return trans;
        }
    }
}