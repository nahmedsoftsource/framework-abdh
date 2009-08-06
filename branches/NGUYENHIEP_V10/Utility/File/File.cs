using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace NGUYENHIEP.Utility.File
{
    public class File
    {
        public static bool SaveFile(HttpPostedFileBase file, out string pathImage, out string pathImageThumb, out string pathImageThumbsmallest, Guid id, string pathFolder,string absolutePath)
        {
            pathImage = "";
            pathImageThumb = "";
            pathImageThumbsmallest = "";
            if (file.ContentLength > 0 && id!= null && !id.Equals(Guid.Empty))
            {
                try
                {
                    string tagFile = (string)(file.FileName.Split('.')).GetValue(1);
                    string filePath = Path.Combine(pathFolder
                    , Path.GetFileName(id.ToString("N") + "." + tagFile));
                    pathImage = (ConfigurationManager.AppSettings["ImagesNews"] + "/" + ((Guid)id).ToString("N") + "." + tagFile).Replace("~", "");
                    pathImageThumb = (ConfigurationManager.AppSettings["ThumbImagesNews"] + "/" + ((Guid)id).ToString("N") + "." + tagFile).Replace("~", "");
                    pathImageThumbsmallest = (ConfigurationManager.AppSettings["ThumbImagesNewsSmallest"] + "/" + ((Guid)id).ToString("N") + "." + tagFile).Replace("~", "");
                    
                    file.SaveAs(filePath);
                    string absolutefull = absolutePath+pathImage.Substring(1).Replace("/","\\");
                    string pathImageThumbtoSave = absolutePath + pathImageThumb.Substring(1).Replace("/", "\\"); ;
                    string pathImageThumbsmallestToSave = absolutePath + pathImageThumbsmallest.Substring(1).Replace("/", "\\"); ;
                    using (System.Drawing.Image Img =
                      System.Drawing.Image.FromFile(absolutefull))
                    {
                        Size ThumbNailSizeSmallest = new Size(47, 51);

                        using (System.Drawing.Image ImgThnail =
                            new Bitmap(Img, ThumbNailSizeSmallest.Width, ThumbNailSizeSmallest.Height))
                        {
                            ImgThnail.Save(pathImageThumbsmallestToSave, Img.RawFormat);
                            ImgThnail.Dispose();
                        }
                        Img.Dispose();
                    }
                    using (System.Drawing.Image Img =
                      System.Drawing.Image.FromFile(absolutefull))
                    {
                        Size ThumbNailSize = new Size(124, 150);

                        using (System.Drawing.Image ImgThnail =
                            new Bitmap(Img, ThumbNailSize.Width, ThumbNailSize.Height))
                        {
                            ImgThnail.Save(pathImageThumbtoSave, Img.RawFormat);
                            ImgThnail.Dispose();
                        }
                        Img.Dispose();
                    }
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
