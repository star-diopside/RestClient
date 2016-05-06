using RestClient.Messaging;
using System.Windows;
using System.Windows.Interactivity;

namespace RestClient.View.Trigger
{
    public class ExceptionTriggerAction : TriggerAction<Window>
    {
        protected override void Invoke(object parameter)
        {
            var e = parameter as ExceptionMessage;
            if (e != null)
            {
                MessageBox.Show(AssociatedObject, e.Exception.Message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
