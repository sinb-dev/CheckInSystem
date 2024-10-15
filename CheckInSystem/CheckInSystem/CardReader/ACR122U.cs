using System.Diagnostics;
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
    }

    private static void OnCardRemoved()
    {
        Debug.WriteLine("Card removed");
    } 
}