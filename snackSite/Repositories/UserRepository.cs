using System.Data;
using Dapper;
using snackSite.Models;

namespace snackSite.Repositories;

public class UserRepository
{
    private static IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    // add user after register
    public static User Add(string username, string password)
    {
        using var connection = GetConnection();

        // TODO: create sql string to add user after register
        const string sql = @"SQL STRING";

        var parameters = new { Name = username, Password = password };
        var user = connection.QuerySingle<User>(sql, parameters);
        return user;
    }

    public static User Get(string email)
    {
        using var connection = GetConnection();

        // TODO: create sql string to get user by email
        const string sql = @"SQL STRING";
        var parameters = new { email };

        var user = connection.QuerySingleOrDefault<User>(sql, parameters);
        return user;
    }
}