using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.IO;
using System.Configuration;

namespace ABDHFramework.Lib
{
  public class DownloadResult : ActionResult
  {

    public DownloadResult()
    {
    }

    public DownloadResult(string virtualPath)
    {
      this.FilePath = virtualPath;
    }

    public string FilePath
    {
      get;
      set;
    }

    public string FileName
    {
      get;
      set;
    }

    public override void ExecuteResult(ControllerContext context)
    {
      if (!String.IsNullOrEmpty(FileName))
      {
        //string type = DocumentFormat.GetFormFormat(FileName)
        //                .Split('|')[1]
        //                .ToLower();
        string type = "";
        string filePath = "";
        if (FilePath != null && FilePath != "" && FilePath.Trim().StartsWith("~"))
        {
          filePath = context.HttpContext.Server.MapPath(FilePath);
        }
        else
        {
          filePath = FilePath;
        }
        if (FilePath != null && FilePath != "")
        {
          bool success = true;
          FileStream fileSystem = null;
          try
          {
            fileSystem = new FileStream(filePath, FileMode.Open);
          }
          catch
          {
            success = false;
          }
          
          if (success)
          {
            long fileLength = fileSystem.Length;
            byte[] Buffer = new byte[(int)fileLength];
            fileSystem.Read(Buffer, 0, (int)fileLength);
            fileSystem.Close();
            context.HttpContext.Response.ContentType = "application/octet-stream";
            context.HttpContext.Response.AddHeader("content-disposition", "attachment; filename=\"" + FileName + "\"");
            context.HttpContext.Response.BinaryWrite(Buffer);
            context.HttpContext.Response.End();
          }
          else
          {
            context.HttpContext.Response.ContentType = "application/octet-stream";
            context.HttpContext.Response.AddHeader("content-disposition", "attachment; filename=\"" + FileName + "\"");
            context.HttpContext.Response.Write("File is not found");
            context.HttpContext.Response.End();
          }

        }
        
      }
    }
  }
}
