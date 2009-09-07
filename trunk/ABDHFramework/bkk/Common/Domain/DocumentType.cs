using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class DocumentType : DomainTypeCode
  {
    private DocumentClassifier _documentClassifier;
    private static IDictionary<int, DocumentType> _documentTypes;

    public DocumentClassifier DocumentClassifier
    {
      get
      {
        return _documentClassifier;
      }
      set
      {
        _documentClassifier = value;
      }
    }

    public static IDictionary<int, DocumentType> DocumentTypes
    {
      get
      {
        if (_documentTypes == null)
        {
          _documentTypes = new Dictionary<int, DocumentType>();
        }
        return _documentTypes;
      }

      set
      {
        _documentTypes = value;
      }
    }

    public bool ExpiredDateRequired { get; set; }
  }
}
