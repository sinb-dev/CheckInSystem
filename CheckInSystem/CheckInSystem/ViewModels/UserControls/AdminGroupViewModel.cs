using CheckInSystem.Views.UserControls;

namespace CheckInSystem.ViewModels.UserControls;

public class AdminGroupViewModel : ViewmodelBase
{
    public AdminGroupViewModel()
    {
        
    }
    
    public void Logout()
    {
        MainContentControl.Content = new LoginScreen();
    }

    public void SwtichToEmployees()
    {
        MainContentControl.Content = new AdminPanel();
    }
}