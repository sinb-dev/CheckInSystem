using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using CheckInSystem.Models;

namespace CheckInSystem.ViewModels;

public class LoginScreenViewModel : ViewmodelBase
{
    private string _username = "";
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged("Username");
        }
    }

    private string _password = "";
    public string Password
    {
        private get => _password;
        set
        {
            _password = value;
            OnPropertyChanged("Password");
        }
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
        }
        
        
    }
    
}