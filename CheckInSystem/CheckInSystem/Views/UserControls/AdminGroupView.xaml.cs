using System.Windows;
using System.Windows.Controls;
using CheckInSystem.ViewModels.UserControls;

namespace CheckInSystem.Views.UserControls;

public partial class AdminGroupView : UserControl
{
    private AdminGroupViewModel vm;
    public AdminGroupView()
    {
        vm = new AdminGroupViewModel();
        DataContext = vm;
        InitializeComponent();
    }

    private void BtnLogOut(object sender, RoutedEventArgs e)
    {
        vm.Logout();
    }

    private void BtnSwitchToGroups(object sender, RoutedEventArgs e)
    {
        vm.SwtichToEmployees();
    }

    private void BtnEditName(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void BtnDeleteGroup(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void BtnCreateGroup(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}