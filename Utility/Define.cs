using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace NGUYENHIEP.Utility
{
    public enum NewsType : short
    {        
        Nomal = 0,
        Promotion = 1,
        Recruitment = 2,
        Construction=3
    }

    public enum WarningRegister : short
    {
        DuplicateUserName = 0,
        DuplicateEmail = 1,
        InvalidPassword = 2,
        InvalidEmail = 3
    }
}
