using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Connector.Models
{
    internal partial class Relation : ObservableObject
    {
        [ObservableProperty] private BasicItem _source;
        [ObservableProperty] private BasicItem _target;
        [ObservableProperty] private string _type;

        public Relation(BasicItem source, BasicItem target, string type="Default")
        {
            Source = source;
            Target = target;
            Type = type;
        }
    }
}
