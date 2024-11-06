using System.Data.SqlClient;

namespace CheckInSystem.Database;

public static class Database
{
    public static string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=CheckInSystem;Trusted_Connection=True;";
    public static SqlConnection Connection = new SqlConnection(ConnectionString);
}