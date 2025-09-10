
namespace Connector.ViewModels
{
    internal class LoginWindowViewModel : ViewModelBase
    {
        private string _loginButtonText = "Zaloguj";

        public string LoginButtonText
        {
            get => _loginButtonText;
            set => SetProperty(ref _loginButtonText, value);
        }

        public void LoginButtonClick()
        {
            LoginButtonText = "Zalogowano";
            OnPropertyChanged(nameof(LoginButtonText));
        }
    }
}
