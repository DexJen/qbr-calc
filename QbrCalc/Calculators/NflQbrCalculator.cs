using System;

namespace QbrCalc.Calculators
{
  public static class NflQbrCalculator
  {
    private const decimal NFLLimit = 2.375M;

    /// <summary>
    /// Calculates the NFL QBR for the given inputs. 
    /// </summary>
    public static decimal CalculateQbr(int attempts, int completions, int yardsGained, int touchdowns, 
      int interceptions)
    {
      // TODO: Validate the inputs here? 
      var completionVar = (decimal.Divide(completions, attempts) - 0.3M) * 5M;
      if (completionVar > NFLLimit) completionVar = NFLLimit;
      if (completionVar < decimal.Zero) completionVar = 0;

      var yardsVar = (decimal.Divide(yardsGained, attempts) - 3) * 0.25M;
      if (yardsVar > NFLLimit) yardsVar = NFLLimit;
      if (yardsVar < decimal.Zero) yardsVar = 0;

      var touchdownsVar = (decimal.Divide(touchdowns, attempts) * 20M);
      if (touchdownsVar > NFLLimit) touchdownsVar = NFLLimit;
      if (touchdownsVar < decimal.Zero) touchdownsVar = 0;

      var interceptionVar = NFLLimit - (decimal.Divide(interceptions, attempts) * 25);
      if (interceptionVar > NFLLimit) interceptionVar = NFLLimit;
      if (interceptionVar < decimal.Zero) interceptionVar = 0;

      return Math.Round(((completionVar + yardsVar + touchdownsVar + interceptionVar) / 6M) * 100M, 1);
    }
  }
}
