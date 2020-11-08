using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QbrCalc.Behaviors
{
  /// <summary>
  /// Attached/Dependent property that can be applied to TextBox controls to only allow numeric entry. Only 0-9 are allowed.
  /// </summary>
  public static class NumericOnlyBehavior
  {
    public static readonly DependencyProperty IsEnabledProperty =
      DependencyProperty.RegisterAttached("IsEnabled", typeof(bool),
        typeof(NumericOnlyBehavior), new UIPropertyMetadata(false, OnValueChanged));

    public static bool GetIsEnabled(Control ctrl)
    {
      return (bool) ctrl.GetValue(IsEnabledProperty);
    }

    public static void SetIsEnabled(Control ctrl, bool value)
    {
      ctrl.SetValue(IsEnabledProperty, value);
    }

    private static void OnValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
      if (!(dependencyObject is Control element)) return;

      if (e.NewValue is bool boolValue && boolValue)
      {
        element.PreviewTextInput += OnTextInput;
        element.PreviewKeyDown += OnPreviewKeyDown;
        DataObject.AddPastingHandler(element, OnPaste);
      }
      else
      {
        element.PreviewTextInput -= OnTextInput;
        element.PreviewKeyDown -= OnPreviewKeyDown;
        DataObject.RemovePastingHandler(element, OnPaste);
      }
    }

    private static void OnTextInput(object sender, TextCompositionEventArgs e)
    {
      if (e.Text.Any(c => !char.IsDigit(c))) e.Handled = true;
    }

    private static void OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Space) e.Handled = true;
    }

    private static void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
      if (e.DataObject.GetDataPresent(DataFormats.Text))
      {
        var text = Convert.ToString(e.DataObject.GetData(DataFormats.Text)).Trim();
        if (text.Any(c => !char.IsDigit(c)))
        {
          e.CancelCommand();
        }
      }
      else
      {
        e.CancelCommand();
      }
    }
  }
}
