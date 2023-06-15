using System.Data;
using Dapper;
using snackSite.Models;

namespace snackSite.Repositories;

public abstract class UserRepository
{
    private static IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    public static Gebruiker Add(string username, string password, string email)
    {
        using var connection = GetConnection();
        int Budget = 0, BudgetLimit = 0, Adminrole = 0;

        // make test user for development
        // This can be changed or used when first using the website
        // to make a default user as the db is empty
        if (email == "test@test.nl")
        {
            BudgetLimit = 0;
            Adminrole = 1;
        }
        
        string sql = @"INSERT INTO gebruiker (Naam, Wachtwoord, Email, Adminrole, Budget, BudgetLimit) VALUES (@Naam, @Wachtwoord, @Email, @Adminrole, @Budget, @BudgetLimit);
                        SELECT * FROM gebruiker WHERE GebruikerId = LAST_INSERT_ID()";

        var parameters = new { Naam = username, Wachtwoord = password, Email = email, Adminrole, Budget, BudgetLimit };
        Gebruiker user = connection.QuerySingle<Gebruiker>(sql, parameters);
        return user;
    }

    public static Gebruiker Get(string? email)
    {
        using var connection = GetConnection();
        const string sql = @"SELECT * FROM gebruiker WHERE Email = @Email";
        var parameters = new { email };

        Gebruiker user = connection.QuerySingleOrDefault<Gebruiker>(sql, parameters);
        return user;
    }
}
