using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
    public class Language : DomainTypeCode
    {
        private static IDictionary<int, Language> _languages;

        public static IDictionary<int, Language> Languages
        {
            get
            {
                if (_languages == null)
                {
                  _languages = new Dictionary<int, Language>();
                }
                return _languages;
            }
            set
            {
                _languages = value;
            }
        }

        public enum LanguageName
        {
          English=1,
          French=2,
          Spanish=3
        }
    }
}
