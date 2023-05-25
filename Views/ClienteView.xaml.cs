using System.Windows;
using crud_wpf_mvvm.ViewModels;

namespace crud_wpf_mvvm.Views;

/// <summary>
/// Interaction logic for ClienteView.xaml
/// </summary>
public partial class ClienteView : Window
{
    public ClienteView()
    {
        InitializeComponent();
    }

    private void ClienteWindow_Loaded(object sender, RoutedEventArgs e)
    {
        if (NomeTextBox.IsEnabled) NomeTextBox.Focus();
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        ClienteViewModel clienteViewModel = (ClienteViewModel)DataContext;

        clienteViewModel.Create();

        if (!string.IsNullOrEmpty(clienteViewModel.HasErrorsCodeBehind))
        {
            MessageBox.Show(clienteViewModel.HasErrorsCodeBehind, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        else
        {
            this.Close();
        }
    }

    private void ViewButton_Click(object sender, RoutedEventArgs e)
    {
        NomeTextBox.IsEnabled = true;
        EmailTextBox.IsEnabled = true;
        ViewButton.Visibility = Visibility.Collapsed;
        EditButton.Visibility = Visibility;

        NomeTextBox.Focus();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        ClienteViewModel clienteViewModel = (ClienteViewModel)DataContext;

        clienteViewModel.Edit();

        if (!string.IsNullOrEmpty(clienteViewModel.HasErrorsCodeBehind))
        {
            MessageBox.Show(clienteViewModel.HasErrorsCodeBehind, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        else
        {
            this.Close();
        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (MessageBox.Show("Confirma a exclusão do cliente?", this.Title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            ClienteViewModel clienteViewModel = (ClienteViewModel)DataContext;

            clienteViewModel.Delete();

            if (!string.IsNullOrEmpty(clienteViewModel.HasErrorsCodeBehind))
            {
                MessageBox.Show(clienteViewModel.HasErrorsCodeBehind, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Close();
            }
        }
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}