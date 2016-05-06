using GalaSoft.MvvmLight.Messaging;
using RestClient.Messaging;
using System.Windows;
using System.Windows.Interactivity;

namespace RestClient.View.Trigger
{
    public class ExceptionTrigger : TriggerBase<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            Messenger.Default.Register<ExceptionMessage>(AssociatedObject, InvokeActions);
        }

        protected override void OnDetaching()
        {
            Messenger.Default.Unregister<ExceptionMessage>(AssociatedObject);
            base.OnDetaching();
        }
    }
}
