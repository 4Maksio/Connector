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
        [ObservableProperty] private ObservableCollection<BasicItem> _basicItems = [];
        [ObservableProperty] private ObservableCollection<Relation> _relations = [];
        [ObservableProperty] private BasicItem _selectedSource;
        [ObservableProperty] private bool _isConnecting;

        [ObservableProperty] private int _connectCount = 0;

        [RelayCommand]
        internal void AddBasicItem()
        {
            BasicItems.Add(new BasicItem
            {
            });
        }
        [RelayCommand]
        internal void Connect(BasicItem item)
        {
            if (!IsConnecting)
            {
                SelectedSource = item;
                IsConnecting = true;
                return;
            }

            if (SelectedSource == item)
            {
                SelectedSource = null;
                IsConnecting = false;
                return;
            }

            if (SelectedSource != null && item != null && validateRelation(SelectedSource, item))
            {
                var sourceRef = SelectedSource;
                var targetRef = item;
                CreateRelation(ref sourceRef, ref targetRef, "Default");
            }

            SelectedSource = null;
            IsConnecting = false;
        }

        public void CreateRelation(ref BasicItem source, ref BasicItem target, string type)
        {
            if (source == null || target == null) return;
            Relations.Add(new Relation(source, target, type));
            ConnectCount++;
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
            {
                removeRelations(item);
                BasicItems.Remove(item);
            }
            else
                item.Name = tmpName;
        }

        private bool validateRelation(BasicItem source, BasicItem target)
        {
            foreach (Relation r in Relations)
            {
                if (r.Source == source && r.Target == target) return false;
            }
            return true;
        }
        private void removeRelations(BasicItem toRemove)
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
