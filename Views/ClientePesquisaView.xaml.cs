using System.ComponentModel;
using System.Windows;
using crud_wpf_mvvm.ViewModels;

namespace crud_wpf_mvvm.Views;

/// <summary>
/// Interaction logic for ClientePesquisaView.xaml
/// </summary>
public partial class ClientePesquisaView : Window
{
    ClienteViewModel _clienteViewModel = new();

    public ClientePesquisaView()
    {
        InitializeComponent();

        DataContext = _clienteViewModel;
    }

    private void ClientePesquisaWindow_Loaded(object sender, RoutedEventArgs e)
    {
        _clienteViewModel.GetAll();
    }

    private void ClientePesquisaWindow_Closing(object sender, CancelEventArgs e)
    {
        _clienteViewModel.Dispose();
    }

    private void NewButton_Click(object sender, RoutedEventArgs e)
    {
        var windowUri = new ClienteView();

        _clienteViewModel.New();
        _clienteViewModel.Cliente.ValidateAll();
 
        windowUri.DataContext = _clienteViewModel;
        windowUri.Owner = this;
        windowUri.CreateButton.Visibility = Visibility;

        windowUri.ShowDialog();

        _clienteViewModel.GetAll();
    }

    private void ViewButton_Click(object sender, RoutedEventArgs e)
    {
        var windowUri = new ClienteView();

        _clienteViewModel.EditModeOn();

        windowUri.DataContext = _clienteViewModel;
        windowUri.Owner = this;
        windowUri.NomeTextBox.IsEnabled = false;
        windowUri.EmailTextBox.IsEnabled = false;        
        windowUri.ViewButton.Visibility = Visibility;

        windowUri.ShowDialog();

        _clienteViewModel.EditModeOff();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        var windowUri = new ClienteView();

        _clienteViewModel.EditModeOn();

        windowUri.DataContext = _clienteViewModel;
        windowUri.Owner = this;
        windowUri.EditButton.Visibility = Visibility;

        windowUri.ShowDialog();

        _clienteViewModel.EditModeOff();
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        var windowUri = new ClienteView();

        windowUri.DataContext = _clienteViewModel;
        windowUri.Owner = this;
        windowUri.NomeTextBox.IsEnabled = false;
        windowUri.EmailTextBox.IsEnabled = false;        
        windowUri.DeleteButton.Visibility = Visibility;

        windowUri.ShowDialog();

        _clienteViewModel.GetAll();
    }
}