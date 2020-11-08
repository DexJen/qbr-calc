using System.Globalization;
using System.Windows.Controls;
using QbrCalc.Util;

namespace QbrCalc.Validation
{
  public class AttemptsValidationRule : ValidationRule
  {
    public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      if (value == null) return new System.Windows.Controls.ValidationResult(true, null);

      if (!(value is string strValue)) return new System.Windows.Controls.ValidationResult(false, "Invalid pass attempts value.");

      if (strValue.IsNullOrEmpty())
      {
        // Don't validate if simply empty
        return new System.Windows.Controls.ValidationResult(true, null);
      }

      if (int.TryParse(strValue, out var attempts) && attempts <= 0)
      {
        return new System.Windows.Controls.ValidationResult(false, "Pass attempts must be greater than zero.");
      }

      return new System.Windows.Controls.ValidationResult(true, null);
    }
  }
}
