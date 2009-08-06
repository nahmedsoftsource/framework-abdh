using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDH_Demo.FrameWork
{
  public class Scope<T> : IDisposable
  {
    #region Private fields
    private bool _hasLeft = false;
    protected bool _isDisposable;
    #endregion

    #region Constructors

    public Scope(T context)
      : this(context, true)
    {

    }

    public Scope(T context, bool isDisposable)
    {
      _isDisposable = isDisposable;
      Context = context;

      if (ScopeStack == null)
      {
        ScopeStack = new Stack<Scope<T>>();
      }

      ScopeStack.Push(this);
    }

    #endregion

    #region Public properties

    public T Context { get; private set; }

    #endregion

    #region Public methods
    /// <summary>
    /// Leave this context scope.  The context
    /// will then be the next last one on the stack.
    /// </summary>
    public void Leave()
    {
      if (!_hasLeft)
      {
        //  Remove it from stack
        if (ScopeStack == null || ScopeStack.Count == 0)
        {
          throw new InvalidOperationException("Error when trying to leave an unknown context scope.");
        }

        Scope<T> delScope = ScopeStack.Pop();

        if (!delScope.Equals(this))
        {
          //  This context scope is not at the top of the stack.
          ScopeStack.Push(delScope);

          throw new InvalidOperationException("This context scope is not at the top of the stack.");
        }
        if (_isDisposable)
        {
          Release();
        }

        //  Clean up the stack object if it is empty
        if (ScopeStack.Count == 0)
        {
          ScopeStack = null;
        }
      }
      _hasLeft = true;
    }

    #endregion

    #region Protected methods

    protected virtual void Release()
    {
      IDisposable disposable = Context as IDisposable;
      if (disposable != null)
      {
        disposable.Dispose();
      }
    }

    #endregion

    #region IDisposable Members

    public void Dispose()
    {
      Leave();
    }

    #endregion

    #region Static methods

    [ThreadStatic]
    private static Stack<Scope<T>> _scopeStack = null;
    private static Stack<Scope<T>> ScopeStack
    {
      get
      {
        if (HttpContext.Current != null)
        {
          return HttpContext.Current.Items[typeof(T).AssemblyQualifiedName] as Stack<Scope<T>>;
        }
        else
        {
          return _scopeStack;
        }
      }
      set
      {
        if (HttpContext.Current != null)
        {
          HttpContext.Current.Items[typeof(T).AssemblyQualifiedName] = value;
        }
        else
        {
          _scopeStack = value;
        }
      }
    }

    public static Scope<T> Current
    {
      get
      {
        Scope<T> scope = null;

        if (ScopeStack != null && ScopeStack.Count > 0)
        {
          scope = ScopeStack.Peek();
        }

        return scope;
      }
    }

    #endregion
  }
}
