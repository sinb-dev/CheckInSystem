namespace CheckInSystem.Models;

using Dapper;
using Database;
using System.Data.SqlClient;

public class Employee
{
    public int ID { get; private set; }
    public string CardID { get; private set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public bool IsOffSite { get; set; }
    public DateTime OffSiteUntil { get; set; }
    public bool IsCheckedIn { get; set; }

    public static List<Employee> GetAllEmployees()
    {
        //string selectQuery = "SELECT * FROM employee";
        string selectQuery = @"SELECT 
            id, 
            cardid, 
            firstname, 
            middlename, 
            lastname, 
            isoffsite, 
            offsiteuntil, 
            [dbo].[IsEmployeeCheckedIn](ID) as IsCheckedIn
            FROM employee";
        using (var connection = new SqlConnection(Database.ConnectionString))
        {
            var employees = connection.Query<Employee>(selectQuery).ToList();
            return employees;
        }
    }
}

