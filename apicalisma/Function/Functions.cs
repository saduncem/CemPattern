using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace apicalisma.Function
{
    public static class Functions
    {
        public static List<string> GetImageBase64()
        {
            string[] extensions = { ".jpg", ".png"};
            var files = Directory.EnumerateFiles(HttpContext.Current.Server.MapPath("~/Content/img"), "*.*",SearchOption.AllDirectories);
            files = files.Where(s => extensions.Any(ext => ext == Path.GetExtension(s)));
            var result = new List<string>();
            foreach (var item in files)
            {
                Byte[] bytes = File.ReadAllBytes(item);
                String bytefile = Convert.ToBase64String(bytes);
                result.Add(bytefile);
            }
            return result;
        }
    }
}