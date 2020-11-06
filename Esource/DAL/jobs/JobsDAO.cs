using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Esource.BL.jobs;

namespace Esource.DAL.jobs
{
    public class JobsDAO
    {
        public int Insert(Jobs jobs)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Job (cid, uid, sid, date_created, sName, cName, username, status, remarks, price)" +
                "VALUES (@paraCid, @paraUid, @paraSid, @paradatecreated, @paraSName, @paraCName, @paraUsername, @paraStatus, @paraRemarks, @paraPrice)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraCid", jobs.cid);
            sqlCmd.Parameters.AddWithValue("@paraUid", jobs.uid);
            sqlCmd.Parameters.AddWithValue("@paraSid", jobs.sid);
            sqlCmd.Parameters.AddWithValue("@paradatecreated", jobs.date_created);
            sqlCmd.Parameters.AddWithValue("@paraSName", jobs.sName);
            sqlCmd.Parameters.AddWithValue("@paraCName", jobs.cName);
            sqlCmd.Parameters.AddWithValue("@paraUsername", jobs.username);
            sqlCmd.Parameters.AddWithValue("@paraStatus", jobs.status);
            sqlCmd.Parameters.AddWithValue("@paraRemarks", jobs.remarks);
            sqlCmd.Parameters.AddWithValue("@paraPrice", jobs.price);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public List<Jobs> SelectByUid(string uid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Job WHERE uid=@paraUid";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraUid", uid);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Jobs obj = null;
            List<Jobs> jobs = new List<Jobs>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    int cid = int.Parse(row["cid"].ToString());
                    int sid = int.Parse(row["sid"].ToString());
                    string date_created = row["date_created"].ToString();
                    string sName = row["sName"].ToString();
                    string cName = row["cName"].ToString();
                    string username = row["username"].ToString();
                    string status = row["status"].ToString();
                    string remarks = row["remarks"].ToString();
                    decimal price = decimal.Parse(row["price"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Jobs(cid, int.Parse(uid), sid, sName, cName, username, remarks, price, date_created, status, Id);
                    jobs.Add(obj);
                }
            }

            return jobs;
        }

        public List<Jobs> SelectByCid(string cid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Job WHERE cid=@paraCid";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraCid", cid);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Jobs obj = null;
            List<Jobs> jobs = new List<Jobs>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    int uid = int.Parse(row["uid"].ToString());
                    int sid = int.Parse(row["sid"].ToString());
                    string date_created = row["date_created"].ToString();
                    string sName = row["sName"].ToString();
                    string cName = row["cName"].ToString();
                    string username = row["username"].ToString();
                    string status = row["status"].ToString();
                    string remarks = row["remarks"].ToString();
                    decimal price = decimal.Parse(row["price"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Jobs(int.Parse(cid), uid, sid, sName, cName, username, remarks, price, date_created, status, Id);
                    jobs.Add(obj);
                }
            }

            return jobs;
        }

        public Jobs SelectByCidSid(string cid, string sid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Job WHERE cid=@paraCid AND sid=@paraSid";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraCid", cid);
            da.SelectCommand.Parameters.AddWithValue("@paraSid", sid);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Jobs obj = null;
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    int uid = int.Parse(row["uid"].ToString());
                    string date_created = row["date_created"].ToString();
                    string sName = row["sName"].ToString();
                    string cName = row["cName"].ToString();
                    string username = row["username"].ToString();
                    string status = row["status"].ToString();
                    string remarks = row["remarks"].ToString();
                    decimal price = decimal.Parse(row["price"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Jobs(int.Parse(cid), uid, int.Parse(sid), sName, cName, username, remarks, price, date_created, status, Id);
                }
            }

            return obj;
        }

        public int UpdateStatus(string id, string status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Service " +
                "SET status = @paraStatus " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraStatus", status);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}