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

    
}