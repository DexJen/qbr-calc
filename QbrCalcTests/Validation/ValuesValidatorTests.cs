using NUnit.Framework;
using QbrCalc.Validation;

namespace QbrCalcTests.Validation
{
  [TestFixture]
  public class ValuesValidatorTests
  {
    private ValuesValidator _validator;

    [OneTimeSetUp]
    public void Setup()
    {
      _validator = new ValuesValidator();
    }

    [Test]
    public void ValidateAttemptsTests()
    {
      var result = _validator.ValidateInputs(0, 3, 100, 0, 0);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Pass attempts cannot be zero.", result.ErrorMessage);

      result = _validator.ValidateInputs(-10, 5, 100, 0, 0);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Pass attempts must be greater than zero.", result.ErrorMessage);

      result = _validator.ValidateInputs(10, 11, 100, 0, 0);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Passes attempted must be greater than or equal to the passes completed.", result.ErrorMessage);

      result = _validator.ValidateInputs(20, 19, 200, 0, 0);
      Assert.IsTrue(result.IsValid);
      Assert.IsNull(result.ErrorMessage);
    }

    [Test]
    public void ValidateCompletionsTests()
    {
      var result = _validator.ValidateInputs(20, -3, 200, 0, 0);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Completions cannot be less than zero.", result.ErrorMessage);

      result = _validator.ValidateInputs(20, 19, 200, 0, 0);
      Assert.IsTrue(result.IsValid);
    }

    [Test]
    public void ValidateTouchdownsTests()
    {
      var result = _validator.ValidateInputs(20, 19, 200, -2, 0);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Touchdowns cannot be less than zero.", result.ErrorMessage);

      result = _validator.ValidateInputs(10, 5, 200, 11, 0);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Touchdowns cannot be greater than the number of pass attempts.", result.ErrorMessage);

      result = _validator.ValidateInputs(10, 5, 200, 7, 0);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Touchdowns cannot be greater than the number of completions.", result.ErrorMessage);

      result = _validator.ValidateInputs(20, 15, 300, 3, 1);
      Assert.IsTrue(result.IsValid);
      Assert.IsNull(result.ErrorMessage);
    }

    [Test]
    public void ValidateInterceptionsTests()
    {
      var result = _validator.ValidateInputs(20, 15, 200, 0, -3);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Interceptions cannot be less than zero", result.ErrorMessage);

      result = _validator.ValidateInputs(20, 11, 230, 0, 21);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Interceptions cannot be greater than the number of pass attempts.", result.ErrorMessage);

      result = _validator.ValidateInputs(20, 15, 300, 1, 3);
      Assert.IsTrue(result.IsValid);
      Assert.IsNull(result.ErrorMessage);
    }

    [Test]
    public void OtherValidationsTests()
    {
      var result = _validator.ValidateInputs(15, 10, 250, 10, 6);
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("The touchdowns plus the interceptions cannot be greater than the number of pass attempts.", result.ErrorMessage);

      result = _validator.ValidateInputs(14, 10, 200, 9, 1);
      Assert.IsTrue(result.IsValid);
      Assert.IsNull(result.ErrorMessage);
    }
  }
}
