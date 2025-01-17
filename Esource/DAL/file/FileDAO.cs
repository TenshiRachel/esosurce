﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Esource.BL.file;

namespace Esource.DAL.file
{
    public class FileDAO
    {
        public int Insert(File file)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO [File] (fileName, fullPath, type, size, shareId, uid) OUTPUT INSERTED.Id " +
                "VALUES (@paraName, @paraPath, @paraType, @paraSize, @paraShareid, @paraUid)";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraName", file.fileName);
            sqlCmd.Parameters.AddWithValue("@paraPath", file.fullPath);
            sqlCmd.Parameters.AddWithValue("@paraType", file.type);
            sqlCmd.Parameters.AddWithValue("@paraSize", file.size);
            sqlCmd.Parameters.AddWithValue("@paraShareId", file.shareId);
            sqlCmd.Parameters.AddWithValue("@paraUid", file.uid);

            conn.Open();
            result = (int)sqlCmd.ExecuteScalar();
            conn.Close();

            return result;
        }

        public List<File> SelectByUid(string uid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM [File] WHERE uid=@paraUid";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraUid", uid);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            File obj = null;
            List<File> files = new List<File>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string name = row["fileName"].ToString();
                    string path = row["fullPath"].ToString();
                    string type = row["type"].ToString();
                    string size = row["size"].ToString();
                    string shareId = row["shareId"].ToString();
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new File(name, path, type, size, int.Parse(uid), shareId, Id);
                    files.Add(obj);
                }
            }

            return files;
        }

        public List<File> SelectByShare(string shareId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM [File]";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            File obj = null;
            List<File> files = new List<File>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string name = row["fileName"].ToString();
                    string path = row["fullPath"].ToString();
                    string type = row["type"].ToString();
                    string size = row["size"].ToString();
                    string shareIds = row["shareId"].ToString();
                    int uid = int.Parse(row["uid"].ToString());
                    int Id = int.Parse(row["Id"].ToString());
                    string[] sharedIdList = shareIds.Split(','); 
                    if (sharedIdList.Contains(shareId))
                    {
                        obj = new File(name, path, type, size, uid, shareId, Id);
                        files.Add(obj);
                    }
                }
            }

            return files;
        }

        public File SelectById(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM [File] WHERE Id=@paraId";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, conn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            File obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string name = row["fileName"].ToString();
                string path = row["fullPath"].ToString();
                string type = row["type"].ToString();
                string size = row["size"].ToString();
                int uid = int.Parse(row["uid"].ToString());
                string shareId = row["shareId"].ToString();
                obj = new File(name, path, type, size, uid, shareId, int.Parse(id));
            }

            return obj;
        }

        public int UpdateShare(string id, string shares)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [File] " +
                "SET shareId = @paraShare " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraShare", shares);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateFilePath(string id, string filePath, string fileName)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [File] " +
                "SET fullPath = @paraPath, fileName = @paraName " +
                "WHERE Id = @paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraPath", filePath);
            sqlCmd.Parameters.AddWithValue("@paraName", fileName);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int Delete(string Id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(DBConnect);

            string sqlStmt = "DELETE FROM [File] WHERE Id=@paraId";

            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, conn);

            sqlCmd.Parameters.AddWithValue("@paraId", Id);

            conn.Open();
            result = sqlCmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}