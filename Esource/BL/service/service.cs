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
        public string img_path { get; set; }
        public int favs { get; set; }
        public int views { get; set; }

        public Service()
        {

        }

        public Service(string name, string desc, decimal price, string categories, string img_path, int uid, int favs = 0, int views = 0, string date_created = null, int Id=-1)
        {
            this.name = name;
            this.desc = desc;
            this.price = price;
            this.categories = categories;
            this.img_path = img_path;
            this.uid = uid;
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

        public int UpdateService(string name, string desc, decimal price, string categories, string img_path, int id)
        {
            int result = new ServiceDAO().UpdateService(name, desc, price, categories, img_path, id);
            return result;
        }

        public List<Service> SelectAll()
        {
            List<Service> services = new ServiceDAO().SelectAll();
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
    }
}