
namespace QbrCalc.Validation
{
  public class ValidationResult
  {
    public bool IsValid { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsInvalid => !IsValid;

    /// <summary>
    /// Returns a failed (invalid) ValidationResult instance using errorMessage
    /// </summary>
    public static ValidationResult Fail(string errorMessage)
    {
      return new ValidationResult
      {
        IsValid = false,
        ErrorMessage = errorMessage
      };
    }

    /// <summary>
    /// Returns a successful ValidationResult instance
    /// </summary>
    /// <returns></returns>
    public static ValidationResult Success()
    {
      return new ValidationResult
      {
        IsValid = true,
        ErrorMessage = string.Empty
      };
    }
  }
}
