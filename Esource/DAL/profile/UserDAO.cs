using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Esource.Utilities;

namespace Esource.DAL.profile
{
    public class UserDAO
    {
        public int Insert(User user)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO [User] (username, email, password, passSalt, bio, type, IV, stripeId, following, followers, website, birthday, gender, location, occupation, social)" +
                "VALUES (@paraName, @paraEmail, @paraPassword, @paraSalt, @paraBio, @paraType, @paraIV, @paraStripe, @paraFollow, @paraFollowers, @paraSite, @paraBirthday, @paraGender, @paraLocation, @paraOccupation, @paraSocial)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraName", user.username);
            sqlCmd.Parameters.AddWithValue("@paraEmail", user.email);
            sqlCmd.Parameters.AddWithValue("@paraPassword", user.password);
            sqlCmd.Parameters.AddWithValue("@paraSalt", user.passSalt);
            sqlCmd.Parameters.AddWithValue("@paraBio", user.bio);
            sqlCmd.Parameters.AddWithValue("@paraType", user.type);
            sqlCmd.Parameters.AddWithValue("@paraIV", user.IV);
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
                string type = row["type"].ToString();
                string IV = row["IV"].ToString();
                string stripe = row["stripeId"].ToString();
                string jobPin = row["jobpin"].ToString();
                int following = int.Parse(row["following"].ToString());
                int follows = int.Parse(row["followers"].ToString());
                string website = row["website"].ToString();
                string birthday = row["birthday"].ToString();
                string gender = row["gender"].ToString();
                string location = row["location"].ToString();
                string skills = row["skills"].ToString();
                string occupation = row["occupation"].ToString();
                string social = row["social"].ToString();
                string resetToken = row["resetToken"].ToString();
                string resetTokenExpiry = row["resetTokenExpiry"].ToString();
                string paymentToken = row["paymentToken"].ToString();
                string paymentTokenExpiry = row["paymentTokenExpiry"].ToString();

                if (!string.IsNullOrEmpty(stripe))
                {
                    stripe = Auth.decrypt(Convert.FromBase64String(stripe), Convert.FromBase64String(IV));
                }
                if (!string.IsNullOrEmpty(jobPin))
                {
                    jobPin = Auth.decrypt(Convert.FromBase64String(jobPin), Convert.FromBase64String(IV));
                }

                obj = new User(name, email, password, passSalt, bio, type, IV, stripe, jobPin, following, follows, social, website, birthday, gender, location, skills, occupation, resetToken, resetTokenExpiry,
                    paymentToken, paymentTokenExpiry, id);
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
                string type = row["type"].ToString();
                string IV = row["IV"].ToString();
                string stripe = row["stripeId"].ToString();
                string jobPin = row["jobpin"].ToString();
                int following = int.Parse(row["following"].ToString());
                int follows = int.Parse(row["followers"].ToString());
                string website = row["website"].ToString();
                string birthday = row["birthday"].ToString();
                string gender = row["gender"].ToString();
                string location = row["location"].ToString();
                string occupation = row["occupation"].ToString();
                string social = row["social"].ToString();
                string skills = row["skills"].ToString();
                string resetToken = row["resetToken"].ToString();
                string resetTokenExpiry = row["resetTokenExpiry"].ToString();
                string paymentToken = row["paymentToken"].ToString();
                string paymentTokenExpiry = row["paymentTokenExpiry"].ToString();

                if (!string.IsNullOrEmpty(stripe))
                {
                    stripe = Auth.decrypt(Convert.FromBase64String(stripe), Convert.FromBase64String(IV));
                }

                if (!string.IsNullOrEmpty(jobPin))
                {
                    jobPin = Auth.decrypt(Convert.FromBase64String(jobPin), Convert.FromBase64String(IV));
                }

                obj = new User(name, email, password, passSalt, bio, type, IV, stripe, jobPin, following, follows, social, skills, website, birthday, gender, location, occupation,
                    resetToken, resetTokenExpiry, paymentToken, paymentTokenExpiry, int.Parse(id));
            }

            return obj;
        }

        public int Update(string id, string bio, string website, string birthday, string gender, string location, string occupation, string social, string skills = "")
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET bio = @paraBio, website = @paraSite, birthday = @paraBirthday, gender = @paraGender, location = @paraLocation, occupation = @paraOccupation, social = @paraSocial, skills = @paraSkills " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraBio", bio);
            sqlCmd.Parameters.AddWithValue("@paraSite", website);
            sqlCmd.Parameters.AddWithValue("@paraBirthday", birthday);
            sqlCmd.Parameters.AddWithValue("@paraGender", gender);
            sqlCmd.Parameters.AddWithValue("@paraLocation", location);
            sqlCmd.Parameters.AddWithValue("@paraOccupation", occupation);
            sqlCmd.Parameters.AddWithValue("@paraSocial", social);
            sqlCmd.Parameters.AddWithValue("@paraSkills", skills);

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

        public int UpdateReset(string id, string token, string expiry)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET resetToken = @paraToken, resetTokenExpiry = @paraExpiry " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraToken", token);
            sqlCmd.Parameters.AddWithValue("@paraExpiry", expiry);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdatePaymentToken(string id, string token, string expiry)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET paymentToken = @paraToken, paymentTokenExpiry = @paraExpiry " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraToken", token);
            sqlCmd.Parameters.AddWithValue("@paraExpiry", expiry);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public bool CheckTokenValid(string type, string token, string uid)
        {
            bool valid = false;
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);
            string sqlStmt = "SELECT * FROM [User] WHERE Id = @paraUid";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraUid", uid);

            DataSet ds = new DataSet();

            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                long currDate = DateTime.Now.Ticks;
                long exprDate = 0;
                string resetToken = "";
                string paymentToken = "";
                byte[] IV = Convert.FromBase64String(row["IV"].ToString());

                string encryptedReset = row["resetToken"].ToString();
                if (!string.IsNullOrEmpty(encryptedReset))
                {
                    resetToken = Auth.decrypt(Convert.FromBase64String(encryptedReset), IV);
                }
                string encryptedPayment = row["paymentToken"].ToString();
                if (!string.IsNullOrEmpty(encryptedPayment))
                {
                    paymentToken = Auth.decrypt(Convert.FromBase64String(encryptedPayment), IV);
                }

                if (type == "reset" && token == resetToken)
                {
                    string resetExpr = row["resetTokenExpiry"].ToString();
                    if (!string.IsNullOrEmpty(resetExpr))
                    {
                        exprDate = long.Parse(resetExpr);
                    }
                }
                
                if (type == "payment" && token == paymentToken)
                {
                    string paymentExpr = row["paymentTokenExpiry"].ToString();
                    if (!string.IsNullOrEmpty(paymentExpr))
                    {
                        exprDate = long.Parse(paymentExpr);
                    }
                }
                long expired = exprDate - currDate;
                if (expired > 0)
                {
                    valid = true;
                }
            }

            return valid;
        }

        public int UpdateJobPIN(string uid, string pin)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET jobpin = @paraPin " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraPin", pin);
            sqlCmd.Parameters.AddWithValue("@paraId", uid);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateSkills(string id, string skills)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET skills = @paraSkills " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraSkills", skills);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}