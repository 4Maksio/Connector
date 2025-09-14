﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connector.Views;

namespace Connector.ViewModels
{
    internal class DashboardViewModel : ViewModelBase
    {
        private ViewModelBase _topBar = new TopBarViewModel();
        private ViewModelBase _leftPanel = new LeftPanelViewModel();
        private ViewModelBase _canva = new CanvaViewModel();
        public ViewModelBase TopBar => _topBar;
        public ViewModelBase LeftPanel => _leftPanel;
        public ViewModelBase Canva => _canva;
    }
}
