using QbrCalc.Validation;
using NUnit.Framework;
using QbrCalc.Util;

namespace QbrCalcTests.Util
{
  [TestFixture]
  public class ResultExtensionsTests
  {
    [Test]
    public void OnFailureTests()
    {
      var error = string.Empty;
      ValidationResult.Fail("Error text")
        .OnFailure(x =>
        {
          error = x.ErrorMessage;
        });

      Assert.That(error, Is.EqualTo("Error text"));

      ValidationResult.Success()
        .OnFailure(x =>
        {
          error = "No error";
        });

      Assert.That(error, Is.EqualTo("Error text"));
    }

    [Test]
    public void OnSuccessTest()
    {
      var called = false;
      ValidationResult.Success()
        .OnSuccess(() =>
        {
          called = true;
        });
      Assert.IsTrue(called);

      called = false;
      ValidationResult.Fail("Error text")
        .OnSuccess(() =>
        {
          called = true;
        });
      Assert.IsFalse(called);
    }
  }
}
