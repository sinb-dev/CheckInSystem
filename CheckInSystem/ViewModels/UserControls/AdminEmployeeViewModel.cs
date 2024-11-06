using System.Collections.ObjectModel;
using CheckInSystem.Models;
using CheckInSystem.Views.Windows;

namespace CheckInSystem.ViewModels.UserControls;

public class AdminEmployeeViewModel : ViewmodelBase
{
    public ObservableCollection<Employee> SelectedEmployeeGroup { get; set; }
    public ObservableCollection<Employee> SelectedEmployees { get; set; }
    
    public AdminEmployeeViewModel(ObservableCollection<Employee> employees)
    {
        SelectedEmployeeGroup = employees;
        SelectedEmployees = new();
    }

    public void EditEmployee(Employee employee)
    {
        EditEmployeeWindow.Open(employee);
    }
}