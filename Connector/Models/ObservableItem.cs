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
        public ObservableItem() : base()
        {
            IsActive = false;
        }
    }
}
