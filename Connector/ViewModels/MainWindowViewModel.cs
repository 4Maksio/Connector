using CommunityToolkit.Mvvm.ComponentModel;

namespace Connector.ViewModels
{
    internal partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase _currentView;

        public MainWindowViewModel() => CurrentView = new LoginWindowViewModel(OnLoginSuccess);

        private void OnLoginSuccess() => CurrentView = new DashboardViewModel();
    }
}
