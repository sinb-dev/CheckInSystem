using System.Windows;
using CheckInSystem.Views.UserControls;

namespace CheckInSystem;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainContent.Content = new LoginScreen();
    }

}