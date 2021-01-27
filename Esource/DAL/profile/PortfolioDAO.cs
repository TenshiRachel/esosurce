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

            string sqlStmt = "INSERT INTO Portfolio (uid, title, category, content, datePosted, views, likes, comments, likeslist) OUTPUT INSERTED.Id " +
                "VALUES (@paraUID, @paraTitle, @paraCategory, @paraContent, @paraDatePosted, @paraViews, @paraLikes, @paraComm, @paraLikeslist)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraUID", portfolio.uid);
            sqlCmd.Parameters.AddWithValue("@paraTitle", portfolio.title);
            sqlCmd.Parameters.AddWithValue("@paraCategory", portfolio.category);
            sqlCmd.Parameters.AddWithValue("@paraContent", portfolio.content);
            sqlCmd.Parameters.AddWithValue("@paraDatePosted", portfolio.datePosted);
            sqlCmd.Parameters.AddWithValue("@paraViews", portfolio.views);
            sqlCmd.Parameters.AddWithValue("@paraLikes", portfolio.likes);
            sqlCmd.Parameters.AddWithValue("@paraComm", portfolio.comments);
            sqlCmd.Parameters.AddWithValue("@paraLikeslist", portfolio.likeslist);

            conn.Open();
            result = (int)sqlCmd.ExecuteScalar();
            conn.Close();

            return result;
        }

        public List<Portfolio> SelectByUid(int UID)
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
            List<Portfolio> portfolios = new List<Portfolio>();

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
                int likes = int.Parse(row["likes"].ToString());
                int comments = int.Parse(row["comments"].ToString());
                string likeslist = row["likeslist"].ToString();
                obj = new Portfolio(uid, title, category, content, likeslist, datePosted, views, likes, comments, id);
                portfolios.Add(obj);
            }

            return portfolios;
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
                int likes = int.Parse(row["likes"].ToString());
                int comments = int.Parse(row["comments"].ToString());
                string likeslist = row["likeslist"].ToString();
                obj = new Portfolio(uid, title, category, content, likeslist, datePosted, views, likes, comments, Id);
            }

            return obj;
        }

        public int UpdatePortfolio(string title, string category, string content, string Id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Portfolio " +
                "SET title = @paraTitle, category = @paraCategory, content = @paraContent " +
                "WHERE Id = @paraID";

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

        public int UpdateLikes(int likes, string likeslist, string Id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Portfolio " +
                "SET likes = @paraLikes AND likeslist = @paraLikeslist " +
                "WHERE Id = @paraID";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraLikes", likes);
            sqlCmd.Parameters.AddWithValue("@paraLikeslist", likeslist);
            sqlCmd.Parameters.AddWithValue("@paraID", Id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateComm(string id, int comm)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Portfolio " +
                "SET comments = @paraComm " +
                "WHERE Id = @paraID";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraComm", comm);
            sqlCmd.Parameters.AddWithValue("@paraID", id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}