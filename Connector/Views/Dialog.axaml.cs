using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Connector.ViewModels;
using Tmds.DBus.Protocol;

namespace Connector;

public partial class Dialog : Window
{
    private DialogViewModel viewModel;
    public Dialog(TaskCompletionSource<bool> task, string message = "Default")
    {
        InitializeComponent();
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        viewModel = new DialogViewModel(task, message);
        DataContext = viewModel;
        viewModel.RequestClose += () => Close();
    }
}