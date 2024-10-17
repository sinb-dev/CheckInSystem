using System.Collections.ObjectModel;
using CheckInSystem.Models;

namespace CheckInSystem.ViewModels;

public class ViewmodelBase
{
    public static ObservableCollection<Employee> employees { get; set; }
    public static ObservableCollection<Group> Groups { get; set; }
}