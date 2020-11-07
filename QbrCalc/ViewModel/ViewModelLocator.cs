using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace QbrCalc.ViewModel
{
  public class ViewModelLocator
  {
    public ViewModelLocator()
    {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

      SimpleIoc.Default.Register(() => new QbrCalcModel());
    }

    public QbrCalcModel QbrCalcModel => SimpleIoc.Default.GetInstance<QbrCalcModel>();
  }
}
