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
        private void OpenDialog()
        {
            Console.WriteLine("Spróbowano otworzyć Dialog. DialogViewModel.IsOpen= "+DialogViewModel.IsOpen);
            if (DialogViewModel.IsOpen)
            {
                Console.WriteLine("Pominięto tworzenie dialogu");
                return;
            }
            Console.WriteLine("Rozpoczęto tworzenie dialogu");
            var dialog = new Dialog();
            dialog.Show();
        }
    }
}
