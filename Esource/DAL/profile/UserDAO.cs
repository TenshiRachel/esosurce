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

            string sqlStmt = "INSERT INTO [User] (username, email, password, passSalt, bio, profile_src, type, stripeId, following, followers, website, birthday, gender, location, occupation, social)" +
                "VALUES (@paraName, @paraEmail, @paraPassword, @paraSalt, @paraBio, @paraSrc, @paraType, @paraStripe, @paraFollow, @paraFollowers, @paraSite, @paraBirthday, @paraGender, @paraLocation, @paraOccupation, @paraSocial)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraName", user.username);
            sqlCmd.Parameters.AddWithValue("@paraEmail", user.email);
            sqlCmd.Parameters.AddWithValue("@paraPassword", user.password);
            sqlCmd.Parameters.AddWithValue("@paraSalt", user.passSalt);
            sqlCmd.Parameters.AddWithValue("@paraBio", user.bio);
            sqlCmd.Parameters.AddWithValue("@paraSrc", user.profile_src);
            sqlCmd.Parameters.AddWithValue("@paraType", user.type);
            sqlCmd.Parameters.AddWithValue("@paraStripe", user.stripeId);
            sqlCmd.Parameters.AddWithValue("@paraFollow", user.following);
            sqlCmd.Parameters.AddWithValue("@paraFollowers", user.followers);
            sqlCmd.Parameters.AddWithValue("@paraSite", user.website);
            sqlCmd.Parameters.AddWithValue("@paraBirthday", user.birthday);
            sqlCmd.Parameters.AddWithValue("@paraGender", user.gender);
            sqlCmd.Parameters.AddWithValue("@paraLocation", user.location);
            sqlCmd.Parameters.AddWithValue("@paraOccupation", user.occupation);
            sqlCmd.Parameters.AddWithValue("@paraSocial", user.social);

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

        public int UpdateFollowing(string id, int follows)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET following = @paraFollow " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraFollow", follows);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateFollower(string id, int follows)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET followers = @paraFollow " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraFollow", follows);

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
                string passSalt = row["passSalt"].ToString();
                string bio = row["bio"].ToString();
                string src = row["profile_src"].ToString();
                string type = row["type"].ToString();
                string stripe = row["stripeId"].ToString();
                int following = int.Parse(row["following"].ToString());
                int follows = int.Parse(row["followers"].ToString());
                string website = row["website"].ToString();
                string birthday = row["birthday"].ToString();
                string gender = row["gender"].ToString();
                string location = row["location"].ToString();
                string occupation = row["occupation"].ToString();
                string social = row["social"].ToString();
                obj = new User(name, email, password, passSalt, bio, src, type, stripe, following, follows, social, website, birthday, gender, location, occupation, id);
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
                string passSalt = row["passSalt"].ToString();
                string bio = row["bio"].ToString();
                string src = row["profile_src"].ToString();
                string type = row["type"].ToString();
                string stripe = row["stripeId"].ToString();
                int following = int.Parse(row["following"].ToString());
                int follows = int.Parse(row["followers"].ToString());
                string website = row["website"].ToString();
                string birthday = row["birthday"].ToString();
                string gender = row["gender"].ToString();
                string location = row["location"].ToString();
                string occupation = row["occupation"].ToString();
                string social = row["social"].ToString();
                obj = new User(name, email, password, passSalt, bio, src, type, stripe, following, follows, social, website, birthday, gender, location, occupation, int.Parse(id));
            }

            return obj;
        }

        public int Update(string id, string bio, string profile_src, string website, string birthday, string gender, string location, string occupation, string social)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET bio = @paraBio, profile_src = @paraSrc, website = @paraSite, birthday = @paraBirthday, gender = @paraGender, location = @paraLocation, occupation = @paraOccupation, social = @paraSocial " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraBio", bio);
            sqlCmd.Parameters.AddWithValue("@paraSrc", profile_src);
            sqlCmd.Parameters.AddWithValue("@paraSite", website);
            sqlCmd.Parameters.AddWithValue("@paraBirthday", birthday);
            sqlCmd.Parameters.AddWithValue("@paraGender", gender);
            sqlCmd.Parameters.AddWithValue("@paraLocation", location);
            sqlCmd.Parameters.AddWithValue("@paraOccupation", occupation);
            sqlCmd.Parameters.AddWithValue("@paraSocial", social);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdatePassword(string password, string passSalt, string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET password = @paraPassword, passSalt = @paraSalt " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraPassword", password);
            sqlCmd.Parameters.AddWithValue("@paraSalt", passSalt);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}