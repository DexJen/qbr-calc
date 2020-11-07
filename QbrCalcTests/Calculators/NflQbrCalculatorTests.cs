using NUnit.Framework;
using QbrCalc.Calculators;

namespace QbrCalcTests.Calculators
{
  [TestFixture]
  public class NflQbrCalculatorTests
  {
    [Test]
    public void NflQbrCalculatorSanityTest()
    {
      // Check that the NflQbrCalculator can handle a few standard tests.
      var result = NflQbrCalculator.CalculateQbr(30, 20, 250, 2, 3);
      Assert.AreEqual(75M, result);

      result = NflQbrCalculator.CalculateQbr(30, 20, 300, 2, 0);
      Assert.AreEqual(121.5M, result);

      result = NflQbrCalculator.CalculateQbr(30, 20, 300, 0, 3);
      Assert.AreEqual(59.7M, result);

      result = NflQbrCalculator.CalculateQbr(40, 15, 250, 0, 0);
      Assert.AreEqual(59.4M, result);

      result = NflQbrCalculator.CalculateQbr(5, 0, 0, 0, 0);
      Assert.AreEqual(39.6M, result);

      result = NflQbrCalculator.CalculateQbr(10, 10, 130, 0, 0);
      Assert.AreEqual(118.8M, result);
    }

    [Test]
    public void NflQbrCalculatorCompletionTests()
    {
      var result = NflQbrCalculator.CalculateQbr(40, 1, 30, 0, 0);
      Assert.AreEqual(39.6M, result);

      result = NflQbrCalculator.CalculateQbr(40, 39, 450, 4, 0);
      Assert.AreEqual(146.9M, result);
    }

    [Test]
    public void NflQbrCalculatorYardsTests()
    {
      var result = NflQbrCalculator.CalculateQbr(45, 14, 100, 0, 0);
      Assert.AreEqual(40.5M, result);

      result = NflQbrCalculator.CalculateQbr(20, 15, 330, 0, 0);
      Assert.AreEqual(116.7M, result);
    }

    [Test]
    public void NflQbrCalculatorTouchdownsTests()
    {
      var result = NflQbrCalculator.CalculateQbr(45, 30, 330, 1, 0);
      Assert.AreEqual(95.6M, result);

      result = NflQbrCalculator.CalculateQbr(45, 30, 350, 6, 0);
      Assert.AreEqual(129.6M, result);
    }

    [Test]
    public void NflQbrCalculatorInterceptionsTests()
    {

    }
  }
}
