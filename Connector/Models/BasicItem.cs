using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Connector.Models
{
    internal partial class BasicItem : ObservableObject
    {
        [ObservableProperty]
        public string _name;
        public BasicItem()
        {
            Name = "Default";
        }
    }
}
