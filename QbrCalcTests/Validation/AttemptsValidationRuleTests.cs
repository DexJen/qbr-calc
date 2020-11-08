using System.Globalization;
using NUnit.Framework;
using QbrCalc.Validation;

namespace QbrCalcTests.Validation
{
  [TestFixture]
  public class AttemptsValidationRuleTests
  {
    [Test]
    public void CanValidateValuesTests()
    {
      var rule = new AttemptsValidationRule();

      var result = rule.Validate(null, CultureInfo.CurrentCulture);
      Assert.IsTrue(result.IsValid);
      Assert.IsNull(result.ErrorContent);


      result = rule.Validate(string.Empty, CultureInfo.CurrentCulture);
      Assert.IsTrue(result.IsValid);
      Assert.IsNull(result.ErrorContent);

      result = rule.Validate(34, CultureInfo.CurrentCulture);
      Assert.IsFalse(result.IsValid);
      Assert.That(result.ErrorContent.ToString(), Is.EqualTo("Invalid pass attempts value."));

      result = rule.Validate("0", CultureInfo.CurrentCulture);
      Assert.IsFalse(result.IsValid);
      Assert.That(result.ErrorContent.ToString(), Is.EqualTo("Pass attempts must be greater than zero."));

      result = rule.Validate("10", CultureInfo.CurrentCulture);
      Assert.IsTrue(result.IsValid);
      Assert.IsNull(result.ErrorContent);
    }
  }
}
