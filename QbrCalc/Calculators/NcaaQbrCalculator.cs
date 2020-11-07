using System;

namespace QbrCalc.Calculators
{
  public static class NcaaQbrCalculator
  {
    private const decimal NcaaYardsFactor = 8.4M;
    private const decimal NcaaTouchdownFactor = 330M;
    private const decimal NcaaCompletionFactor = 100M;
    private const decimal NcaaInterceptionFactor = 200M;

    /// <summary>
    /// Calculates the NCAA QBR for the given values
    /// </summary>
    public static decimal CalculateQbr(int attempts, int completions, int yardsGained, int touchdowns,
      int interceptions)
    {
      return Math.Round(
        decimal.Divide((NcaaYardsFactor * yardsGained) + (NcaaTouchdownFactor * touchdowns) + (NcaaCompletionFactor * completions)
                         - (NcaaInterceptionFactor * interceptions), attempts), 1);
    }
  }
}
