using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    using System;
    using System.Globalization;
    /// <summary>
    ///  HTMLHelper of Fckeditor
    /// http://chsword.cnblogs.com/
    /// </summary>
    static public class FckTextBoxExt
    {
        /// <summary>
        /// Fckeditor'sHTMLHelper,can be binding with ViewData
        /// </summary>
        /// <param name="u">HtmlHelper</param>
        /// <param name="name">Html tag 's NAME</param>
        /// <returns></returns>
        public static string FckTextBox(this HtmlHelper u, string name)
        {
            return u.FckTextBox(name, null);
        }
        /// <summary>
        /// Fckeditor'sHTMLHelper
        /// </summary>
        /// <param name="u"></param>
        /// <param name="name">Html name </param>
        /// <param name="value">Content</param>
        /// <returns></returns>
        public static string FckTextBox(this HtmlHelper u, string name, object value)
        {
            return u.FckTextBox(name, value.ToString());
        }
        /// <summary>
        /// Fckeditor’sHTMLHelper
        /// </summary>
        /// <param name="u"></param>
        /// <param name="name">Html name</param>
        /// <param name="value">Content</param>
        /// <returns></returns>
        public static string FckTextBox(this HtmlHelper u, string name, string value)
        {
            if (value == null)
            {
                value = Convert.ToString(u.ViewDataContainer.ViewData[name], CultureInfo.InvariantCulture);
            }

            return string.Format(@"<textarea name=""{0}"" id=""{0}"" rows=""50"" cols=""80"" style=""width:100%; height: 600px"">{1}</textarea>
<script type=""text/javascript"">;
    
    var oFCKeditor = new FCKeditor('{0}') ;

    oFCKeditor.BasePath    = sBasePath ;
oFCKeditor.Height=400;
    oFCKeditor.ReplaceTextarea() ;
</script>
", name, value);

        }
        public static string FckUploadImages(this HtmlHelper u, string name, string value)
        {
            if (value == null)
            {
                value = Convert.ToString(u.ViewDataContainer.ViewData[name], CultureInfo.InvariantCulture);
            }
            return string.Format(@"<textbox name=""{0}"" id = ""{0}"" rows = ""1"" cols=""80"" style=""width:100%"">{1}</textbox>
<script type=""text/javascript"">;
    var oFCKeditor = new FCKeditor('{0}') ;
    oFCKeditor.BasePath    = sBasePath ;
oFCKeditor.Height=400;

    oFCKeditor.ReplaceTextarea() ;
</script>",name,value);
        }
    }
}
