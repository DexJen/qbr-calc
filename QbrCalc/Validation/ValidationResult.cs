using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QbrCalc.Validation
{
  public class ValidationResult
  {
    public bool IsValid { get; set; }
    public string ErrorMessage { get; set; }

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
