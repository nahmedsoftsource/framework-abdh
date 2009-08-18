
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ABDHFramework.Lib.FluentHtml
{
	/// <summary>
	/// Base class for a radio button.
	/// </summary>
	public abstract class CheckBoxBase<T> : InputBase<T> where T : CheckBoxBase<T>
	{
    private object _selectedValue;

    protected CheckBoxBase(string name) : base(HtmlInputType.Checkbox, name) { }

		/// <summary>
		/// Set the checked attribute.
		/// </summary>
		/// <param name="value">Whether the radio button should be checked.</param>
		public virtual T Checked(bool value)
		{
			if (value)
			{
				Attr(HtmlAttribute.Checked, HtmlAttribute.Checked);
			}
			else
			{
				RemoveAttr(HtmlAttribute.Checked);
			}
			return (T)this;
		}

    public virtual T SelectedValue(object value)
    {
      _selectedValue = value;
      return (T)this;
    }

    protected override void PreRender()
    {
      if (_selectedValue != null)
      {
        Checked(FormatValue(_selectedValue) == GetFormattedValue());
      }
      if (GetValue() == null)
      {
        SetValue(true);
      }
      base.PreRender();
    }

    public override string ToString()
    {
      string result = base.ToString();
      object rawValue = GetValue();
      if (rawValue is bool && (bool)rawValue && !string.IsNullOrEmpty(GetAttr(HtmlAttribute.Name))) // make sure the controller always receives true or false
      {
        result += new HiddenField(GetAttr(HtmlAttribute.Name)).Value(false).ToString();
      }
      return result;
    }
	}
}