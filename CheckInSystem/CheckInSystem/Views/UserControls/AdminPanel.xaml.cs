using System.Windows;
using System.Windows.Controls;
using CheckInSystem.ViewModels.UserControls;

namespace CheckInSystem.Views.UserControls;

public partial class AdminPanel : UserControl
{
    private AdminPanelViewModel vm;
    public AdminPanel()
    {
        InitializeComponent();
        vm = new AdminPanelViewModel(EmployeesControl);
        DataContext = vm;
    }

    private void BtnResetGroup(object sender, RoutedEventArgs e)
    {
        SelectedGroup.SelectedIndex = -1;
    }

    private void BtnLogOut(object sender, RoutedEventArgs e)
    {
        vm.Logout();
    }

    private void BtnEditGroupsForEmployees(object sender, RoutedEventArgs e)
    {
        //TODO: Add logic to edit groups for selected employees
    }

    private void BtnEditOffsiteForEmployees(object sender, RoutedEventArgs e)
    {
        //TODO: Add logic to mark selected Emoplyees as offsite
    }

    private void BtnDeleteEmployees(object sender, RoutedEventArgs e)
    {
        //TODO: Add logic til delete selected employees
    }

    private void BtnSwitchToGroups(object sender, RoutedEventArgs e)
    {
        vm.SwitchToGroups();
    }

    private void BtnEditScannedCard(object sender, RoutedEventArgs e)
    {
        vm.EditNextScannedCard();
    }
}