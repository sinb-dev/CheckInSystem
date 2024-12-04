﻿using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using CheckInSystem.CardReader;
using CheckInSystem.Models;
using CheckInSystem.ViewModels;
using CheckInSystem.Views;
using WpfScreenHelper;

namespace CheckInSystem;

public class Startup
{
    public static void Run()
    {
        ACR122U.StartReader();
        ViewmodelBase.Employees = new ObservableCollection<Employee>(Employee.GetAllEmployees());
        ViewmodelBase.Groups =
            new ObservableCollection<Group>(Group.GetAllGroups(new List<Employee>(ViewmodelBase.Employees)));
        OpenEmployeeOverview();
        AddAdmin();
    }

    private static void OpenEmployeeOverview()
    {
        var screens = Screen.AllScreens.GetEnumerator();
        screens.MoveNext();
        screens.MoveNext();
        Screen? screen = screens.Current;
        EmployeeOverview employeeOverview = new EmployeeOverview();

        if (screen != null)
        {
            employeeOverview.Top = screen.Bounds.Top;
            employeeOverview.Left = screen.Bounds.Left;
            employeeOverview.Height = screen.Bounds.Height;
            employeeOverview.Width = screen.Bounds.Width;
        }
        employeeOverview.Show();
    }

    private static void AddAdmin()
    {
        var admins = AdminUser.GetAdminUsers();
        if (admins.Count == 0)
        {
            AdminUser.CreateUser("sko", "test123");
        }
    }
}