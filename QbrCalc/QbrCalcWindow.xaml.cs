using System.Windows;
using System.Windows.Controls;

namespace QbrCalc
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class QbrCalcWindow : Window
  {
    public QbrCalcWindow()
    {
      InitializeComponent();
    }

    private void TextBoxGotFocus(object sender, RoutedEventArgs e)
    {
      if (sender is TextBox tb)
      {
        tb.SelectAll();
      }
    }

    private void QbrCalcWindowLoaded(object sender, RoutedEventArgs e)
    {
      PassedAttemptedTextBox.Focus();
    }
  }
}
