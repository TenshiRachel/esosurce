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
    public class PortfolioDAO
    {
        public int Insert(Portfolio portfolio)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Portfolio (uid, title, category, content, datePosted, views, likes)" +
                "VALUES (@paraUID, @paraTitle, @paraCategory, @paraContent, @paraDatePosted, @paraViews, @paraLikes)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraUID", portfolio.uid);
            sqlCmd.Parameters.AddWithValue("@paraTitle", portfolio.title);
            sqlCmd.Parameters.AddWithValue("@paraCategory", portfolio.category);
            sqlCmd.Parameters.AddWithValue("@paraContent", portfolio.content);
            sqlCmd.Parameters.AddWithValue("@paraDatePosted", portfolio.datePosted);
            sqlCmd.Parameters.AddWithValue("@paraViews", portfolio.views);
            sqlCmd.Parameters.AddWithValue("@paraLikes", portfolio.likes);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public Portfolio SelectByUid(int UID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Portfolio WHERE uid = @paraUID";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraUID", UID);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Portfolio obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int id = int.Parse(row["Id"].ToString());
                int uid = int.Parse(row["uid"].ToString());
                string title = row["title"].ToString();
                string category = row["category"].ToString();
                string content = row["content"].ToString();
                string datePosted = row["datePosted"].ToString();
                int views = int.Parse(row["views"].ToString());
                string likes = row["likes"].ToString();
                obj = new Portfolio(uid, title, category, content, likes, datePosted, views, id);
            }

            return obj;
        }

        public Portfolio SelectById(int ID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Portfolio WHERE Id = @paraID";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraID", ID);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Portfolio obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int Id = int.Parse(row["Id"].ToString());
                int uid = int.Parse(row["uid"].ToString());
                string title = row["title"].ToString();
                string category = row["category"].ToString();
                string content = row["content"].ToString();
                string datePosted = row["datePosted"].ToString();
                int views = int.Parse(row["views"].ToString());
                string likes = row["likes"].ToString();
                obj = new Portfolio(uid, title, category, content, likes, datePosted, views, Id);
            }

            return obj;
        }

        public int UpdatePortfolio(string title, string category, string content, string Id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Portfolio " +
                "SET title = @paraTitle, category = @paraCategory, content = @paraContent " +
                "WHERE id = @paraID";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraTitle", title);
            sqlCmd.Parameters.AddWithValue("@paraCategory", category);
            sqlCmd.Parameters.AddWithValue("@paraContent", content);
            sqlCmd.Parameters.AddWithValue("@paraID", Id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateViews(string views, string Id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Portfolio " +
                "SET views = @paraViews " +
                "WHERE Id = @paraID";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraViews", views);
            sqlCmd.Parameters.AddWithValue("@paraID", Id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateLikes(string likes, string Id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Portfolio " +
                "SET likes = @paraLikes " +
                "WHERE Id = @paraID";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraLikes", likes);
            sqlCmd.Parameters.AddWithValue("@paraID", Id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}