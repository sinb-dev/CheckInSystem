using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;

namespace CheckInSystem.Models;

public class Group
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public ObservableCollection<Employee> Members { get; private set; }

    public static List<Group> GetAllGroups(List<Employee> employees)
    {
        string selectQueryGroups = @"SELECT * FROM [group]";
        string selectQueryEmployeesInGroup = @"SELECT employeeID FROM employeeGroup WHERE groupID = {0}";
        
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            var groups = connection.Query<Group>(selectQueryGroups).ToList();

            foreach (var group in groups)
            {
                string formattedQuery = string.Format(selectQueryEmployeesInGroup, group.ID);
                var employeeIDs = connection.Query<int>(formattedQuery).ToList();
                group.Members = new ObservableCollection<Employee>();

                foreach (var employeeID in employeeIDs)
                {
                    //group.Members.Add(employees.Where(i => i.ID == employeeID).FirstOrDefault());
                    var temp = employees.Where(i => i.ID == employeeID).FirstOrDefault();
                    if (temp != null)
                    {
                        group.Members.Add(temp);
                    }
                }
            }
            return groups;
        }
    }

    public static Group NewGroup(String name)
    {
        string insertQuery = @"INSERT INTO [group] (name) VALUES (@name)
            SELECT SCOPE_IDENTITY();";
        Group newGroup = new Group()
        {
            Name = name,
            Members = new ObservableCollection<Employee>()
        };
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            newGroup.ID = connection.QueryFirst<int>(insertQuery, new {name = name});
        }
        return newGroup;
    }

    public void RemoveGroupDb()
    {
        string deletionQuery = @"DELETE [group] WHERE ID = @ID";
        
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            connection.Query(deletionQuery, new { ID = this.ID });
        }
    }

    public void UpdateName(string name)
    {
        string updateQuery = @"UPDATE [group] 
            SET name = @name
            WHERE ID = @ID";
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            connection.Query(updateQuery, new {name = name, ID = this.ID});
        }

        this.Name = name;
    }
    
    public void AddEmployee(Employee employee)
    {
        string insertQuery = @"INSERT INTO employeeGroup (employeeID, groupID) VALUES (@employeeID, @groupID)";

        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            connection.Query(insertQuery, new { employeeID = employee.ID, @groupID = this.ID });
        }
        this.Members.Add(employee);
    }

    public void RemoveEmployee(Employee employee)
    {
        string deletionQuery = @"DELETE employeeGroup WHERE employeeID = @employeeID AND groupID = @groupID";
        using (var connection = new SqlConnection(Database.Database.ConnectionString))
        {
            connection.Query(deletionQuery, new { employeeID = employee.ID, @groupID = this.ID });
        }

        this.Members.Remove(employee);
    }
}