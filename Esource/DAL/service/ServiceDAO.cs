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

            string sqlStmt = "INSERT INTO Service (name, desc, price, date_created, img_path, favs, uid)" +
                "VALUES (@paraName, @paraDesc, @paraPrice, @paraDate, @paraImg, @paraFavs, @paraUid)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraName", service.name);
            sqlCmd.Parameters.AddWithValue("@paraDesc", service.desc);
            sqlCmd.Parameters.AddWithValue("@paraPrice", service.price);
            sqlCmd.Parameters.AddWithValue("@paraDate", service.date_created);
            sqlCmd.Parameters.AddWithValue("@paraImg", service.img_path);
            sqlCmd.Parameters.AddWithValue("@paraFavs", service.favs);
            sqlCmd.Parameters.AddWithValue("@paraUid", service.uid);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateService(string name, string desc, decimal price, string img_path)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Service " +
                "SET name=@paraName, desc=@paraDesc, price=@paraPrice, img_path=@paraImg";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraName", name);
            sqlCmd.Parameters.AddWithValue("@paraDesc", desc);
            sqlCmd.Parameters.AddWithValue("@paraPrice", price);
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
                    string desc = row["desc"].ToString();
                    decimal price = decimal.Parse(row["price"].ToString());
                    string date_create = row["date_created"].ToString();
                    string img_path = row["img_path"].ToString();
                    int favs = int.Parse(row["favs"].ToString());
                    int uid = int.Parse(row["uid"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Service(name, desc, price, img_path, uid, favs, date_create, Id);
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
                    string desc = row["desc"].ToString();
                    decimal price = decimal.Parse(row["price"].ToString());
                    string date_create = row["date_created"].ToString();
                    string img_path = row["img_path"].ToString();
                    int favs = int.Parse(row["favs"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Service(name, desc, price, img_path, int.Parse(uid), favs, date_create, Id);
                    services.Add(obj);
                }
            }

            return services;
        }

        public Service SelectById(string id)
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
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string name = row["name"].ToString();
                string desc = row["desc"].ToString();
                decimal price = decimal.Parse(row["price"].ToString());
                string date_create = row["date_created"].ToString();
                string img_path = row["img_path"].ToString();
                int uid = int.Parse(row["uid"].ToString());
                int favs = int.Parse(row["favs"].ToString());
                obj = new Service(name, desc, price, img_path, uid, favs, date_create, int.Parse(id));
            }

            return obj;
        }
    }
}