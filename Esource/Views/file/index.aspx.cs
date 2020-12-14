using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.file;
using Esource.Utilities;

namespace Esource.Views.file
{
    public partial class index : System.Web.UI.Page
    {
        string currUserId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                currUserId = Session["uid"].ToString();
                if (!Page.IsPostBack)
                {
                    List<BL.file.File> userfiles = new BL.file.File().SelectByUid(currUserId);
                    files.DataSource = userfiles;
                    files.DataBind();
                }
            }
            else
            {
                Session["error"] = "You need to be logged in to view files";
                Response.Redirect("~/Views/index.aspx");
            }
        }

        protected void files_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {

            }
        }

        protected void files_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (files.Items.Count > 1)
            {
                filesErr.Visible = true;
            }
        }

        public void storeFile()
        {
            foreach(HttpPostedFile postedFile in upPoster.PostedFiles)
            {
                string file_path = "";

                string fileName = Path.GetFileName(postedFile.FileName);
                string ext = Path.GetExtension(fileName);
                string dirPath = Server.MapPath("~/Content/uploads/files/" + currUserId + "/");
                Directory.CreateDirectory(dirPath);
                postedFile.SaveAs(dirPath + fileName);

                file_path = "~/Content/uploads/files/" + currUserId + "/" + fileName;

                BL.file.File file = new BL.file.File(fileName, file_path, ext, postedFile.ContentLength, int.Parse(currUserId));
                int result = file.AddFile();
                if (result == 0)
                {
                    Toast.error(this, "An error occured while adding file");
                }
                else
                {
                    string newDirPath = Server.MapPath("~/Content/uploads/files/" + currUserId + "/" + result + "/");
                    Directory.CreateDirectory(newDirPath);
                    if (System.IO.File.Exists(dirPath + fileName))
                    {
                        System.IO.File.Delete(dirPath + fileName);
                    }
                    postedFile.SaveAs(newDirPath + fileName);
                    result = new BL.file.File().UpdateFilePath(result.ToString(), newDirPath + fileName, fileName);
                    if (result == 0)
                    {
                        Toast.error(this, "An error occured while adding file");
                    }
                    else
                    {
                        Toast.success(this, "File(s) uploaded successfully");
                        List<BL.file.File> userfiles = new BL.file.File().SelectByUid(currUserId);
                        files.DataSource = userfiles;
                        files.DataBind();
                    }
                }
            }
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            if (upPoster.HasFiles)
            {
                storeFile();
            }
            else
            {
                Toast.error(this, "Please upload a file");
            }
        }

        protected void btn_Download_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Share_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            List<string> fileIds = new List<string>();
            foreach(RepeaterItem item in files.Items)
            {
                CheckBox chkbox = item.FindControl("checkFile") as CheckBox;
                if (chkbox.Checked && chkbox != null)
                {
                    fileIds.Add(chkbox.Attributes["CommandArgument"]);
                }
            }
            foreach(string id in fileIds)
            {
                int result = new BL.file.File().Remove(id);
            }
            List<BL.file.File> userfiles = new BL.file.File().SelectByUid(currUserId);
            files.DataSource = userfiles;
            files.DataBind();
            Toast.success(this, "File(s) deleted successfully");
        }

        protected void btn_Rename_Click(object sender, EventArgs e)
        {
            string fid = "";
            foreach (RepeaterItem item in files.Items)
            {
                CheckBox chkbox = item.FindControl("checkFile") as CheckBox;
                if (chkbox.Checked && chkbox != null)
                {
                    fid = chkbox.Attributes["CommandArgument"];
                }
            }
            BL.file.File file = new BL.file.File().SelectById(fid);
            string newPath = Server.MapPath("~/Content/uploads/files/" + currUserId + "/" + fid + "/");
            System.IO.File.Copy(file.fullPath, newPath + rename_input.Value);
            System.IO.File.Delete(file.fullPath);
            int result = new BL.file.File().UpdateFilePath(fid, newPath + rename_input.Value, rename_input.Value);
            if (result == 0)
            {
                Toast.error(this, "An error occured while renaming file");
            }
            else
            {
                List<BL.file.File> userfiles = new BL.file.File().SelectByUid(currUserId);
                files.DataSource = userfiles;
                files.DataBind();
                Toast.success(this, "File renamed successfully");
            }
        }
    }
}