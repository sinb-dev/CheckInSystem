using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using CheckInSystem.Models;
using CheckInSystem.ViewModels.UserControls;

namespace CheckInSystem.Views.UserControls;

public partial class AdminEmployeeView : UserControl
{
    private AdminEmployeeViewModel vm;
    
    public AdminEmployeeView(ObservableCollection<Employee> employees)
    {
        vm = new AdminEmployeeViewModel(employees);
        DataContext = vm;
        InitializeComponent();
    }

    private void BtnOpenEmployeeEdit(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        Employee employee = (Employee)button.DataContext;
        vm.EditEmployee(employee);
    }

    private void BtnSeeEmployeeTime(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        Employee employee = (Employee)button.DataContext;
        //TODO: Open EmployeeTime
    }

    private void BtnEditEmployeeGroup(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        Employee employee = (Employee)button.DataContext;
        //TODO: Open EmployeeGroup
    }

    private void CbSelected(object sender, RoutedEventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        Employee employee = (Employee)checkBox.DataContext;
        AdminEmployeeViewModel.SelectedEmployees.Add(employee);
        Debug.WriteLine($"{employee.FirstName} Checked");
    }

    private void CbUnSelected(object sender, RoutedEventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        Employee employee = (Employee)checkBox.DataContext;
        AdminEmployeeViewModel.SelectedEmployees.Remove(employee);
        Debug.WriteLine($"{employee.FirstName} Unchecked");
    }
}