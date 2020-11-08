
namespace QbrCalc.Util
{
  public static class StringExtensions
  {
    /// <summary>
    /// Tests a string for null or the empty string
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public static bool IsNullOrEmpty(this string value)
    {
      return string.IsNullOrEmpty(value);
    }
  }
}
