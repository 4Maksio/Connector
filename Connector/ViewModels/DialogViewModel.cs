using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Connector.ViewModels
{
    internal partial class DialogViewModel : ViewModelBase
    {
        [ObservableProperty] private string _message;
        [ObservableProperty] private string _confirmText = "Potwierdź";
        [ObservableProperty] private string _cancelText = "Anuluj";
        public static bool IsOpen;
        public event Action? RequestClose = () => IsOpen = false;
        private TaskCompletionSource<bool> _task;

        public DialogViewModel(TaskCompletionSource<bool> task, string message)
        {
            IsOpen = true;
            Message = message;
            _task = task;
        }
        [RelayCommand]
        public void Confirm()
        {
            _task.TrySetResult(true);
            Close();
        }
        [RelayCommand]
        public void Cancel()
        {
            _task.TrySetResult(false);
            Close();
        }
        [RelayCommand]
        public void Close() => RequestClose?.Invoke();
    }
}
