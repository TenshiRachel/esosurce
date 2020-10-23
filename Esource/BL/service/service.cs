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
        public int uid { get; set; }
        public string date_created { get; set; }
        public string img_path { get; set; }
        public int favs { get; set; }

        public Service()
        {

        }

        public Service(string name, string desc, decimal price, string img_path, int uid, int favs = 0, string date_created = null, int Id=-1)
        {
            this.name = name;
            this.desc = desc;
            this.price = price;
            this.img_path = img_path;
            this.uid = uid;
            this.favs = favs;
            this.date_created = date_created ?? DateTime.Today.ToString("dd/MM/yyyy");
            this.Id = Id;
        }

        public int AddService(Service service)
        {
            int result = new ServiceDAO().Insert(this);
            return result;
        }

        public int UpdateService(string name, string desc, decimal price, string img_path)
        {
            int result = new ServiceDAO().UpdateService(name, desc, price, img_path);
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

        public Service SelectById(string id)
        {
            Service service = new ServiceDAO().SelectById(id);
            return service;
        }
    }
}