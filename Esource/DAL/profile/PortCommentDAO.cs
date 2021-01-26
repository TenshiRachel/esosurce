using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Esource.DAL.profile
{
    public class PortCommentDAO
    {
        public int Insert(PortComment comment)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO PortComment (uid, username, content, date, pid)" +
                "VALUES (@paraUID, @paraName, @paraContent, @paraDate, @paraPID)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraUID", comment.uid);
            sqlCmd.Parameters.AddWithValue("@paraName", comment.username);
            sqlCmd.Parameters.AddWithValue("@paraContent", comment.content);
            sqlCmd.Parameters.AddWithValue("@paraDate", comment.date);
            sqlCmd.Parameters.AddWithValue("@paraPID", comment.pid);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public PortComment SelectByPid(int PID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM PortComment WHERE pid = @paraPID";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraPID", PID);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            PortComment obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int Id = int.Parse(row["Id"].ToString());
                int uid = int.Parse(row["uid"].ToString());
                string username = row["username"].ToString();
                string content = row["content"].ToString();
                string date = row["date"].ToString();
                int pid = int.Parse(row[""].ToString());
                obj = new PortComment(uid, username, content, date, pid, Id);
            }

            return obj;
        }
    }
}