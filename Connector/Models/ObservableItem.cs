using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Connector.Models
{
    internal partial class ObservableItem : BasicItem
    {
        [ObservableProperty] bool _isActive;
        [ObservableProperty] double _x;
        [ObservableProperty] double _y;
        public ObservableItem(string type) : base(type)
        {
            IsActive = false;
            X = 0;
            Y = 0;
        }
    }
}
