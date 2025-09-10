using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set { _currentView = value; }
        }

        public MainWindowViewModel()
        {
            // na start wczytujemy LoginView
            CurrentView = new LoginWindowViewModel();
        }
    }
}
