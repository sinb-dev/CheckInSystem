using System.Windows;
using System.Windows.Controls;
using CheckInSystem.ViewModels;
using CheckInSystem.ViewModels.UserControls;

namespace CheckInSystem.Views.UserControls;

public partial class LoginScreen : UserControl
{
    private LoginScreenViewModel vm;
    public LoginScreen()
    {
        vm = new LoginScreenViewModel();
        this.DataContext = vm;
        InitializeComponent();
    }
    
    private void Login_clicked(object sender, RoutedEventArgs e)
    {
        vm.btn_test();
    }

    private void PasswordChanged(object sender, RoutedEventArgs e)
    {
        vm.Password = ((PasswordBox)sender).Password; 
    }
}