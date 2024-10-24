using System.Windows;
using System.Windows.Controls;
using CheckInSystem.ViewModels;

namespace CheckInSystem.Views.UserControls;

public partial class LoginScreen : UserControl
{
    private LoginScreenViewModel mw;
    public LoginScreen()
    {
        mw = new LoginScreenViewModel();
        this.DataContext = mw;
        InitializeComponent();
    }
    
    private void Login_clicked(object sender, RoutedEventArgs e)
    {
        mw.btn_test();
    }

    private void PasswordChanged(object sender, RoutedEventArgs e)
    {
        mw.Password = ((PasswordBox)sender).Password; 
    }
}