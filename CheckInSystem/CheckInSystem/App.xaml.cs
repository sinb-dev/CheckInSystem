using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace CheckInSystem;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    void App_Startup(object sender, StartupEventArgs e)
    {
        CheckInSystem.Startup.Run();
    }
}