using System.Windows;
using CheckInSystem.ViewModels;

namespace CheckInSystem.Views;

public partial class EmployeeOverview : Window
{
    private EmployeeOverviewViewModel mw;
    public EmployeeOverview()
    {
        mw = new EmployeeOverviewViewModel();
        this.DataContext = mw;
        InitializeComponent();
    }
}