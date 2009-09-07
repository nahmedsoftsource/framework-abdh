using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class DocumentClassifier:DomainTypeCode
  {
    private static IDictionary<int, DocumentClassifier> _documentClassifiers;

    public static IDictionary<int, DocumentClassifier> DocumentClassifiers
    {
      get
      {
        if (_documentClassifiers == null)
        {
          _documentClassifiers = new Dictionary<int, DocumentClassifier>();
        }
        return DocumentClassifier._documentClassifiers;
      }
      set
      {
        DocumentClassifier._documentClassifiers = value;
      }
    }

    public struct Codes
    {
      public const int InsuranceForm = 1;
      public const int Credential = 2;
      public const int Paperwork = 3;
    } 
  }
}
