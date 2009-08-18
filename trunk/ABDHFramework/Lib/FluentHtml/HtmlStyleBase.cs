using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.ComponentModel;
using System.Web.UI.WebControls;
using ABDHFramework;
using System.Text;
using Framework.Lib.FluentHtml;

namespace ABDHFramework.Lib.FluentHtml
{
  public abstract class HtmlStyleBase<T> where T : HtmlStyleBase<T>
  {
    private Dictionary<string, object> _styleAttributes;

    public HtmlStyleBase()
    {
      _styleAttributes = new Dictionary<string, object>();
    }

    public HtmlStyleBase(string styles) : this()
    {
      foreach (var style in styles.Split(';'))
      {
        if (!String.IsNullOrEmpty(style))
        {
          var temp = style.Split(':');
          _styleAttributes.Add(temp[0].Trim(), temp[1].Trim());
        }
      }
    }
    /// <summary>
    /// Adds the style.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public void AddStyle(string key, object value)
    {
      _styleAttributes[key] = value;
    }

    /// <summary>
    /// Removes the style.
    /// </summary>
    /// <param name="key">The key.</param>
    public void RemoveStyle(string key)
    {
      if (_styleAttributes.ContainsKey(key))
      {
        _styleAttributes.Remove(key);
      }
    }

    public bool Contains(string key)
    {
      return _styleAttributes.ContainsKey(key);
    }

    /// <summary>
    ///   Set background color
    /// </summary>
    /// <param name="backColor"></param>
    /// <returns></returns>
    public T BackColor(int value)
    {
      AddStyle(HtmlStyleAttribute.BackColor, FormatColor(value));
      return (T)this;
    }

    /// <summary>
    ///   Set background color
    /// </summary>
    /// <param name="backColor"></param>
    /// <returns></returns>
    public T BackColor(Color value)
    {
      AddStyle(HtmlStyleAttribute.BackColor, FormatColor(value));
      return (T)this;
    }

    /// <summary>
    ///   Set border color
    /// </summary>
    /// <param name="backColor"></param>
    /// <returns></returns>
    public T BorderColor(int value)
    {
      AddStyle(HtmlStyleAttribute.BorderColor, FormatColor(value));
      return (T)this;
    }

    /// <summary>
    ///   Set border color
    /// </summary>
    /// <param name="backColor"></param>
    /// <returns></returns>
    public T BorderColor(Color value)
    {
      AddStyle(HtmlStyleAttribute.BorderColor, FormatColor(value));
      return (T)this;
    }

    /// <summary>
    ///   Set border style
    /// </summary>
    /// <param name="borderStyle"></param>
    /// <returns></returns>
    public T BorderStyle(string value)
    {
      AddStyle(HtmlStyleAttribute.BorderStyle, value.ToString());
      return (T)this;
    }

    /// <summary>
    ///   Set border width
    /// </summary>
    /// <param name="borderWidth"></param>
    /// <returns></returns>
    public T BorderWidth(Unit value)
    {
      AddStyle(HtmlStyleAttribute.BorderWidth, value.ToString());
      return (T)this;
    }

    /// <summary>
    ///   Set text color
    /// </summary>
    /// <param name="foreColor"></param>
    /// <returns></returns>
    public T ForeColor(int value)
    {
      AddStyle(HtmlStyleAttribute.ForeColor, FormatColor(value));
      return (T)this;
    }

    /// <summary>
    ///   Set text color
    /// </summary>
    /// <param name="foreColor"></param>
    /// <returns></returns>
    public T ForeColor(Color value)
    {
      AddStyle(HtmlStyleAttribute.ForeColor, FormatColor(value));
      return (T)this;
    }
    /// <summary>
    ///   Set height
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public T Height(Unit value)
    {
      AddStyle(HtmlStyleAttribute.Height, value.ToString());
      return (T)this;
    }
    /// <summary>
    ///   Set width
    /// </summary>
    /// <param name="width"></param>
    /// <returns></returns>
    public T Width(Unit value)
    {
      AddStyle(HtmlStyleAttribute.Width, value.ToString());
      return (T)this;
    }

    public T MergeStyle(HtmlStyleBase<T> style)
    {
      foreach (var item in style._styleAttributes)
      {
        AddStyle(item.Key, item.Value);
      }
      return (T)this;
    }

    private string FormatColor(int color)
    {
      return "#" + (color & 0xFFFFFF).ToString("X6");
    }

    private string FormatColor(Color color)
    {
      return FormatColor(color.ToArgb());
    }

    public override string ToString()
    {
      StringBuilder str = new StringBuilder();
      foreach (var item in _styleAttributes)
      {
        str.Append(item.Key).Append(":").Append(item.Value).Append(";");
      }
      return str.ToString();
    }
  }
}
