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
using ExCSS;

namespace Connector.ViewModels
{
    internal partial class CanvaViewModel : ViewModelBase
    {
        [ObservableProperty] private ObservableCollection<ObservableItem> _observableItems = [];
        [ObservableProperty] private ObservableCollection<Relation> _relations = [];
        [ObservableProperty] private ObservableItem? _selectedSource;
        [ObservableProperty] private bool _isConnecting;

        [ObservableProperty] private int _connectCount = 0;

        [RelayCommand]
        internal void AddBasicItem()
        {
            ObservableItems.Add(new ObservableItem
            {
            });
        }
        [RelayCommand]
        internal void Connect(ObservableItem item)
        {
            if (!IsConnecting)
            {
                IsConnecting = true;
                SelectedSource = item;
                SelectedSource.IsActive = IsConnecting;
                return;
            }

            if (SelectedSource == item)
            {
                IsConnecting = false;
                SelectedSource.IsActive = IsConnecting;
                SelectedSource = null;
                return;
            }

            if (SelectedSource != null && item != null && validateRelation(SelectedSource, item))
            {
                var sourceRef = SelectedSource;
                var targetRef = item;
                CreateRelation(ref sourceRef, ref targetRef, "Default");
            }

            IsConnecting = false;
            if (SelectedSource != null)
            {
                SelectedSource.IsActive = IsConnecting;
                SelectedSource = null;
            }
        }

        public void CreateRelation(ref ObservableItem source, ref ObservableItem target, string type)
        {
            if (source == null || target == null) return;
            Relations.Add(new Relation(source, target, type));
            ConnectCount++;
        }

        [RelayCommand]
        private async Task OpenDialog(ObservableItem item)
        {
            if(DialogViewModel.IsOpen)
                return;
            TaskCompletionSource<bool> awaitingConfirmation = new TaskCompletionSource<bool>();
            Dialog dialog = new Dialog(awaitingConfirmation);
            dialog.Show();

            bool result = await awaitingConfirmation.Task;
            if (result)
            {
                if (SelectedSource != null && SelectedSource.Equals(item))  // Jeśli łączenie jest w toku
                    Connect(item);                                          // Samopołączenie resetuje proces łączenia
                removeRelations(item);
                ObservableItems.Remove(item);
            }
        }

        private bool validateRelation(ObservableItem source, ObservableItem target)
        {
            foreach (Relation r in Relations)
            {
                if (r.Source == source && r.Target == target) return false;
            }
            return true;
        }
        private void removeRelations(ObservableItem toRemove)
        {
            for(int i=1; i<=Relations.Count; i++)
            {
                if (Relations[Relations.Count-i].Source == toRemove || Relations[Relations.Count - i].Target == toRemove)
                {
                    Relations.RemoveAt(Relations.Count - i);
                    ConnectCount--;
                    i--;
                }
            }
        }
    }
}
