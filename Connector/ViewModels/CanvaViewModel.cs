using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Connector.Models;

namespace Connector.ViewModels
{
    internal partial class CanvaViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<BasicItem> basicItems = [];

        [RelayCommand]
        internal void AddBasicItem()
        {
            BasicItems.Add(new BasicItem
            {
            });
        }

        public CanvaViewModel()
        {
            AddBasicItem();
        }
    }
}
