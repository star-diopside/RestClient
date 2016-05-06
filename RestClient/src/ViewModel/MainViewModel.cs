using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using RestClient.Messaging;
using RestClient.Model;
using System;

namespace RestClient.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        public RestResult RestResult { get; } = new RestResult();
        public string Status { get; private set; } = "レディ";

        public RelayCommand ExitCommand { get; }
        public RelayCommand GetCommand { get; }

        public MainViewModel()
        {
            ExitCommand = new RelayCommand(OnExit);
            GetCommand = new RelayCommand(OnGet);
        }

        private void OnExit()
        {
        }

        private async void OnGet()
        {
            try
            {
                Status = "しばらくお待ちください...";
                await this.RestResult.Get();
            }
            catch (Exception e)
            {
                MessengerInstance.Send(new ExceptionMessage() { Exception = e });
            }
            finally
            {
                Status = "レディ";
            }
        }
    }
}
