using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;

namespace Connector.ViewModels
{
    internal partial class LeftPanelViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isHidden;

        public IRelayCommand AddBasicItem { get; }
        public IRelayCommand ToggleLeftPanel { get; }
        public LeftPanelViewModel(Action clickAddButton)
        {
            IsHidden = false;
            AddBasicItem = new RelayCommand(() =>
            {
                clickAddButton?.Invoke();
            });
            ToggleLeftPanel = new RelayCommand(() =>
            {
                SwapVisibility();
            });
        }
        public void SwapVisibility() => IsHidden = !IsHidden;
    }
}
