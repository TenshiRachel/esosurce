using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esource.BL.service;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Esource.DAL.service
{
    public class ServiceDAO
    {
        public int Insert(Service service)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Service (name, descript, price, categories, status, date_created, username, views, favs, uid) OUTPUT INSERTED.Id " +
                "VALUES (@paraName, @paraDesc, @paraPrice, @paraCategories, @paraStatus, @paraDate, @paraUsername, @paraViews, @paraFavs, @paraUid)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraName", service.name);
            sqlCmd.Parameters.AddWithValue("@paraDesc", service.desc);
            sqlCmd.Parameters.AddWithValue("@paraPrice", service.price);
            sqlCmd.Parameters.AddWithValue("@paraDate", service.date_created);
            sqlCmd.Parameters.AddWithValue("@paraCategories", service.categories);
            sqlCmd.Parameters.AddWithValue("@paraStatus", service.status);
            sqlCmd.Parameters.AddWithValue("@paraUsername", service.username);
            sqlCmd.Parameters.AddWithValue("@paraFavs", service.favs);
            sqlCmd.Parameters.AddWithValue("@paraViews", service.views);
            sqlCmd.Parameters.AddWithValue("@paraUid", service.uid);

            conn.Open();
            result = (int)sqlCmd.ExecuteScalar();
            conn.Close();

            return result;
        }

        public int UpdateService(string name, string desc, decimal price, string categories, int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Service " +
                "SET name = @paraName, descript = @paraDesc, price = @paraPrice, categories = @paraCategories " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraName", name);
            sqlCmd.Parameters.AddWithValue("@paraDesc", desc);
            sqlCmd.Parameters.AddWithValue("@paraPrice", price);
            sqlCmd.Parameters.AddWithValue("@paraCategories", categories);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
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

        public List<Service> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Service WHERE status = ''";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Service obj = null;
            List<Service> services = new List<Service>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string name = row["name"].ToString();
                    string desc = row["descript"].ToString();
                    decimal price = decimal.Parse(row["price"].ToString());
                    string date_create = row["date_created"].ToString();
                    string categories = row["categories"].ToString();
                    string username = row["username"].ToString();
                    string status = row["status"].ToString();
                    int favs = int.Parse(row["favs"].ToString());
                    int views = int.Parse(row["views"].ToString());
                    int uid = int.Parse(row["uid"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Service(name, desc, price, categories, uid, username, status, favs, views, date_create, Id);
                    services.Add(obj);
                }
            }

            return services;
        }

        public List<Service> OrderedSelectAll(string param)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Service WHERE status = '' ORDER BY " + param + " DESC";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Service obj = null;
            List<Service> services = new List<Service>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string name = row["name"].ToString();
                    string desc = row["descript"].ToString();
                    decimal price = decimal.Parse(row["price"].ToString());
                    string date_create = row["date_created"].ToString();
                    string categories = row["categories"].ToString();
                    string username = row["username"].ToString();
                    string status = row["status"].ToString();
                    int favs = int.Parse(row["favs"].ToString());
                    int views = int.Parse(row["views"].ToString());
                    int uid = int.Parse(row["uid"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Service(name, desc, price, categories, uid, username, status, favs, views, date_create, Id);
                    services.Add(obj);
                }
            }

            return services;
        }

        public List<Service> SelectByUid(string uid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Service WHERE uid=@paraUid AND status=''";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraUid", uid);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Service obj = null;
            List<Service> services = new List<Service>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string name = row["name"].ToString();
                    string desc = row["descript"].ToString();
                    decimal price = decimal.Parse(row["price"].ToString());
                    string date_create = row["date_created"].ToString();
                    string categories = row["categories"].ToString();
                    string username = row["username"].ToString();
                    string status = row["status"].ToString();
                    int favs = int.Parse(row["favs"].ToString());
                    int views = int.Parse(row["views"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Service(name, desc, price, categories, int.Parse(uid), username, status, favs, views, date_create, Id);
                    services.Add(obj);
                }
            }

            return services;
        }

        public List<Service> SelectById(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Service WHERE Id=@paraId";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Service obj = null;
            List<Service> servs = new List<Service>();
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string name = row["name"].ToString();
                string desc = row["descript"].ToString();
                decimal price = decimal.Parse(row["price"].ToString());
                string date_create = row["date_created"].ToString();
                string categories = row["categories"].ToString();
                string username = row["username"].ToString();
                string status = row["status"].ToString();
                int uid = int.Parse(row["uid"].ToString());
                int favs = int.Parse(row["favs"].ToString());
                int views = int.Parse(row["views"].ToString());
                obj = new Service(name, desc, price, categories, uid, username, status, favs, views, date_create, int.Parse(id));
                servs.Add(obj);
            }

            return servs;
        }

        public int UpdateViews(string id, int views)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Service " +
                "SET views = @paraViews " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraViews", views);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateFavs(string id, int favs)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Service " +
                "SET favs = @paraFavs " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraFavs", favs);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}