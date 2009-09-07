using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.Framework
{
  public static class StringExtensions
  {
    /// <summary>
    /// Determines whether a string is null or blank (ignore whitespaces).
    /// </summary>
    /// <param name="str">The input string.</param>
    /// <returns>
    /// 	<c>true</c> if the string is null or blank; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNullOrBlank(this string str)
    {
      return (str == null || str.Trim() == string.Empty);
    }

    /// <summary>
    /// Determines whether a string is null or empty.
    /// </summary>
    /// <param name="str">The input string.</param>
    /// <returns>
    /// 	<c>true</c> if the string is null or empty; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNullOrEmpty(this string str)
    {
      return String.IsNullOrEmpty(str);
    }
  }
}
