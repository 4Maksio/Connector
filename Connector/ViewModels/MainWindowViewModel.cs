using CommunityToolkit.Mvvm.ComponentModel;

namespace Connector.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public MainWindowViewModel()
        {
            CurrentView = new LoginWindowViewModel(OnLoginSuccess);
        }

        private void OnLoginSuccess() => CurrentView = new DashboardViewModel();
    }
}
