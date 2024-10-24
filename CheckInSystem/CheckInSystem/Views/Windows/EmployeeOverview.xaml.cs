using System.Windows;
using CheckInSystem.ViewModels;
using CheckInSystem.ViewModels.Windows;

namespace CheckInSystem.Views;

public partial class EmployeeOverview : Window
{
    private EmployeeOverviewViewModel vm;
    public EmployeeOverview()
    {
        vm = new EmployeeOverviewViewModel();
        this.DataContext = vm;
        InitializeComponent();
    }
}