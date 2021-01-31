using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esource.DAL.service;

namespace Esource.BL.service
{
    public class Service
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public decimal price { get; set; }
        public string categories { get; set; }
        public int uid { get; set; }
        public string date_created { get; set; }
        public string username { get; set; }
        public string status { get; set; }
        public int favs { get; set; }
        public int views { get; set; }

        public Service()
        {

        }

        public Service(string name, string desc, decimal price, string categories, int uid, string username, string status = "", int favs = 0, int views = 0, string date_created = null, int Id=-1)
        {
            this.name = name;
            this.desc = desc;
            this.price = price;
            this.categories = categories;
            this.uid = uid;
            this.username = username;
            this.status = status;
            this.favs = favs;
            this.views = views;
            this.date_created = date_created ?? DateTime.Today.ToString("dd/MM/yyyy");
            this.Id = Id;
        }

        public int AddService()
        {
            int result = new ServiceDAO().Insert(this);
            return result;
        }

        public int UpdateService(string name, string desc, decimal price, string categories, int id)
        {
            int result = new ServiceDAO().UpdateService(name, desc, price, categories, id);
            return result;
        }

        public int Delete(string id, string status = "deleted")
        {
            int result = new ServiceDAO().UpdateStatus(id, status);
            return result;
        }

        public List<Service> SelectAll()
        {
            List<Service> services = new ServiceDAO().SelectAll();
            return services;
        }

        public List<Service> OrderedSelectAll(string param)
        {
            List<Service> services = new ServiceDAO().OrderedSelectAll(param);
            return services;
        }

        public List<Service> SelectByUid(string uid)
        {
            List<Service> services = new ServiceDAO().SelectByUid(uid);
            return services;
        }

        public List<Service> SelectById(string id)
        {
            List<Service> service = new ServiceDAO().SelectById(id);
            return service;
        }

        public int UpdateViews(string id, int views)
        {
            int result = new ServiceDAO().UpdateViews(id, views);
            return result;
        }

        public int Favourite(string id, int favs)
        {
            int result = new ServiceDAO().UpdateFavs(id, favs);
            return result;
        }
    }
}