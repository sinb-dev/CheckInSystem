using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CheckInSystem.Models;

using Dapper;
using Database;
using System.Data.SqlClient;

public class Employee : INotifyPropertyChanged
{
    public int ID { get; private set; }
    private string _cardID;
    public string CardID
    {
        get => _cardID;
        set => SetProperty(ref _cardID, value);
    }
    
    private string? _firstName;
    public string? FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    private string? _middleName;
    public string? MiddleName
    {
        get => _middleName;
        set => SetProperty(ref _middleName, value);
    }
    
    private string? _lastName;

    public string? LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }
    
    private bool _isOffSite;
    public bool IsOffSite
    {
        get => _isOffSite;
        set => SetProperty(ref _isOffSite, value);
    }
    
    public DateTime? OffSiteUntil { get; set; }

    private bool _isCheckedIn;
    public bool IsCheckedIn
    {
        get => _isCheckedIn;
        set => SetProperty(ref _isCheckedIn, value);
    }

    private DateTime? _arrivalTime;
    public DateTime? ArrivalTime
    {
        get => _arrivalTime;
        set => SetProperty(ref _arrivalTime, value);
    }

    private DateTime? _departureTime;

    public DateTime? DepartureTime
    {
        get => _departureTime;
        set => SetProperty(ref _departureTime, value);
    }

    

    
    public void CardScanned(string cardID)
    {
        Employee? tempEmployee = GetFromCardId(cardID);
        if (tempEmployee == null) return;
        ArrivalTime = tempEmployee.ArrivalTime;
        DepartureTime = tempEmployee.DepartureTime;
        IsCheckedIn = tempEmployee.IsCheckedIn;
    }
    
    public static List<Employee> GetAllEmployees()
    {
        string selectQuery = @"SELECT employee.ID, cardid, firstname, middlename, lastname, isoffsite, offsiteuntil, arrivaltime, departuretime,
            [dbo].[IsEmployeeCheckedIn](employee.ID) as IsCheckedIn
            FROM employee
            LEFT JOIN dbo.onSiteTime on onSiteTime.ID = (
            SELECT TOP (1) ID 
            FROM OnSiteTime
            WHERE employee.ID = OnSiteTime.employeeID
            ORDER BY arrivalTime DESC)";
        using (var connection = new SqlConnection(Database.ConnectionString))
        {
            var employees = connection.Query<Employee>(selectQuery).ToList();
            return employees;
        }
    }

    public static Employee? GetFromCardId(string cardID)
    {
        string selectQuery = @"SELECT employee.ID, cardid, firstname, middlename, lastname, isoffsite, offsiteuntil, arrivaltime, departuretime,
            [dbo].[IsEmployeeCheckedIn](employee.ID) as IsCheckedIn
            FROM employee
            LEFT JOIN dbo.onSiteTime on onSiteTime.ID = (
            SELECT TOP (1) ID 
            FROM OnSiteTime
            WHERE employee.ID = OnSiteTime.employeeID
            ORDER BY arrivalTime DESC)
            WHERE cardID = @cardID";
        using (var connection = new SqlConnection(Database.ConnectionString))
        {
            var employees = connection.Query<Employee>(selectQuery, new {cardID = cardID}).FirstOrDefault();
            return employees;
        }
    }

    public void UpdateDb()
    {
        string updateQuery = @"
            UPDATE employee
            SET cardID = @CardID,
            firstName = @FirstName,
            middleName = @MiddleName,
            lastName = @LastName,
            isOffSite = @IsOffSite,
            offSiteUntil = @OffSiteUntil
            WHERE ID = @id";
        
        using (var connection = new SqlConnection(Database.ConnectionString))
        {
            connection.Query(updateQuery, this);
        }
    }

    public void DeleteFromDb()
    {
        string deletionQuery = @"DELETE employee WHERE ID = @ID";
        
        using (var connection = new SqlConnection(Database.ConnectionString))
        {
            connection.Query(deletionQuery, this);
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    protected void SetProperty<T>(ref T variable, T value, [CallerMemberName] string? propertyName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(variable, value))
        {
            variable = value;
            OnPropertyChanged(propertyName);
        }
    }
}

