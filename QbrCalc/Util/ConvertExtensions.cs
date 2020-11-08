using System;
using System.Globalization;

namespace QbrCalc.Util
{
  public static class ConvertExtensions
  {
    /// <summary>
    /// Converts the string to an integer;
    /// </summary>
    /// <exception cref="FormatException">Thrown if string does not have a valid integer representation</exception>
    /// <exception cref="OverflowException">Thrown if string has a numeric representation that is too large or too small</exception>
    public static int ToInt(this string value)
    {
      return value.IsNullOrEmpty() 
        ? 0 
        : Convert.ToInt32(value, CultureInfo.CurrentCulture);
    }
  }
}
