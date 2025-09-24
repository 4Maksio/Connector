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
    internal partial class DialogViewModel : ViewModelBase, IDisposable
    {
        [ObservableProperty] private string _message;
        [ObservableProperty] private string _confirmText = "Potwierdź";
        [ObservableProperty] private string _cancelText = "Anuluj";
        public static bool IsOpen;
        public event Action? RequestClose = () => IsOpen = false;

        public DialogViewModel(string message = "Default")
        {
            IsOpen = true;
            Message = message;
            Console.WriteLine("Stworzono dialog. Stan IsOpen= "+IsOpen);
        }

        public void Dispose()
        {
            IsOpen = false;
            Console.WriteLine("Zniszczono dialog. Stan IsOpen= "+IsOpen);
        }

        [RelayCommand]
        public void Close() => RequestClose?.Invoke();
    }
}
