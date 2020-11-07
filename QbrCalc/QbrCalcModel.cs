using System;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using QbrCalc.Calculators;
using QbrCalc.Util;
using QbrCalc.Validation;
using QbrCalc.ViewModel;

namespace QbrCalc
{
  public class QbrCalcModel : ViewModelBase
  {
    private readonly ValuesValidator _validator;

    private string _passesAttempted;
    private string _passesCompleted;
    private string _yardsGained;
    private string _touchdowns;
    private string _interceptions;
    private string _validationError;

    private RelayCommand _calculateNflQbr;
    private RelayCommand _calculateNcaaQbr;
    private RelayCommand _exitCommand;

    public string PassesAttempted
    {
      get => _passesAttempted;
      set => Set(() => PassesAttempted, ref _passesAttempted, value);
    }

    public string PassesCompleted
    {
      get => _passesCompleted;
      set => Set(() => PassesCompleted, ref _passesCompleted, value);
    }

    public string YardsGained
    {
      get => _yardsGained;
      set => Set(() => YardsGained, ref _yardsGained, value);
    }

    public string Touchdowns
    {
      get => _touchdowns;
      set => Set(() => Touchdowns, ref _touchdowns, value);
    }

    public string Interceptions
    {
      get => _interceptions;
      set => Set(() => Interceptions, ref _interceptions, value);
    }

    public ObservableCollection<QbrCalculationResult> CalculationResults { get; }

    public string ValidationError
    {
      get => _validationError;
      set => Set(() => ValidationError, ref _validationError, value);
    }

    public RelayCommand CalculateNflQbr
    {
      get
      {
        return _calculateNflQbr ?? (_calculateNflQbr = new RelayCommand(() =>
        {
          ValidateInputValues((atp, cmp, yards, tds, ints) =>
          {
            ValidationError = string.Empty;
            var qbr = NflQbrCalculator.CalculateQbr(atp, cmp, yards, tds, ints);
            CalculationResults.Add(new QbrCalculationResult
            {
              CalculationType = "NFL",
              Qbr = $"{qbr:##0.0}"
            });
          });
        }));
      }
    }

    public RelayCommand CalculateNcaaQbr
    {
      get
      {
        return _calculateNcaaQbr ?? (_calculateNcaaQbr = new RelayCommand(() =>
        {
          ValidateInputValues((atp, cmp, yards, tds, ints) =>
          {
            ValidationError = string.Empty;
            var qbr = NcaaQbrCalculator.CalculateQbr(atp, cmp, yards, tds, ints);
            CalculationResults.Add(new QbrCalculationResult
            {
              CalculationType = "NCAA",
              Qbr = $"{qbr:##0.0}"
            });
          });
        }));
      }
    }

    public RelayCommand ExitAppCommand
    {
      get
      {
        return _exitCommand ?? (_exitCommand = new RelayCommand(() =>
        {
          Application.Current?.MainWindow?.Close();
        }));
      }
    }

    public QbrCalcModel()
    {
      _validator = new ValuesValidator();
      _validationError = string.Empty;
      CalculationResults = new ObservableCollection<QbrCalculationResult>();

      if (IsInDesignModeStatic)
      {
        CalculationResults.Add(new QbrCalculationResult{ Qbr = "112.3", CalculationType = "NFL" });
        CalculationResults.Add(new QbrCalculationResult{ Qbr = "90.4", CalculationType = "NCAA" });
      }
    }

    private void ValidateInputValues(Action<int, int, int, int, int> calculateQbr)
    {
      var attempted = PassesAttempted.ToInt();
      var completed = PassesCompleted.ToInt();
      var yardsGained = YardsGained.ToInt();
      var touchdowns = Touchdowns.ToInt();
      var interceptions = Interceptions.ToInt();

      _validator.ValidateInputs(attempted, completed, yardsGained, touchdowns, interceptions)
        .OnFailure(res => ValidationError = res.ErrorMessage)
        .OnSuccess(() =>
        {
          calculateQbr(attempted, completed, yardsGained, touchdowns, interceptions);
        });
    }
  }
}
