using Avalonia;
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
        [ObservableProperty]private string _name;
        [ObservableProperty] string _description;
        [ObservableProperty] string[] _docs;
        [ObservableProperty] string[] _testArtifacts;
        [ObservableProperty] BasicItem[] _children;
        private string _type;

        public string Type => _type;

        public BasicItem(string type)
        {
            Name = "Item";
            _type = type;
            Description = "Lorem Ipsum dolor sit ament. Set solom nut kente lepanto nutrina.";
            Children = [];
            Docs = ["https://www.atlassian.com/software/confluence", "https://www.figma.com/"];
            TestArtifacts = ["https://www.atlassian.com/pl/software/jira", "https://www.testrail.com/"];
        }
    }
}
