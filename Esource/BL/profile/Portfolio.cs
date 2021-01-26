using Esource.DAL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esource.BL.profile
{
    public class Portfolio
    {
        public int Id { get; set; }
        public int uid { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string content { get; set; }
        public string datePosted { get; set; }
        public int views { get; set; }
        public string likes { get; set; }

        public Portfolio()
        {

        }

        public Portfolio(int uid, string title, string category, string content, string likes, string datePosted = null, int views = 0, int Id = -1)
        {
            this.uid = uid;
            this.title = title;
            this.category = category;
            this.content = content;
            this.datePosted = datePosted ?? DateTime.Today.ToString("dd/MM/yyyy");
            this.views = views;
            this.likes = likes;
        }

        public int AddPortfolio()
        {
            int result = new PortfolioDAO().Insert(this);
            return result;
        }

        public Portfolio SelectByUid(int uid)
        {
            Portfolio portfolio = new PortfolioDAO().SelectByUid(uid);
            return portfolio;
        }

        public Portfolio SelectById(int ID)
        {
            Portfolio portfolio = new PortfolioDAO().SelectById(ID);
            return portfolio;
        }

        public int UpdatePortfolio(string title, string category, string content, string uid)
        {
            int result = new PortfolioDAO().UpdatePortfolio(title, category, content, uid);
            return result;
        }

        public int UpdateViews(string views, string uid)
        {
            int result = new PortfolioDAO().UpdateViews(views, uid);
            return result;
        }

        public int UpdateLikes(string likes, string uid)
        {
            int result = new PortfolioDAO().UpdateLikes(likes, uid);
            return result;
        }
    }
}