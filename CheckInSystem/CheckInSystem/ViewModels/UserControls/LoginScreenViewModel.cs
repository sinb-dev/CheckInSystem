using System.Windows;
using CheckInSystem.Models;
using CheckInSystem.Views.UserControls;

namespace CheckInSystem.ViewModels.UserControls;

public class LoginScreenViewModel : ViewmodelBase
{
    private string _username = "";

    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    private string _password = "";

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public LoginScreenViewModel()
    {
        
    }

    public void btn_test()
    {
        AdminUser? adminUser = AdminUser.Login(Username, Password);
        if (adminUser == null)
        {
            MessageBox.Show("Forkert brugernavn eller kodeord, prøv igen.", "Login fejl", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        else
        {
            //Move to Adminpanel
            MainContentControl.Content = new AdminPanel();
        }
    }
    
}