using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ABDHFramework.Lib.FluentHtml
{
  public abstract class ContainerElementBase<T>: ElementBase<T> where T: ContainerElementBase<T>
  {
    private IList<IElement> _innerElements;

    public ContainerElementBase():base(HtmlTag.Div) { }

    public virtual T InnerElement(IElement element)
    {
      if (_innerElements == null)
      {
        _innerElements = new List<IElement>();
      }
      _innerElements.Add(element);
      return (T)this;
    }

    protected override void PreRender()
    {
      if (_innerElements != null)
      {
        StringBuilder strBuilder = new StringBuilder();
        foreach (var item in _innerElements)
        {
          strBuilder.Append(item.ToString());
        }
        Builder.InnerHtml = strBuilder.ToString();
      }
      base.PreRender();
    }
  }
}
