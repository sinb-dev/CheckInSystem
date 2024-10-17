using System.Collections.ObjectModel;
using System.Diagnostics;
using CheckInSystem.CardReader;
using CheckInSystem.Models;
using CheckInSystem.ViewModels;

namespace CheckInSystem;

public class Startup
{
    public static void Run()
    {
        ACR122U.StartReader();
        ViewmodelBase.employees = new ObservableCollection<Employee>(Employee.GetAllEmployees());
        ViewmodelBase.Groups =
            new ObservableCollection<Group>(Group.GetAllGroups(new List<Employee>(ViewmodelBase.employees)));
    }
}