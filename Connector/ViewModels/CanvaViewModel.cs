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
        private ObservableCollection<BasicItem> _basicItems = [];
        [ObservableProperty]
        private ObservableCollection<Relation> _relations = [];

        [RelayCommand]
        internal void AddBasicItem()
        {
            BasicItems.Add(new BasicItem
            {
            });
        }
        [RelayCommand]
        internal void ConnectTo()
        {
            // TODO: stworzyć pomost między View a CreateRelation()
            // NOTE: kliknięcie ponownie anuluje akcję
            // NOTE: kliknięcie BasicItem'u powoduje wywołanie CreateRelation dla przycisku wywołującego oraz kliniętego przycisku, jeśli jest inny niż przycisk wywołujący.
        }

        public void CreateRelation(ref BasicItem source, ref BasicItem target, string type)
        {
            Relations.Add(new Relation(source, target, type));
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
