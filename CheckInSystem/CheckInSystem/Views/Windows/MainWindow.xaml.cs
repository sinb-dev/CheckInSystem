using System.Windows;
using CheckInSystem.ViewModels;
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
        ViewmodelBase.MainContentControl = MainContent;
        MainContent.Content = new LoginScreen();
    }

}