using System;
using CommunityToolkit.Mvvm.Input;

namespace Connector.ViewModels
{
    internal class LoginWindowViewModel : ViewModelBase
    {
        public IRelayCommand LoginButtonClick { get; }
        public LoginWindowViewModel(Action onLoginSuccess)
        {
            LoginButtonClick = new RelayCommand(() =>
            {
                // tu walidacja hasła
                onLoginSuccess?.Invoke();
            });
        }
    }
}
