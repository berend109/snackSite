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

    public User Add(string username, string password, string email)
    {
        using var connection = GetConnection();
        int Budget = 0, BudgetLimit = 0, Adminrole = 0;
        string sql = @"INSERT INTO gebruiker (Naam, Wachtwoord, Email, Adminrole, Budget, BudgetLimit) VALUES (@Naam, @Wachtwoord, @Email, @Adminrole, @Budget, @BudgetLimit);
                        SELECT * FROM gebruiker WHERE GebruikerId = LAST_INSERT_ID()";

        var parameters = new { Name = username, Password = password, Email = email, Adminrole = Adminrole, Budget, BudgetLimit };
        var user = connection.QuerySingle<User>(sql, parameters);
        return user;
    }

    public static User Get(string? email)
    {
        using var connection = GetConnection();
        const string sql = @"SELECT * FROM gebruiker WHERE Email = @Email";
        var parameters = new { email };

        var user = connection.QuerySingleOrDefault<User>(sql, parameters);
        return user;
    }
}