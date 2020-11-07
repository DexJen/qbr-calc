using System;
using QbrCalc.Validation;

namespace QbrCalc.Util
{
  public static class ResultExtensions
  {
    /// <summary>
    /// If result has failed then the onError action is called. Returns result.
    /// </summary>
    public static ValidationResult OnFailure(this ValidationResult result, Action<ValidationResult> onError)
    {
      if (result.IsInvalid) onError(result);
      return result;
    }

    /// <summary>
    /// If result has succeeded then the onSuccess action is called.
    /// </summary>
    public static void OnSuccess(this ValidationResult result, Action onSuccess)
    {
      if (result.IsInvalid) return;
      onSuccess();
    }
  }
}
