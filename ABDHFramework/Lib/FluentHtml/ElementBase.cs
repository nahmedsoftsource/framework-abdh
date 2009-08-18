using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Framework.Lib.FluentHtml
{
  /// <summary>
  /// Base class for HTML elements.
  /// </summary>
  /// <typeparam name="T">The derived class type.</typeparam>
  public abstract class ElementBase<T>: IElement where T : ElementBase<T>
  {
    protected const string LABEL_FORMAT = "{0}_Label";

    /// <summary>
    /// TagBuilder object used to generate HTML for elements.
    /// </summary>
    public TagBuilder Builder { get; private set; }

    protected string LabelBeforeText { get; set; }
    protected string LabelAfterText { get; set; }
    protected string LabelClass { get; set; }
    public HtmlStyle Style()
    {
      if (_style == null)
      {
        _style = new HtmlStyle();
      }
      return _style;
    }

    private IList<Behaviors.IBehavior> _behaviors;
    private HtmlStyle _style;

    protected ElementBase(string tag)
    {
      Builder = new TagBuilder(tag);
    }

    /// <summary>
    /// Set the 'id' attribute.
    /// </summary>
    /// <param name="value">The value of the 'id' attribute.</param>
    public virtual T Id(string value)
    {
      Builder.MergeAttribute(HtmlAttribute.Id, value, true);
      return (T)this;
    }

    /// <summary>
    /// Add a value to the 'class' attribute.
    /// </summary>
    /// <param name="classToAdd">The value of the class to add.</param>
    public virtual T Class(string classToAdd)
    {
      Builder.AddCssClass(classToAdd);
      return (T)this;
    }

    /// <summary>
    /// Set the 'title' attribute.
    /// </summary>
    /// <param name="value">The value of the 'title' attribute.</param>
    public virtual T Title(string value)
    {
      Builder.MergeAttribute(HtmlAttribute.Title, value, true);
      return (T)this;
    }

    /// <summary>
    /// Set the 'style' attribute. Ex: .Style("width:20px;height:30px")
    /// </summary>
    /// <param name="style">The style. Ex: "width:20px;height:30px"</param>
    /// <returns></returns>
    public virtual T Style(string style)
    {
      Style().MergeStyle(new HtmlStyle(style));
      return (T)this;
    }

    /// <summary>
    /// Set the 'style' attribute. Ex: .Style(new HtmlStyle().Color(Color.Red))
    /// </summary>
    /// <param name="style">The style. Ex: new HtmlStyle().Color(Color.Red)</param>
    /// <returns></returns>
    public virtual T Style(HtmlStyle style)
    {
      Style().MergeStyle(style);
      return (T)this;
    }

    /// <summary>
    /// Set the 'style' attribute. Ex: .Style(s => s.Color(Color.Red))
    /// </summary>
    /// <param name="style">The style. Ex: s => s.Color(Color.Red)</param>
    /// <returns></returns>
    public T Style(Func<HtmlStyle, HtmlStyle> func)
    {
      func(Style());
      return (T)this;
    }

    /// <summary>
    /// Set the 'onclick' attribute.
    /// </summary>
    /// <param name="value">The value for the attribute.</param>
    /// <returns></returns>
    public virtual T OnClick(string value)
    {
      Builder.MergeAttribute(HtmlEventAttribute.OnClick, value, true);
      return (T)this;
    }

    /// <summary>
    /// Set the value of the specified attribute.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    public virtual void SetAttr(string name, object value)
    {
      var valueString = value == null ? null : value.ToString();
      Builder.MergeAttribute(name, valueString, true);
    }

    /// <summary>
    /// Get the value of the specified attribute.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    public virtual string GetAttr(string name)
    {
      string result;
      Builder.Attributes.TryGetValue(name, out result);
      return result;
    }

    /// <summary>
    /// Set the value of a specified attribute.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    public virtual T Attr(string name, object value)
    {
      SetAttr(name, value);
      return (T)this;
    }

    /// <summary>
    /// Generate a label before the element.
    /// </summary>
    /// <param name="value">The inner text of the label.</param>
    /// <param name="class">The value of the 'class' attribute for the label.</param>
    public virtual T Label(string value, string @class)
    {
      LabelClass = @class;
      return Label(value);
    }

    /// <summary>
    /// Generate a label before the element.
    /// </summary>
    /// <param name="value">The inner text of the label.</param>
    public virtual T Label(string value)
    {
      LabelBeforeText = value;
      return (T)this;
    }

    /// <summary>
    /// Generate a label after the element.
    /// </summary>
    /// <param name="value">The inner text of the label.</param>
    /// <param name="class">The value of the 'class' attribute for the label.</param>
    public virtual T LabelAfter(string value, string @class)
    {
      LabelClass = @class;
      return LabelAfter(value);
    }

    /// <summary>
    /// Generate a label after the element.
    /// </summary>
    /// <param name="value">The inner text of the label.</param>
    public virtual T LabelAfter(string value)
    {
      LabelAfterText = value;
      return (T)this;
    }

    public virtual T Do(Behaviors.IBehavior behavior)
    {
      if (behavior != null)
      {
        if (_behaviors == null)
        {
          _behaviors = new List<Behaviors.IBehavior>();
        }
        _behaviors.Add(behavior);
      }
      return (T)this;
    }

    /// <summary>
    /// Remove an attribute.
    /// </summary>
    /// <param name="name">The name of the attribute to remove.</param>
    public void RemoveAttr(string name)
    {
      Builder.Attributes.Remove(name);
    }

    public override string ToString()
    {
      ApplyBehaviors();
      ApplyStyles();
      PreRender();
      var html = RenderLabel(LabelBeforeText);
      html += Builder.ToString(TagRenderMode);
      html += RenderLabel(LabelAfterText);
      return html;
    }

    /// <summary>
    /// How the tag should be closed.
    /// </summary>
    public virtual TagRenderMode TagRenderMode
    {
      get { return TagRenderMode.Normal; }
    }

    protected virtual string RenderLabel(string labelText)
    {
      if (labelText == null)
      {
        return null;
      }
      var labelBuilder = GetLabelBuilder();
      labelBuilder.SetInnerText(labelText);
      return labelBuilder.ToString();
    }

    protected TagBuilder GetLabelBuilder()
    {
      var labelBuilder = new TagBuilder(HtmlTag.Label);
      if (Builder.Attributes.ContainsKey(HtmlAttribute.Id))
      {
        var id = Builder.Attributes[HtmlAttribute.Id];
        labelBuilder.MergeAttribute(HtmlAttribute.For, id);
        labelBuilder.MergeAttribute(HtmlAttribute.Id, string.Format(LABEL_FORMAT, id));
      }
      if (!string.IsNullOrEmpty(LabelClass))
      {
        labelBuilder.MergeAttribute(HtmlAttribute.Class, LabelClass);
      }
      return labelBuilder;
    }

    protected void ApplyBehaviors()
    {
      if (_behaviors == null)
      {
        return;
      }
      foreach (var behavior in _behaviors)
      {
        behavior.Execute(this);
      }
    }

    protected void ApplyStyles()
    {
      if (_style == null)
      {
        return;
      }
      if (Builder.Attributes.ContainsKey(HtmlAttribute.Style))
      {
        _style.MergeStyle(new HtmlStyle(Builder.Attributes[HtmlAttribute.Style]));
      }
      Builder.MergeAttribute(HtmlAttribute.Style, _style.ToString());
    }

    protected virtual void PreRender() { }
  }
}