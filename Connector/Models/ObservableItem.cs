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
        public IEnumerable<string> ChildrenNames => Children.Select(c => c.Name);
        public IEnumerable<string> ChildrenDescriptions => Children.Select(c => c.Description);
        public IEnumerable<string> ChildrenItemTypes => Children.Select(c => c.ItemType);
        public ObservableItem(
            string itemType,
            string name = "Item",
            string description = "Lorem Ipsum",
            BasicItem[] children = null!,
            string[] docs = null!,
            string[] testArtifacts = null!
        ) : base( itemType, name, description, children, docs, testArtifacts)
        {
            IsActive = false;
            X = 0;
            Y = 0;
        }
    }
}
