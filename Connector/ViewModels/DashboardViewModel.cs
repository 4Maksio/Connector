using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Connector.Views;

namespace Connector.ViewModels
{
    internal partial class DashboardViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase _leftPanel;
        [ObservableProperty]
        private ViewModelBase _topBar;
        [ObservableProperty]
        private ViewModelBase _canva = new CanvaViewModel();
        public DashboardViewModel()
        {
            LeftPanel = new LeftPanelViewModel(((CanvaViewModel)Canva).AddBasicItem);
            TopBar = new TopBarViewModel(((LeftPanelViewModel)LeftPanel).SwapVisibility);
        }
    }
}
