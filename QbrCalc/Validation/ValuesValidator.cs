
namespace QbrCalc.Validation
{

  public class ValuesValidator
  {
    /// <summary>
    /// Performs basic validation of QBR input parameters. Returns a ValidationResult instance where IsValid is true
    /// when all checks pass. 
    /// </summary>
    public ValidationResult ValidateInputs(int passAttempts, int completions, int yardsGained,
      int touchdowns, int interceptions)
    {
      if (passAttempts == decimal.Zero)
      {
        return ValidationResult.Fail("Pass attempts cannot be zero.");
      }
      if (passAttempts < decimal.Zero)
      {
        return ValidationResult.Fail("Pass attempts must be greater than zero.");
      }

      if (passAttempts < completions)
      {
        return ValidationResult.Fail("Passes attempted must be greater than or equal to the passes completed.");
      }

      if (completions < decimal.Zero)
      {
        return ValidationResult.Fail("Completions cannot be less than zero.");
      }

      if (touchdowns < decimal.Zero)
      {
        return ValidationResult.Fail("Touchdowns cannot be less than zero.");
      }

      if (touchdowns > passAttempts)
      {
        return ValidationResult.Fail("Touchdowns cannot be greater than the number of pass attempts.");
      }

      if (touchdowns > completions)
      {
        return ValidationResult.Fail("Touchdowns cannot be greater than the number of completions.");
      }

      if (interceptions < decimal.Zero)
      {
        return ValidationResult.Fail("Interceptions cannot be less than zero");
      }

      if (interceptions > passAttempts)
      {
        return ValidationResult.Fail("Interceptions cannot be greater than the number of pass attempts.");
      }

      if (touchdowns + interceptions > passAttempts)
      {
        return ValidationResult.Fail("The touchdowns plus the interceptions cannot be greater than the number of pass attempts.");
      }

      return new ValidationResult { IsValid = true };
    }
  }
}
