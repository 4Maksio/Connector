using Avalonia;
using Avalonia.Controls.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Models
{
    internal partial class BasicItem : ObservableObject
    {
        [ObservableProperty] string _name;
        [ObservableProperty] string _description;
        [ObservableProperty] string[] _docs;
        [ObservableProperty] string[] _testArtifacts;
        [ObservableProperty] BasicItem[] _children;
        public readonly string _itemType;

        public string ItemType
        {
            get { return _itemType; }
            set { }
        }

        public BasicItem(
            string itemType,
            string name = "Item",
            string description = "Lorem Ipsum",
            BasicItem[] children = null!,
            string[] docs = null!,
            string[] testArtifacts = null!
            )
        {
            _itemType = itemType;
            Name = name;
            Description = description;
            Children = children ?? [];
            Docs = docs ?? ["https://www.atlassian.com/software/confluence", "https://www.figma.com/"];
            TestArtifacts = testArtifacts ?? ["https://www.atlassian.com/pl/software/jira", "https://www.testrail.com/"];
        }
    }
}
