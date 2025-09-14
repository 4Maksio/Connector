using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Input;

namespace Connector.ViewModels
{
    internal class TopBarViewModel : ViewModelBase
    {
        public IRelayCommand ToggleLeftPanel { get; }
        public TopBarViewModel(Action toggleLeftPanelVisibility)
        {
            ToggleLeftPanel = new RelayCommand(() =>
            {
                // tu walidacja hasła
                toggleLeftPanelVisibility?.Invoke();
            });
        }
    }
}
