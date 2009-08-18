using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Lib.FluentHtml
{
	/// <summary>
	/// Base class for a radio button.
	/// </summary>
	public abstract class RadioButtonBase<T> : InputBase<T> where T : RadioButtonBase<T>
	{
    private object _selectedValue;

		protected RadioButtonBase(string name) : base(HtmlInputType.Radio, name) { }

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
      base.PreRender();
    }
	}
}