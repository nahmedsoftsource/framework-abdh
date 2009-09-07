using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Reflection;

namespace Superior.MobileMedics.Generator
{
  class Program
  {
    public String GenerateFile { get; set; }

    public static String BaseControllerTemplate;
    public static String ParentCommentParamTemplate = @"
    /// <param name=""__PARENT_ID__""></param>";

    public static String ParentParamTemplate = @"__PARENT_ID_TYPE__ __PARENT_ID__";

    public static String DomainObjectUpdateParantIDTemplate = @"
      __DOMAIN_OBJECT__.__PARENT_ID__ = __PARENT_ID__;";

    public static String BaseControllerPathTemplate = @"Controllers\Base\__PACKAGE__\Base__CONTROLLER__Controller.cs";

    public static String ControllerTemplate = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Superior.MobileMedics.MainWebSite.Lib;
using Superior.MobileMedics.MainWebSite.Controllers.Base;
using __DOMAIN_NAMESPACE__;
using __SERVICE_NAMESPACE__;

namespace Superior.MobileMedics.MainWebSite.Controllers
{
  public class __CONTROLLER__Controller : Base__CONTROLLER__Controller
  {
  }
}
";

    public static String ControllerPathTemplate = @"Controllers\__PACKAGE__\__CONTROLLER__Controller.cs";

    public static String RoutePathTemplate = @"Routing\__CONTROLLER__Route.cs";
    public static String BaseRoutePathTemplate = @"Routing\Base\Base__CONTROLLER__Route.cs";

    public static String CreateTemplate;
    public static String EditTemplate;

    public static String CreatePathTemplate = @"Views\Base\__CONTROLLER__\Create.aspx";
    public static String EditPathTemplate = @"Views\Base\__CONTROLLER__\Edit.aspx";

    public static String ListTemplate;
    public static String ListWithoutLayoutTemplate;
    public static String ListPartialTemplate;

    public static String ListPathTemplate = @"Views\Base\__CONTROLLER__\List.aspx";
    public static String ListWithoutLayoutPathTemplate = @"Views\Base\__CONTROLLER__\ListWithoutLayout.aspx";
    public static String ListPartialPathTemplate = @"Views\Shared\Base\__CONTROLLER__\List.ascx";

    public static String InitAttrInControllerContent = "";

    public XElement xml { get; set; }

    public String DomainName { get; set; }
    public String DomainFullName { get; set; }
    public String DomainAssembly { get; set; }
    public String ServiceName { get; set; }
    public String IServiceName { get; set; }
    public String Package { get; set; }
    public String ControllerName { get; set; }
    public String DomainNamespace { get; set; }
    public String ServiceNamespace { get; set; }
    public String DomainObject { get; set; }
    public String Parent { get; set; }
    public String ParentID { get; set; }
    public String ParentIDType { get; set; }

    public String ParentCommentParam { get; set; }
    public String ParentParam { get; set; }
    public String DomainObjectUpdateParantID { get; set; }

    static void Main(string[] args)
    {
      var p = new Program(@"OrderManagement\ApplicantAddress\generator");

      p.Run();
    }

    public Program(String File)
    {
      GenerateFile = File;
      DomainAssembly = "Superior.MobileMedics.Domain";
      CreateTemplate = ReadTemplate("Create");
      EditTemplate = ReadTemplate("Edit");
      ListTemplate = ReadTemplate("List.aspx");
      ListWithoutLayoutTemplate = ReadTemplate("ListWithoutLayout.aspx");
      ListPartialTemplate = ReadTemplate("List.ascx");
      BaseControllerTemplate = ReadTemplate("BaseController");
    }

    /// <summary>
    /// read template
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public String ReadTemplate(String Name)
    {
      var tempDir = AppDomain.CurrentDomain.BaseDirectory + @"..\..\templates\";
      // create reader & open file
      var tr = new StreamReader(tempDir + Name + ".html");

      // read a line of text
      var ret = tr.ReadToEnd();

      // close the stream
      tr.Close();

      return ret;
    }

    /// <summary>
    /// run
    /// </summary>
    public void Run()
    {
      xml = XElement.Load(AppDomain.CurrentDomain.BaseDirectory + @"..\..\generate\package\" + GenerateFile + ".xml");

      var domain = xml.Elements().Where(e => e.Name == "domain").First();
      DomainName = domain.Attribute("name").Value;
      Package = domain.Attribute("package").Value;
      ControllerName = domain.Attribute("controller").Value;

      if (domain.Attribute("parent") != null)
      {
        Parent = domain.Attribute("parent").Value;
        ParentIDType = (domain.Attribute("parentIDType") != null) ? domain.Attribute("parentIDType").Value : "Guid";
      }

      DomainNamespace = "Superior.MobileMedics.Domain." + Package;
      ServiceNamespace = "Superior.MobileMedics.Service." + Package;
      if (domain.Attribute("service") != null)
      {
        ServiceName = domain.Attribute("service").Value;
      }
      else
      {
        ServiceName = DomainName + "Service";
      }

      IServiceName = "I" + ServiceName;
      DomainFullName = DomainNamespace + "." + DomainName;

      DomainObject = char.ToLower(DomainName[0]) + DomainName.Substring(1);

      if (Parent != null)
      {
        ParentID = Parent + "ID";
        ParentCommentParam = Replace(ParentCommentParamTemplate);
        ParentParam = Replace(ParentParamTemplate);
        DomainObjectUpdateParantID = Replace(DomainObjectUpdateParantIDTemplate);
      }

      // build views
      BuildViews();

      // build controller
      BuildController();

      // build routing
      BuildRouting();

      Console.Write("Done!");
    }

    /// <summary>
    /// build controller
    /// </summary>
    public void BuildController()
    {
      var BaseControllerContent = Replace(BaseControllerTemplate);
      SaveFile(Replace(BaseControllerPathTemplate), BaseControllerContent);

      var ControllerContent = Replace(ControllerTemplate);
      SaveFile(Replace(ControllerPathTemplate), ControllerContent, false);
    }

    /// <summary>
    /// build views
    /// </summary>
    public void BuildViews()
    {
      BuildCreateView();
      BuildEditView();
      BuildListView();
    }

    /// <summary>
    /// build create view
    /// </summary>
    public void BuildCreateView()
    {
      var createFieldContent = "";
      Type t = Type.GetType(DomainFullName + ", " + DomainAssembly, true);

      var Create = xml.Elements("actions").First().Elements("Create").SingleOrDefault();

      if (Create == null)
      {
        //return;
      }

      var createFields = Create.Elements("field");

      var allowFields = createFields.Select(e => e.Attribute("name").Value);

      foreach (var item in createFields)
      {
        var fieldName = item.Attribute("name").Value;
        var p = t.GetProperties().Where(prop => prop.Name == fieldName).SingleOrDefault();

        switch (item.Attribute("type").Value)
        {
          case "money":
            createFieldContent += BuildCreateTextField(p, item);
            break;
          case "file":
            createFieldContent += BuildCreateFileField(p, item);
            break;
          case "info":
            createFieldContent += BuildCreateInfoField(p, item);
            break;
          case "select":
            createFieldContent += BuildCreateSelectField(p, item);
            break;
          case "select-multiple":
            createFieldContent += BuildCreateSelectMultipleField(p, item);
            break;
          default:
            createFieldContent += BuildCreateTextField(p, item);
            break;
        }
      }

      //foreach (var item in t.GetProperties())
      //{
      //  if (allowFields.Contains(item.Name)){
      //    switch (item.PropertyType.Name)
      //    {
      //      case "String":
      //        createFieldContent += BuildCreateTextField(item);
      //        break;
      //      default:
      //        break;
      //    }
      //  }
      //}

      var CreateContent = Replace(CreateTemplate)
        .Replace("__CREATE_FIELDS__", createFieldContent);
      ;

      SaveFile(Replace(CreatePathTemplate), CreateContent);
    }

    /// <summary>
    /// build edit view
    /// </summary>
    public void BuildEditView()
    {
      var editFieldContent = "";
      Type t = Type.GetType(DomainFullName + ", " + DomainAssembly, true);

      var Edit = xml.Elements("actions").First().Elements("Edit").SingleOrDefault();

      if (Edit == null)
      {
        //return;
      }

      var editFields = Edit.Elements("field");

      var allowFields = editFields.Select(e => e.Attribute("name").Value);

      foreach (var item in editFields)
      {
        var fieldName = item.Attribute("name").Value;
        var p = t.GetProperties().Where(prop => prop.Name == fieldName).Single();

        switch (item.Attribute("type").Value)
        {
          case "money":
            editFieldContent += BuildEditTextField(p, item);
            break;
          default:

            editFieldContent += BuildEditTextField(p);
            break;
        }
      }
      /*
      foreach (var item in t.GetProperties())
      {
        if (allowFields.Contains(item.Name))
        {
          switch (item.PropertyType)
          {
            case typeof(String):
              editFieldContent += BuildEditTextField(item);
              break;
            default:
              break;
          }

          editFieldContent += item.PropertyType.FullName+ "\n";
        }
      }*/

      var EditContent = Replace(EditTemplate)
        .Replace("__EDIT_FIELDS__", editFieldContent);
      ;

      SaveFile(Replace(EditPathTemplate), EditContent);
    }

    /// <summary>
    /// build create view
    /// </summary>
    public void BuildListView()
    {
      var listFieldContent = "";
      Type t = Type.GetType(DomainFullName + ", " + DomainAssembly, true);

      var Create = xml.Elements("actions").First().Elements("List").SingleOrDefault();

      if (Create == null)
      {
        //return;
      }

      var listFields = Create.Elements("field");

      var allowFields = listFields.Select(e => e.Attribute("name").Value);

      foreach (var item in t.GetProperties())
      {
        if (allowFields.Contains(item.Name))
        {
          switch (item.PropertyType.Name)
          {
            case "String":
              listFieldContent += BuildListTextField(item);
              break;
            default:
              break;
          }
        }
      }

      var ListPartialContent = Replace(ListPartialTemplate)
        .Replace("__LIST_FIELDS__", listFieldContent);
      ;
      var ListContent = Replace(ListTemplate);
      var ListWithoutLayoutContent = Replace(ListWithoutLayoutTemplate);

      SaveFile(Replace(ListPartialPathTemplate), ListPartialContent);
      SaveFile(Replace(ListPathTemplate), ListContent);
      SaveFile(Replace(ListWithoutLayoutPathTemplate), ListWithoutLayoutContent);
    }

    /// <summary>
    /// build routing
    /// </summary>
    public void BuildRouting()
    {
      var RouteTemplate = ReadTemplate("Route");
      SaveFile(Replace(RoutePathTemplate), Replace(RouteTemplate), false);

      var BaseRouteTemplate = ReadTemplate("BaseRoute");
      SaveFile(Replace(BaseRoutePathTemplate), Replace(BaseRouteTemplate), true);
    }

    /// <summary>
    /// create text field
    /// </summary>
    /// <param name="prop"></param>
    /// <returns></returns>
    public String BuildCreateTextField(PropertyInfo prop)
    {
      return BuildCreateTextField(prop, null);
    }

    /// <summary>
    /// create text field
    /// </summary>
    /// <param name="prop"></param>
    /// <returns></returns>
    public String BuildCreateTextField(PropertyInfo prop, XElement item)
    {
      var template = ReadTemplate(@"Create\TextField");
      var requiredTemplate = ReadTemplate(@"Create\Required");

      var ret = ReplaceForView(template, prop, item);

      var required = "";
      if (prop != null && (!prop.PropertyType.IsGenericType || prop.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>)))
      {
        required = requiredTemplate;
      }

      return ret.Replace("__REQUIRED__", required);
    }

    /// <summary>
    /// build upload field
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public String BuildCreateFileField(PropertyInfo prop, XElement item)
    {
      var template = ReadTemplate(@"Create\FileField");
      var requiredTemplate = ReadTemplate(@"Create\Required");

      var ret = ReplaceForView(template, prop, item);

      var required = "";
      if (prop != null && (!prop.PropertyType.IsGenericType || prop.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>)))
      {
        required = requiredTemplate;
      }

      return ret.Replace("__REQUIRED__", required);
    }

    /// <summary>
    /// build info field
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public String BuildCreateInfoField(PropertyInfo prop, XElement item)
    {
      var template = ReadTemplate(@"Create\InfoField");
      var requiredTemplate = ReadTemplate(@"Create\Required");

      var ret = ReplaceForView(template, prop, item);

      var required = "";
      if (prop != null && (!prop.PropertyType.IsGenericType || prop.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>)))
      {
        required = requiredTemplate;
      }

      return ret.Replace("__REQUIRED__", required);
    }

    /// <summary>
    /// build select field
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public String BuildCreateSelectField(PropertyInfo prop, XElement item)
    {
      var template = ReadTemplate(@"Create\SelectField");
      var requiredTemplate = ReadTemplate(@"Create\Required");

      var ret = ReplaceForView(template, prop, item);

      var required = "";
      if (prop != null && (!prop.PropertyType.IsGenericType || prop.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>)))
      {
        required = requiredTemplate;
      }

      var initAttrTemplate = ReadTemplate(@"BaseController\InitAttr\SelectList");
      InitAttrInControllerContent += ReplaceForInitAttr(initAttrTemplate)
        .Replace("__FIELD_NAME__", item.Attribute("name").Value)
        .Replace("__INIT__", item.Attribute("init").Value)
        ;

      return ret.Replace("__REQUIRED__", required);
    }

    /// <summary>
    /// build select multiple field
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public String BuildCreateSelectMultipleField(PropertyInfo prop, XElement item)
    {
      var template = ReadTemplate(@"Create\SelectMultipleField");
      var requiredTemplate = ReadTemplate(@"Create\Required");

      var ret = ReplaceForView(template, prop, item);

      var required = "";
      if (prop != null && (!prop.PropertyType.IsGenericType || prop.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>)))
      {
        required = requiredTemplate;
      }

      var initAttrTemplate = ReadTemplate(@"BaseController\InitAttr\SelectMultipleList");
      InitAttrInControllerContent += ReplaceForInitAttr(initAttrTemplate)
        .Replace("__FIELD_NAME__", item.Attribute("name").Value)
        .Replace("__INIT__", item.Attribute("init").Value)
        ;

      return ret.Replace("__REQUIRED__", required);
    }

    public String ReplaceForInitAttr(String template)
    {
      return template
        .Replace("__DOMAIN__", DomainName)
        ;
    }

    /// <summary>
    /// edit text field
    /// </summary>
    /// <param name="prop"></param>
    /// <returns></returns>
    public String BuildEditTextField(PropertyInfo prop)
    {
      return BuildEditTextField(prop, null);
    }

    /// <summary>
    /// edit text field
    /// </summary>
    /// <param name="prop"></param>
    /// <returns></returns>
    public String BuildEditTextField(PropertyInfo prop, XElement item)
    {
      var template = ReadTemplate(@"Edit\TextField");
      var requiredTemplate = ReadTemplate(@"Edit\Required");

      var ret = ReplaceForView(template, prop, item);

      var required = "";
      if (!prop.PropertyType.IsGenericType || prop.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>))
      {
        required = requiredTemplate;
      }

      return ret
        .Replace("__REQUIRED__", required)
        .Replace("__CURRENCY__", (item != null && item.Attribute("type").Value == "money") ? "USD" : "")

        ;
    }

    /// <summary>
    /// list text field
    /// </summary>
    /// <param name="prop"></param>
    /// <returns></returns>
    public String BuildListTextField(PropertyInfo prop)
    {
      var template = ReadTemplate(@"List\TextField");

      var ret = ReplaceForView(template, prop);

      return ret;
    }

    /// <summary>
    /// replace for view
    /// </summary>
    /// <param name="Template"></param>
    /// <param name="FieldName"></param>
    /// <returns></returns>
    public String ReplaceForView(String Template, PropertyInfo prop)
    {
      return ReplaceForView(Template, prop, null);
    }

    /// <summary>
    /// replace for view
    /// </summary>
    /// <param name="Template"></param>
    /// <param name="FieldName"></param>
    /// <returns></returns>
    public String ReplaceForView(String Template, PropertyInfo prop, XElement item)
    {
      var FieldName = "";
      var FieldFullName = "";
      var FieldToString = "";
      if (prop != null)
      {
        FieldName = prop.Name;
        FieldFullName = prop.Name;
        FieldToString = prop.PropertyType.Name != "String" ? ".ToString()" : "";
      }

      if (item != null)
      {
        if (item.Attribute("name") != null)
        {
          FieldName = item.Attribute("name").Value;
        }

        if (item.Attribute("label") != null)
        {
          FieldFullName = item.Attribute("label").Value;
        }
      }

      var FieldID = FieldName.Replace(".", "_");
      var FieldContent = "";
      if (item != null && item.Attribute("content") != null)
      {
        FieldContent = item.Attribute("content").Value;
      }

      return Replace(Template)
        .Replace("__FIELD_FULL_NAME__", FieldFullName)
        .Replace("__FIELD_NAME__", FieldName)
        .Replace("__FIELD_TOSTRING__", FieldToString)
        .Replace("__FIELD_ID__", FieldID)
        .Replace("__FIELD_CONTENT__", FieldContent)
        ;
    }

    /// <summary>
    /// replace
    /// </summary>
    /// <param name="Template"></param>
    /// <returns></returns>
    public String Replace(String Template)
    {
      return Template
        .Replace("__DOMAIN__", DomainName)
        .Replace("__ISERVICE__", IServiceName)
        .Replace("__SERVICE__", ServiceName)
        .Replace("__PACKAGE__", Package)
        .Replace("__CONTROLLER__", ControllerName)
        .Replace("__DOMAIN_TYPE__", "Guid")
        .Replace("__DOMAIN_NAMESPACE__", DomainNamespace)
        .Replace("__SERVICE_NAMESPACE__", ServiceNamespace)
        .Replace("__DOMAIN_OBJECT__", DomainObject)
        .Replace("__PARENT_COMMENT_PARAM__", ParentCommentParam)
        .Replace("__PARENT_ID__", ParentID)
        .Replace("__PARENT_ID_TYPE__", ParentIDType)
        .Replace("__PARENT_PARAM__", ParentParam)
        .Replace("__DOMAIN_OBJECT_UPDATE_PARENT_ID__", DomainObjectUpdateParantID)
        .Replace("__PARENT_PARAM_1__", Parent != null ? ParentIDType + " " + ParentID : "")
        .Replace("__PARENT_PARAM_2__", Parent != null ? ParentIDType + " " + ParentID + ", " : "")
        .Replace("__PARENT_PARAM_3__", Parent != null ? "?" + ParentID + "=\"+" + ParentID : "") // use for param
        .Replace("__PARENT_PARAM_4__", Parent != null ? ParentID + " = " + ParentID : "") // use for param
        .Replace("__PARENT_PARAM_5__", Parent != null ? string.Format("var {0} = ({1})ViewData[\"{0}\"];", ParentID, ParentIDType) : "") // use for param
        .Replace("__PARENT_PARAM_6__", Parent != null ? string.Format("ViewData[\"{0}\"] = {0};", ParentID) : "") // use for param
        .Replace("__INIT_ATTR_CONTROLLER__", InitAttrInControllerContent)
        ;
    }

    /// <summary>
    /// save file content to main website
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="content"></param>
    public static void SaveFile(String fileName, String content)
    {
      SaveFile(fileName, content, true);
    }

    /// <summary>
    /// save file
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="content"></param>
    /// <param name="replace"></param>
    public static void SaveFile(String fileName, String content, bool replace)
    {
      String WebDir = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\MainWebSite\";
      String filePath = WebDir + fileName;

      if (replace || !File.Exists(filePath))
      {
        var file = new FileInfo(filePath);
        if (!file.Directory.Exists)
        {
          file.Directory.Create();
        }

        TextWriter tw = new StreamWriter(filePath);

        tw.Write(content);

        tw.Close();
        Console.WriteLine("Saved file " + fileName);
      }
      else
      {
        Console.WriteLine("File existed " + fileName);
      }
    }
  }
}
