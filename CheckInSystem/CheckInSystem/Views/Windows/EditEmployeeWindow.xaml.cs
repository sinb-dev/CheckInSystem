using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CheckInSystem.ViewModels.Windows;

namespace CheckInSystem.Views.Windows;

public partial class EditEmployeeWindow : Window
{
    public EditEmployeeViewModel vm;
    public EditEmployeeWindow(EditEmployeeViewModel viewModel)
    {
        vm = viewModel;
        this.DataContext = vm;
        Closing += vm.OnWindowClosing;
        InitializeComponent();
        vm.UpdateCardMessage = UpdateCardMessage;
    }
    
    private void UpdateCardId(object sender, RoutedEventArgs e)
    {
        vm.UpdateCardId();
    }
}