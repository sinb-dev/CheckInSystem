using System.Windows.Controls;
using CheckInSystem.Models;
using CheckInSystem.Views.UserControls;

namespace CheckInSystem.ViewModels.UserControls;

public class AdminPanelViewModel : ViewmodelBase
{
    private ContentControl EmployeesControl { get; set; }

    public Group? UpdateEmployeesControl
    {
        set
        {
            if (value == null)
            {
                EmployeesControl.Content = new AdminEmployeeView(employees);
            }
            else
            {
                EmployeesControl.Content = new AdminEmployeeView(value.Members);
            }
        }
    }
    
    public AdminPanelViewModel(ContentControl contentControl)
    {
        EmployeesControl = contentControl;
        EmployeesControl.Content = new AdminEmployeeView(employees);
    }

    public void Logout()
    {
        MainContentControl.Content = new LoginScreen();
    }
}