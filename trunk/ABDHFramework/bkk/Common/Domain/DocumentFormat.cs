using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class DocumentFormat : DomainTypeCode
  {
    private string _fileExtension;
    private static IDictionary<int, DocumentFormat> _documentFormats;

    public string FileExtension
    {
      get
      {
        return _fileExtension;
      }
      set
      {
        _fileExtension = value;
      }
    }

    public static IDictionary<int, DocumentFormat> DocumentFormats
    {
      get
      {
        if (_documentFormats == null)
        {
          _documentFormats = new Dictionary<int, DocumentFormat>();
        }
        return _documentFormats;

      }
      set { _documentFormats = value; }
    }



    public static String GetFormFormat(String fileName)
    {
      string ext = System.IO.Path.GetExtension(fileName).ToLower();
      if (ext.Length == 0)
        return "0|" + DocumentFormat.DocumentFormats[0].Name;
      IDictionary<int, Common.Domain.DocumentFormat> formats = DocumentFormat.DocumentFormats;
      foreach (var item in formats)
      {
        if (item.Value.FileExtension != null && item.Value.FileExtension.ToLower().Contains(ext))
        {
          if (item.Value.FileExtension.ToLower().Split(';').Contains(ext.ToLower()))
          {
            return item.Key.ToString() + "|" + item.Value.Name;
          }
          else if (item.Value.FileExtension.ToLower().Split(',').Contains(ext.ToLower()))
          {
            return item.Key.ToString() + "|" + item.Value.Name;
          }
        }
      }
      return "0|" + DocumentFormat.DocumentFormats[0].Name;
    }
  }
}
