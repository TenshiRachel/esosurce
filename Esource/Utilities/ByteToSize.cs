using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esource.Utilities
{
    public static class ByteToSize
    {
        public static string convert(int bytes, decimal dec = 0)
        {
            if (bytes == 0) return "0 bytes";

            int k = 1024;
            string [] sizes = { "Bytes", "KB", "MB", "GB", "TB" };
            List<string> sizeRange = new List<string>(sizes);
            double i = Math.Floor(Math.Log(bytes) / Math.Log(k));

            dec = dec < 0 ? 0 : dec;
            return (bytes / Math.Pow(k, i)).ToString("F" + dec) + " " + sizeRange[int.Parse(i.ToString())];
        }
    }
}