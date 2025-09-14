using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData;

namespace Connector.ViewModels
{
    internal partial class LeftPanelViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isHidden;

        public LeftPanelViewModel()
        {
            IsHidden = false;
        }
        public void SwapVisibility() => IsHidden = !IsHidden;
    }
}
