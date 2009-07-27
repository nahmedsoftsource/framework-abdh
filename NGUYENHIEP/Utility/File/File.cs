using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;

namespace NGUYENHIEP.Utility.File
{
    public class File
    {
        public static bool SaveFile(HttpPostedFileBase file, out string pathImage,Guid id,string pathFolder)
        {
            pathImage = "";
            if (file.ContentLength > 0 && id!= null && !id.Equals(Guid.Empty))
            {
                try
                {
                    string tagFile = (string)(file.FileName.Split('.')).GetValue(1);
                    string filePath = Path.Combine(pathFolder
                    , Path.GetFileName(id.ToString("N") + "." + tagFile));
                    pathImage = (ConfigurationManager.AppSettings["ImagesNews"] + "/" + ((Guid)id).ToString("N") + "." + tagFile).Replace("~", "");

                    file.SaveAs(filePath);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
