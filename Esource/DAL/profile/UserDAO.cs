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
    public class UserDAO
    {
        public int Insert(User user)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO [User] (username, email, password, bio, profile_src, type)" +
                "VALUES (@paraName, @paraEmail, @paraPassword, @paraBio, @paraSrc, @paraType)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraName", user.username);
            sqlCmd.Parameters.AddWithValue("@paraEmail", user.email);
            sqlCmd.Parameters.AddWithValue("@paraPassword", user.password);
            sqlCmd.Parameters.AddWithValue("@paraBio", user.bio);
            sqlCmd.Parameters.AddWithValue("@paraSrc", user.profile_src);
            sqlCmd.Parameters.AddWithValue("@paraType", user.type);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public User SelectByEmail(string mail)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM [User] WHERE email = @paraEmail";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", mail);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            User obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int id = int.Parse(row["Id"].ToString());
                string name = row["username"].ToString();
                string email = row["email"].ToString();
                string password = row["password"].ToString();
                string bio = row["bio"].ToString();
                string src = row["profile_src"].ToString();
                string type = row["type"].ToString();
                obj = new User(name, email, password, bio, src, type, id);
            }

            return obj;
        }

        public User SelectById(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM [User] WHERE Id = @paraUserID";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserID", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            User obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string name = row["username"].ToString();
                string email = row["email"].ToString();
                string password = row["password"].ToString();
                string bio = row["bio"].ToString();
                string src = row["profile_src"].ToString();
                string type = row["type"].ToString();
                obj = new User(name, email, password, bio, src, type, int.Parse(id));
            }

            return obj;
        }
    }
}