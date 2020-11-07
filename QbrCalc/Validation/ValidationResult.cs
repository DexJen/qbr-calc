
namespace QbrCalc.Validation
{
  public class ValidationResult
  {
    public bool IsValid { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsInvalid => !IsValid;

    public static ValidationResult Fail(string errorMessage)
    {
      return new ValidationResult
      {
        IsValid = false,
        ErrorMessage = errorMessage
      };
    }
  }
}
