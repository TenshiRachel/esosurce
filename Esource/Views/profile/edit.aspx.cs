using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.Utilities;
using System.IO;
using CountryData.Standard;

namespace Esource.Views.profile
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                LblUid.Text = Session["uid"].ToString();
                User user = new User().SelectById(LblUid.Text);
                string [] socialList = user.social.Split(',');
                string [] skillsList = user.skills.Split(',');
                if (!Page.IsPostBack)
                {
                    CountryHelper helper = new CountryHelper();
                    List<string> countries = helper.GetCountries();
                    countries.Insert(0, "Not Set");
                    location.DataSource = countries;
                    location.DataBind();
                    bio.Value = user.bio;
                    if (user.website != "Not Set")
                    {
                        website.Value = user.website;
                    }
                    dob.Value = user.birthday;
                    gender.Value = user.gender;
                    location.Value = user.location;
                    occupation.Value = user.occupation;
                    jobpin.Value = user.jobPin;
                    currUsername.InnerHtml = user.username;
                    string userDirPath = "~/Content/uploads/profile/" + LblUid.Text + "/";
                    if (File.Exists(Server.MapPath(userDirPath) + "banner.png"))
                    {
                        bannerePic.ImageUrl = Page.ResolveUrl(userDirPath + "banner.png");
                    }
                    if (File.Exists(Server.MapPath(userDirPath) + "profilePic.png"))
                    {
                        profilePic.ImageUrl = Page.ResolveUrl(userDirPath + "profilePic.png");
                    }
                    if (socialList.Any())
                    {
                        twitter.Value = socialList[0];
                        instagram.Value = socialList[1];
                        facebook.Value = socialList[2];
                        youtube.Value = socialList[3];
                        deviantart.Value = socialList[4];
                    }
                    if (skillsList.Any())
                    {
                        if (skillsList[0] != null)
                        {
                            skill1.Value = skillsList[0];
                        }
                        if (skillsList.Length > 1)
                        {
                            if (skillsList[1] != null)
                            {
                                skill2.Value = skillsList[1];
                            }
                            if (skillsList[2] != null)
                            {
                                skill3.Value = skillsList[2];
                            }
                            if (skillsList[3] != null)
                            {
                                skill4.Value = skillsList[3];
                            }
                            if (skillsList[4] != null)
                            {
                                skill5.Value = skillsList[4];
                            }
                        }

                    }
                    if (user.type == "client")
                    {
                        usertype.InnerHtml = "Client";
                    }
                }
            }
            else
            {
                Session["error"] = "You need to be logged in to edit your profile";
                Response.Redirect("~/Views/index.aspx");
            }

            if (string.IsNullOrEmpty(jobpin.Value))
            {
                removepinmodallaucher.Visible = false;
            }
            else
            {
                setPinModalLauncher.InnerHtml = "Change PIN";
            }
        }

        public string UpdateSocial(string twitter, string instagram, string facebook, string youtube, string deviantart)
        {
            string social = twitter + "," + instagram + "," + facebook + "," + youtube + "," + deviantart;
            return social;
        }
        

        public bool storeFile(FileUpload fileUpload)
        {
            List<string> acceptedTypes = new List<string>() {
                "image/png",
                "image/jpeg",
                "image/jpg"
            };
            if (acceptedTypes.Contains(fileUpload.PostedFile.ContentType))
            {
                string dirPath = Server.MapPath("~/Content/uploads/profile/" + LblUid.Text + "/");
                Directory.CreateDirectory(dirPath);
                string imgPath = dirPath + "banner.png";
                if (fileUpload.ID == "upload_image")
                {
                    imgPath = dirPath + "profilePic.png";
                }
                if (File.Exists(imgPath))
                {
                    File.Delete(imgPath);
                }
                fileUpload.SaveAs(imgPath);
                return true;
            }
            else
            {
                Toast.error(this, "Only images files are accepted");
                return false;
            }
        }

        protected void updateProfile_Click(object sender, EventArgs e)
        {
            string social = UpdateSocial(twitter.Value, instagram.Value, facebook.Value, youtube.Value, deviantart.Value);
            int result = 0;
            bool valid = true;
            if (!string.IsNullOrEmpty(skill1.Value) || !string.IsNullOrEmpty(skill2.Value) || !string.IsNullOrEmpty(skill3.Value) || !string.IsNullOrEmpty(skill4.Value) || !string.IsNullOrEmpty(skill5.Value))
            {
                string skills = skill1.Value + "," + skill2.Value + "," + skill3.Value + "," + skill4.Value + "," + skill5.Value;
                result = new User().UpdateUser(LblUid.Text, bio.Value, website.Value, dob.Value, gender.Value, location.Value, occupation.Value, social, skills);
            }
            else
            {
                result = new User().UpdateUser(LblUid.Text, bio.Value, website.Value, dob.Value, gender.Value, location.Value, occupation.Value, social);
            }
            if (upload_banner.HasFile)
            {
                valid = storeFile(upload_banner);
            }
            if (upload_image.HasFile)
            {
                valid = storeFile(upload_image);
            }
            if (result == 1 && valid)
            {
                Session["success"] = "Your profile changes have been saved successfully";
                Response.Redirect("~/Views/profile/index.aspx");
            }
            else
            {
                Toast.error(this, "An error occurred while updating profile");
            }
        }

        protected void btn_PIN_Click(object sender, EventArgs e)
        {
            int outParse = 0;
            if (string.IsNullOrEmpty(jobpin.Value))
            {
                Toast.error(this, "Please enter a PIN number");
            }
            else if (jobpin.Value.Length != 6)
            {
                Toast.error(this, "The pin number must be 6 digits long");
            }
            else if (!Int32.TryParse(jobpin.Value, out outParse) && outParse == 0)
            {
                Toast.error(this, "Only numeric digits are accepted");
            }
            else
            {
                User user = new User().SelectById(LblUid.Text);
                Tuple<string, string> enteredhash = Auth.hash(tbcfmpin.Value, user.passSalt);
                if (enteredhash.Item1 == user.password)
                {
                    int result = new User().UpdateJobPin(LblUid.Text, Auth.encrypt(jobpin.Value, Convert.FromBase64String(user.IV)));
                    if (result == 0)
                    {
                        Toast.error(this, "An error occured while setting PIN");
                    }
                    else
                    {
                        Session["success"] = "Job/Request PIN set successfully";
                        Response.Redirect("~/Views/profile/index.aspx");
                    }
                }
                else
                {
                    Toast.error(this, "Incorrect password, please try again");
                }
            }
            
        }

        protected void btnremove_Click(object sender, EventArgs e)
        {
            User user = new User().SelectById(LblUid.Text);
            Tuple<string, string> enteredhash = Auth.hash(tbremove.Value, user.passSalt);
            if (enteredhash.Item1 == user.password)
            {
                int result = new User().UpdateJobPin(LblUid.Text, "");
                if (result == 0)
                {
                    Toast.error(this, "An error occured while removing PIN");
                }
                else
                {
                    Session["success"] = "PIN removed successfully";
                    Response.Redirect("~/Views/profile/index.aspx");
                }
            }
        }
    }
}