using System;
using System.Runtime.Serialization;

namespace Superior.Framework.Exception
{
  public abstract class SuperiorExceptionBase : System.Exception
  {
    private readonly Guid _errorGuid;

    /// <summary>
    /// Initializes a new instance of the <see cref="SuperiorExceptionBase"/> class.
    /// </summary>
    /// <param name="message">The error message</param>
    public SuperiorExceptionBase(string message)
      :base(message)
    {
      _errorGuid = Guid.NewGuid();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SuperiorExceptionBase"/> class.
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="innerException">The source exception.  Can be null if there is no inner exception.</param>
    /// <remarks>
    /// If the <paramref name="innerException"/> is also <c>SuperiorExceptionBase</c>,
    /// the error GUID will be copied over.
    /// </remarks>
    public SuperiorExceptionBase(string message, System.Exception innerException)
      : base(message, innerException)
    {
      if (innerException is SuperiorExceptionBase)
      {
        _errorGuid = ((SuperiorExceptionBase)innerException).Guid;
      }
      else
      {
        _errorGuid = Guid.NewGuid();
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SuperiorExceptionBase"/> class. (The serialization constructor.)
    /// </summary>
    /// <param name="info">The standard serialization info.  This will be passed in by .NET framework</param>
    /// <param name="ctx">The standard streaming context.  This will be passed in by .NET framework</param>
    protected SuperiorExceptionBase(SerializationInfo info, StreamingContext ctx)
    {
      _errorGuid = (Guid)info.GetValue("guid", typeof(Guid));
    }

    /// <summary>
    /// The unique error GUID.
    /// </summary>
    /// <remarks>
    /// Each error instance should have an unique error GUID.  For
    /// exceptions wrapping other exceptions, they should have the
    /// same error GUID since they all represents the same operation
    /// error.
    /// </remarks>
    public Guid Guid
    {
      get { return _errorGuid; }
    }
  }
}
