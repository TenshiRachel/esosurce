using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esource.DAL.file;

namespace Esource.BL.file
{
    public class File
    {
        public string fileName { get; set; }
        public string fullPath { get; set; }
        public string type { get; set; }
        public decimal size { get; set; }
        public string shareId { get; set; }
        public int uid { get; set; }
        public int Id { get; set; }

        public File()
        {

        }

        public File(string fileName, string fullPath, string type, decimal size, int uid, string shareId = "", int Id = -1)
        {
            this.fileName = fileName;
            this.fullPath = fullPath;
            this.type = type;
            this.size = size;
            this.shareId = shareId;
            this.uid = uid;
            this.Id = Id;
        }

        public int AddFile()
        {
            int result = new FileDAO().Insert(this);
            return result;
        }

        public List<File> SelectByUid(string uid)
        {
            List<File> files = new FileDAO().SelectByUid(uid);
            return files;
        }

        public List<File> SelectByShare(string shareId)
        {
            List<File> files = new FileDAO().SelectByShare(shareId);
            return files;
        }

        public int Remove(string Id)
        {
            int result = new FileDAO().Delete(Id);
            return result;
        }
    }
}