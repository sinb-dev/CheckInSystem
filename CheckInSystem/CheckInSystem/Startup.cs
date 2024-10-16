using CheckInSystem.CardReader;

namespace CheckInSystem;

public class Startup
{
    public static void Run()
    {
        ACR122U.StartReader();
    }
}