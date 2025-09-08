using CommunityToolkit.Mvvm.ComponentModel;

namespace Connector.ViewModels
{
    internal class LoginWindowViewModel : ViewModelBase
    {
        private string _loginButtonText = "Zaloguj";

        public string LoginButtonText
        {
            get { return _loginButtonText; }
            set { _loginButtonText = value; }
        }

        public void LoginButtonClick()
        {
            LoginButtonText = "Zalogowano";
            OnPropertyChanged(nameof(LoginButtonText));
        }
    }
}
