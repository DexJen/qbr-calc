using NUnit.Framework;
using QbrCalc.Calculators;

namespace QbrCalcTests.Calculators
{
  [TestFixture]
  public class NcaaQbrCalculatorTests
  {
    [Test]
    public void NcaaQbrCalculatorSanityTests()
    {
      var qbr = NcaaQbrCalculator.CalculateQbr(30, 20, 250, 2, 3);
      Assert.AreEqual(138.7M, qbr);

      qbr = NcaaQbrCalculator.CalculateQbr(30, 20, 300, 2, 0);
      Assert.AreEqual(172.7M, qbr);

      qbr = NcaaQbrCalculator.CalculateQbr(30, 5, 100, 0, 0);
      Assert.AreEqual(44.7m, qbr);

      qbr = NcaaQbrCalculator.CalculateQbr(5, 0, 0, 0, 0);
      Assert.AreEqual(decimal.Zero, qbr);

      qbr = NcaaQbrCalculator.CalculateQbr(10, 10, 220, 1, 0);
      Assert.AreEqual(317.8M, qbr);
    }
  }
}
