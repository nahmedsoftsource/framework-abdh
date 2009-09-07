using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Superior.Framework.Exception
{
  /// <summary>
  /// SuperiorException is the standard thrown exception for all exceptions that can not reasonably be assigned
  /// to a more specific exception type.
  /// </summary>
  /// <remarks>To catch exceptions, catch the <see cref="SuperiorExceptionBase"/> type.</remarks>
  [Serializable]
  public sealed class SuperiorException : SuperiorExceptionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SuperiorException"/> class.
    /// </summary>
    /// <param name="message">The error message</param>
    public SuperiorException(string message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SuperiorException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    public SuperiorException(string message, System.Exception innerException)
      : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SuperiorException"/> class. (This is the serialization constructor.)
    /// </summary>
    /// <param name="info">The standard serialization info.  This will be passed in by .NET framework</param>
    /// <param name="ctx">The standard streaming context.  This will be passed in by .NET framework</param>
    private SuperiorException(SerializationInfo info, StreamingContext ctx)
      : base(info, ctx)
    {
    }

  }
}
