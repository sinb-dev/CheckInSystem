using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;

namespace CheckInSystem.Models;

using BCrypt.Net;

public class AdminUser
{
    public int ID { get; private set; }
    public string Username { get; private set; }

    public static void CreateUser(string username, string password)
    {
        string insertQuery = @"INSERT INTO adminUser (username, hashedPassword) VALUES (@username, @passwordHash)";
        
        string passwordHash = BCrypt.EnhancedHashPassword(password);
        Debug.WriteLine(passwordHash);
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            connection.Query(insertQuery, new {username = username, passwordHash = passwordHash});
        }
    }

    public static AdminUser Login(string username, string password)
    {
        string passwordHashQuery = @"SELECT hashedPassword FROM adminUser WHERE username = @username";
        string selectQuery = @"SELECT ID, username FROM adminUser WHERE username = @username";
        
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            string? hashedPassword = connection.Query<string>(passwordHashQuery, new {username = username}).FirstOrDefault();
            if (hashedPassword == null) return null;
            if (!BCrypt.EnhancedVerify(password, hashedPassword)) return null;
            
            var adminUser = connection.Query<AdminUser>(selectQuery, new {username = username}).FirstOrDefault();
            return adminUser;
        }
    }

    public static List<AdminUser> GetAdminUsers()
    {
        string selectQuery = @"SELECT * FROM adminUser";
        
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            var adminUsers = connection.Query<AdminUser>(selectQuery).ToList();
            return adminUsers;
        }
    }

    public void Delete()
    {
        string deletionQuery = @"DELETE FROM adminUser WHERE ID = @id";
        
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            connection.Query(deletionQuery, new {id = this.ID});
        }
    }
}