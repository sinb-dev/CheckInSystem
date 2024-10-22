using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CheckInSystem.ViewModels;

namespace CheckInSystem;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class LoginScreen : Window
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