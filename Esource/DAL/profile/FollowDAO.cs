using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Esource.BL.profile;

namespace Esource.DAL.profile
{
    public class FollowDAO
    {
        public int AddFollow(Follow follow)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Follower (followedId, followingId) VALUES (@paraFollowed, @paraFollowing)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraFollowed", follow.followerId);
            sqlCmd.Parameters.AddWithValue("@paraFollowing", follow.followingId);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int RemoveFollow(string followerId, string followingId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "DELETE FROM Follower WHERE followedId = @paraFollowed AND followingId = @paraFollowing";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraFollowed", followerId);
            sqlCmd.Parameters.AddWithValue("@paraFollowing", followingId);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public bool isFollowed(string followerId, string followingId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Follower WHERE followedId = @paraFollowed AND followingId = @paraFollowing";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraFollowed", followerId);
            da.SelectCommand.Parameters.AddWithValue("@paraFollowing", followingId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            bool followed = false;

            if (rec_cnt > 0)
            {
                followed = true;
            }

            return followed;
        }
    }
}