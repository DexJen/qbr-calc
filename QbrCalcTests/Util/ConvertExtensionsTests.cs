using System;
using NUnit.Framework;
using QbrCalc.Util;

namespace QbrCalcTests.Util
{
  [TestFixture]
  public class ConvertExtensionsTests
  {
    [Test]
    public void ToIntTests()
    {
      var test = "";

      var value = test.ToInt();
      Assert.That(value, Is.EqualTo(0));

      test = "10";
      value = test.ToInt();
      Assert.That(value, Is.EqualTo(10));

      test = "0";
      value = test.ToInt();
      Assert.That(value, Is.EqualTo(0));

      test = "2147483648";
      Assert.Throws<OverflowException>(() =>
      {
        value = test.ToInt();
      });

      test = "-2147483649";
      Assert.Throws<OverflowException>(() =>
      {
        value = test.ToInt();
      });

      test = "1234t";
      Assert.Throws<FormatException>(() =>
      {
        value= test.ToInt();
      });

      test = "23.45";
      Assert.Throws<FormatException>(() =>
      {
        value = test.ToInt();
      });
    }
  }
}
