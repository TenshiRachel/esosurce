using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esource.DAL.service;

namespace Esource.BL.service
{
    public class Fav
    {
        public int uid { get; set; }
        public int sid { get; set; }

        public Fav()
        {

        }

        public Fav(int uid, int sid)
        {
            this.uid = uid;
            this.sid = sid;
        }

        public int Add()
        {
            int result = new FavDAO().Insert(this);
            return result;
        }

        public int Remove(int uid, int sid)
        {
            int result = new FavDAO().Remove(uid, sid);
            return result;
        }

        public List<string> SelectUserFavs(string uid)
        {
            List<string> sids = new FavDAO().SelectUserFavs(uid);
            return sids;
        }
    }
}