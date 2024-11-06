using System.Data.SqlClient;
using System.Diagnostics;
using CheckInSystem.Models;
using CheckInSystem.ViewModels;
using CheckInSystem.Views.Windows;
using Dapper;
using FrApp42.ACR122U;


namespace CheckInSystem.CardReader;

public class ACR122U
{
    public static readonly Reader Reader = new Reader();
    
    public static void StartReader()
    {
        Reader.Connected += OnReaderConnected;
        Reader.Disconnected += OnReaderDisconnected;
        Reader.Inserted += OnCardInserted;
        Reader.Removed += OnCardRemoved;
    }
    
    private static void OnReaderConnected(string value)
    {
        Debug.WriteLine($"New reader connected : {value}");
    }

    private static void OnReaderDisconnected(string value)
    {
        Debug.WriteLine($"Reader disconnected : {value}");
    }

    private static async void OnCardInserted(string uid)
    {
        Debug.WriteLine($"New card detected : {uid}");
        CardScanned(uid);
    }

    private static void OnCardRemoved()
    {
        Debug.WriteLine("Card removed");
    } 
    
    private static void CardScanned(string cardID)
    {
        if (cardID == "") return;
        
        if (State.UpdateNextEmployee)
        {
           UpdateNextEmployee(cardID);
           return;
        }

        if (State.UpdateCardId)
        {
            UpdateCardId(cardID);
            return;
        }

        string insertQuery = "EXEC CardScanned @cardID";
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            connection.Query(insertQuery, new {cardID = cardID});
        }
        UpdateEmployeeLocal(cardID);
    }

    private static void UpdateEmployeeLocal(string cardID)
    {
        Employee? employee = ViewmodelBase.Employees.Where(e => e.CardID == cardID).FirstOrDefault();
        if (employee != null)
        {
            employee.CardScanned(cardID);
        }
        else
        {
            var dbEmployee = Employee.GetFromCardId(cardID);
            if (dbEmployee != null)
            {
                ViewmodelBase.Employees.Add(dbEmployee);
            }
        }
    }

    private static void UpdateNextEmployee(string cardID)
    {
        State.UpdateNextEmployee = false;
        Employee? editEmployee = ViewmodelBase.Employees.Where(e => e.CardID == cardID).FirstOrDefault();
        if (editEmployee == null)
        {
            CardScanned(cardID);
            editEmployee = ViewmodelBase.Employees.Where(e => e.CardID == cardID).FirstOrDefault();
        }
        EditEmployeeWindow.Open(editEmployee);
    }

    private static void UpdateCardId(string cardID)
    {
        State.UpdateCard(cardID);
    }
}