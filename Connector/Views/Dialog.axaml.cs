using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Connector.ViewModels;

namespace Connector;

public partial class Dialog : Window
{
    private DialogViewModel viewModel;
    public Dialog()
    {
        InitializeComponent();
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        viewModel = new DialogViewModel();
        DataContext = viewModel;
        viewModel.RequestClose += () => Close();
    }
}