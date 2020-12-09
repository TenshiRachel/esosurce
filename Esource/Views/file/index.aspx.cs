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
                List<BL.file.File> userfiles = new BL.file.File().SelectByUid(currUserId);
                files.DataSource = userfiles;
                files.DataBind();
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
                string dirPath = Server.MapPath("~/Content/uploads/files/" + currUserId + "/");
                Directory.CreateDirectory(dirPath);
                postedFile.SaveAs(dirPath + fileName);

                file_path = "~/Content/uploads/files/" + currUserId + "/" + fileName;

                BL.file.File file = new BL.file.File(fileName, file_path, postedFile.ContentType, postedFile.ContentLength, int.Parse(currUserId));
                int result = file.AddFile();
                if (result == 1)
                {
                    Toast.success(this, "File(s) uploaded successfully");
                    List<BL.file.File> userfiles = new BL.file.File().SelectByUid(currUserId);
                    files.DataSource = userfiles;
                    files.DataBind();
                }
                else
                {
                    Toast.error(this, "An error occured while adding file");
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
    }
}