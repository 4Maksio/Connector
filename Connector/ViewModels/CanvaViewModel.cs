using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
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

        [RelayCommand]
        private async Task OpenDialog(BasicItem item)
        {
            string tmpName = item.Name;
            item.Name = "Dedicated to trash";
            if(DialogViewModel.IsOpen)
                return;
            TaskCompletionSource<bool> awaitingConfirmation = new TaskCompletionSource<bool>();
            Dialog dialog = new Dialog(awaitingConfirmation);
            dialog.Show();

            bool result = await awaitingConfirmation.Task;
            if (result)
                BasicItems.Remove(item);
            else
                item.Name = tmpName;
        }
    }
}
