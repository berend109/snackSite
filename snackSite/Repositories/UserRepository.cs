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

    public static Gebruiker Add(string username, string password, string email)
    {
        using var connection = GetConnection();
        int budget = 0, budgetLimit = 0, adminrole = 0;

        // make test user for development
        // This can be changed or used when first using the website
        // to make a default user as the db is empty
        if (email == "test@test.nl")
        {
            budgetLimit = 0;
            adminrole = 1;
        }
        
        const string sql = @"INSERT INTO gebruiker (Naam, Wachtwoord, Email, Adminrole, Budget, BudgetLimit) VALUES (@Naam, @Wachtwoord, @Email, @Adminrole, @Budget, @BudgetLimit);
                        SELECT * FROM gebruiker WHERE GebruikerId = LAST_INSERT_ID()";

        var parameters = new { Naam = username, Wachtwoord = password, Email = 
			email,
            Adminrole = adminrole,
            Budget = budget,
            BudgetLimit = budgetLimit };
        var user = connection.QuerySingle<Gebruiker>(sql, parameters);
        return user;
    }

    public static Gebruiker Get(string? email)
    {
        using var connection = GetConnection();
        const string sql = @"SELECT * FROM gebruiker WHERE Email = @Email";
        var parameters = new { email };

        var user = connection.QuerySingleOrDefault<Gebruiker>(
			sql, parameters);
        return user;
    }
}
