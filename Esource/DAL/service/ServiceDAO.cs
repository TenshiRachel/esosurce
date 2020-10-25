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

            string sqlStmt = "INSERT INTO Service (name, descript, price, categories, date_created, img_path, views, favs, uid)" +
                "VALUES (@paraName, @paraDesc, @paraPrice, @paraCategories, @paraDate, @paraImg, @paraViews, @paraFavs, @paraUid)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraName", service.name);
            sqlCmd.Parameters.AddWithValue("@paraDesc", service.desc);
            sqlCmd.Parameters.AddWithValue("@paraPrice", service.price);
            sqlCmd.Parameters.AddWithValue("@paraDate", service.date_created);
            sqlCmd.Parameters.AddWithValue("@paraCategories", service.categories);
            sqlCmd.Parameters.AddWithValue("@paraImg", service.img_path);
            sqlCmd.Parameters.AddWithValue("@paraFavs", service.favs);
            sqlCmd.Parameters.AddWithValue("@paraViews", service.views);
            sqlCmd.Parameters.AddWithValue("@paraUid", service.uid);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateService(string name, string desc, decimal price, string categories, string img_path, int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Service " +
                "SET name = @paraName, descript = @paraDesc, price = @paraPrice, categories = @paraCategories, img_path = @paraImg " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraName", name);
            sqlCmd.Parameters.AddWithValue("@paraDesc", desc);
            sqlCmd.Parameters.AddWithValue("@paraPrice", price);
            sqlCmd.Parameters.AddWithValue("@paraCategories", categories);
            sqlCmd.Parameters.AddWithValue("@paraImg", img_path);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public List<Service> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Service";

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
                    string img_path = row["img_path"].ToString();
                    int favs = int.Parse(row["favs"].ToString());
                    int views = int.Parse(row["views"].ToString());
                    int uid = int.Parse(row["uid"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Service(name, desc, price, categories, img_path, uid, favs, views, date_create, Id);
                    services.Add(obj);
                }
            }

            return services;
        }

        public List<Service> SelectByUid(string uid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Service WHERE uid=@paraUid";

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
                    string img_path = row["img_path"].ToString();
                    int favs = int.Parse(row["favs"].ToString());
                    int views = int.Parse(row["views"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Service(name, desc, price, categories, img_path, int.Parse(uid), favs, views, date_create, Id);
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
                string img_path = row["img_path"].ToString();
                int uid = int.Parse(row["uid"].ToString());
                int favs = int.Parse(row["favs"].ToString());
                int views = int.Parse(row["views"].ToString());
                obj = new Service(name, desc, price, categories, img_path, uid, favs, views, date_create, int.Parse(id));
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