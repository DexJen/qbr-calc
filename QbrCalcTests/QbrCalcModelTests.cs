using NUnit.Framework;
using QbrCalc;
using QbrCalc.Util;

namespace QbrCalcTests
{
  [TestFixture]
  public class QbrCalcModelTests
  {
    [Test]
    public void InitialStateTest()
    {
      var model = new QbrCalcModel();

      model.CalculateNflQbr.Execute(null);

      Assert.IsFalse(model.ValidationError.IsNullOrEmpty());

      model.ValidationError = string.Empty;
      model.CalculateNcaaQbr.Execute(null);

      Assert.IsFalse(model.ValidationError.IsNullOrEmpty());
    }

    [Test]
    public void ValidationTests()
    {
      var model = new QbrCalcModel
      {
        PassesAttempted = "40", 
        PassesCompleted = "41"
      };

      model.CalculateNflQbr.Execute(null);

      Assert.IsFalse(model.ValidationError.IsNullOrEmpty());
      Assert.AreEqual("Passes attempted must be greater than or equal to the passes completed.", model.ValidationError);

      model.ValidationError = string.Empty;
      model.CalculateNcaaQbr.Execute(null);

      Assert.IsFalse(model.ValidationError.IsNullOrEmpty());
      Assert.AreEqual("Passes attempted must be greater than or equal to the passes completed.", model.ValidationError);

      model.PassesAttempted = "0";

      model.ValidationError = string.Empty;
      model.CalculateNcaaQbr.Execute(null);

      Assert.IsFalse(model.ValidationError.IsNullOrEmpty());
      Assert.AreEqual("Pass attempts cannot be zero.", model.ValidationError);
    }

    [Test]
    public void CalculationTests()
    {
      var model = new QbrCalcModel
      {
        PassesAttempted = "35",
        PassesCompleted = "25",
        YardsGained = "340",
        Touchdowns = "2",
        Interceptions = "0"
      };

      model.CalculateNflQbr.Execute(null);

      Assert.IsTrue(model.ValidationError.IsNullOrEmpty());
      Assert.That(model.CalculationResults.Count, Is.EqualTo(1));

      model.CalculateNcaaQbr.Execute(null);

      Assert.IsTrue(model.ValidationError.IsNullOrEmpty());
      Assert.That(model.CalculationResults.Count, Is.EqualTo(2));
    }
  }
}
