using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Superior.Framework.Exception
{
  /// <summary>
  ///   ObjectNotFoundException is thrown on the interface when an object does not exist in the system.
  /// </summary>
  public sealed class ObjectNotFoundException: SuperiorExceptionBase
  {
    private const string ObjectNotFoundMessage = "The requested object is not found";

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectNotFoundException"/> class.
    /// </summary>
    public ObjectNotFoundException()
      : base(ObjectNotFoundMessage)
    {

    }

    public ObjectNotFoundException(System.Exception innerException)
      : base(ObjectNotFoundMessage, innerException)
    {

    }

        /// <summary>
    /// Initializes a new instance of the <see cref="SuperiorException"/> class.
    /// </summary>
    /// <param name="message">The error message</param>
    public ObjectNotFoundException(string message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SuperiorException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    public ObjectNotFoundException(string message, System.Exception innerException)
      : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SuperiorException"/> class. (This is the serialization constructor.)
    /// </summary>
    /// <param name="info">The standard serialization info.  This will be passed in by .NET framework</param>
    /// <param name="ctx">The standard streaming context.  This will be passed in by .NET framework</param>
    private ObjectNotFoundException(SerializationInfo info, StreamingContext ctx)
      : base(info, ctx)
    {
    }
  }
}
