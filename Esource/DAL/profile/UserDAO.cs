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

            string sqlStmt = "INSERT INTO [User] (username, email, password, bio, profile_src, type, stripeId, website, birthday, gender, location, occupation)" +
                "VALUES (@paraName, @paraEmail, @paraPassword, @paraBio, @paraSrc, @paraType, @paraStripe, @paraSite, @paraBirthday, @paraGender, @paraLocation, @paraOccupation)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraName", user.username);
            sqlCmd.Parameters.AddWithValue("@paraEmail", user.email);
            sqlCmd.Parameters.AddWithValue("@paraPassword", user.password);
            sqlCmd.Parameters.AddWithValue("@paraBio", user.bio);
            sqlCmd.Parameters.AddWithValue("@paraSrc", user.profile_src);
            sqlCmd.Parameters.AddWithValue("@paraType", user.type);
            sqlCmd.Parameters.AddWithValue("@paraStripe", user.stripeId);
            sqlCmd.Parameters.AddWithValue("@paraSite", user.website);
            sqlCmd.Parameters.AddWithValue("@paraBirthday", user.birthday);
            sqlCmd.Parameters.AddWithValue("@paraGender", user.gender);
            sqlCmd.Parameters.AddWithValue("@paraLocation", user.location);
            sqlCmd.Parameters.AddWithValue("@paraOccupation", user.occupation);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateStripeId(string id, string stripeId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET stripeId = @paraStripe " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraStripe", stripeId);

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
                string stripe = row["stripeId"].ToString();
                string website = row["website"].ToString();
                string birthday = row["birthday"].ToString();
                string gender = row["gender"].ToString();
                string location = row["location"].ToString();
                string occupation = row["occupation"].ToString();
                obj = new User(name, email, password, bio, src, type, stripe, website, birthday, gender, location, occupation, id);
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
                string stripe = row["stripeId"].ToString();
                string website = row["website"].ToString();
                string birthday = row["birthday"].ToString();
                string gender = row["gender"].ToString();
                string location = row["location"].ToString();
                string occupation = row["occupation"].ToString();
                obj = new User(name, email, password, bio, src, type, stripe, website, birthday, gender, location, occupation, int.Parse(id));
            }

            return obj;
        }

        public int Update(string id, string username, string email, string bio, string profile_src, string website, string birthday, string gender, string location, string occupation)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET username = @paraName, email = @paraEmail, bio = @paraBio, profile_src = @paraSrc, website = @paraSite, birthday = @paraBirthday, gender = @paraGender, location = @paraLocation, occupation = @paraOccupation" +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraName", username);
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraBio", bio);
            sqlCmd.Parameters.AddWithValue("@paraSrc", profile_src);
            sqlCmd.Parameters.AddWithValue("@paraSite", website);
            sqlCmd.Parameters.AddWithValue("@paraBirthday", birthday);
            sqlCmd.Parameters.AddWithValue("@paraGender", gender);
            sqlCmd.Parameters.AddWithValue("@paraLocation", location);
            sqlCmd.Parameters.AddWithValue("@paraOccupation", occupation);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}