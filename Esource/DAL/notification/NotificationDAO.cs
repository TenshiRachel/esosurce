using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Esource.BL.notification;

namespace Esource.DAL.notification
{
    public class NotificationDAO
    {
        public int Insert(Notification notif)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Notification (cid, cname, pid, title, type, date_created, status)" +
                "VALUES (@paraCid, @paraCname, @paraPid, @paraTitle, @paraType, @paraDate, @paraStatus)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraCid", notif.uid);
            sqlCmd.Parameters.AddWithValue("@paraCname", notif.username);
            sqlCmd.Parameters.AddWithValue("@paraPid", notif.pid);
            sqlCmd.Parameters.AddWithValue("@paraTitle", notif.title);
            sqlCmd.Parameters.AddWithValue("@paraType", notif.type);
            sqlCmd.Parameters.AddWithValue("@paraDate", notif.date_created);
            sqlCmd.Parameters.AddWithValue("@paraStatus", notif.status);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public List<Notification> SelectUserNotifs(string uid, string type)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Notification WHERE cid = @paraCid AND type = @paraType AND status = ''";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraCid", uid);
            da.SelectCommand.Parameters.AddWithValue("@paraType", type);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Notification obj = null;
            List<Notification> notifs = new List<Notification>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string username = row["cname"].ToString();
                    int pid = int.Parse(row["pid"].ToString());
                    string title = row["date_created"].ToString();
                    string date_created = row["date_created"].ToString();
                    string status = row["status"].ToString();
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Notification(int.Parse(uid), username, pid, title, type, date_created, status, Id);
                    notifs.Add(obj);
                }
            }

            return notifs;
        }

        public int UpdateStatus(string id, string status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Notification " +
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

        public int UpdateByType(string uid, string type, string status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Notification " +
            "SET status = @paraStatus " +
            "WHERE cid = @paraUid AND type = @paraType";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraUid", uid);
            sqlCmd.Parameters.AddWithValue("@paraType", type);
            sqlCmd.Parameters.AddWithValue("@paraStatus", status);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}