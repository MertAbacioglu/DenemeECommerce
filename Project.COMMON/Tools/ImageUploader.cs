using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.COMMON.Tools
{
    public static class ImageUploader
    {
        //HttpPostedFileBase tipini çağrbilmek için referanslardan assembly - system.web kütüphanesini ekledik.
        //guid kullanmak istemezsek dosya ismi çakışmalarını karar mekanizmalarıyla kontrol etmeliyiz.
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);
                string[] fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();
                string fileName = $"{uniqueName}.{extension}";

                if (extension == "jpg" || extension == "jpeg" || extension == "png")
                {
                    //Alttaki File, System.IO kütüphanesi ile çağırılır.Bu kütüphane serverdaki dosyalara müdahele etmemizi sağlar.
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1"; //dosya adin(guid) taklit edildiğinde 1 dönecek.
                    }
                    string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                    file.SaveAs(filePath);
                    return serverPath + fileName;
                }
                return "2"; //secilen dosya uzantısı bizim istediğimiz gibi değil.
            }
            return "3"; //dosya null


        }

    }
}
