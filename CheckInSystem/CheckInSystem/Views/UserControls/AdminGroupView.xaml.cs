using System.Windows.Controls;
using CheckInSystem.ViewModels.UserControls;

namespace CheckInSystem.Views.UserControls;

public partial class AdminGroupView : UserControl
{
    private AdminGroupViewModel vm;
    public AdminGroupView()
    {
        vm = new AdminGroupViewModel();
        InitializeComponent();
    }
}