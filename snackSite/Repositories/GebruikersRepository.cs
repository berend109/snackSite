using snackSite.Models;
using System.Data;
using Dapper;

namespace snackSite.Repositories;

public class GebruikersRepository
{
    private IDbConnection GetConnection()
    {

        return new DbUtils().GetDbConnection();
    }

    public Gebruiker Get(int gebruikerId)
    {
        string sql = "SELECT * FROM gebruiker WHERE GebruikerId = @GebruikerId";

        using var connection = GetConnection();
        var Gebruikers = connection.QuerySingle<Gebruiker>(sql, new { gebruikerId });
        return Gebruikers;
    }
    public IEnumerable<Gebruiker> GetGebruiker()
    {
        string sql = @"SELECT * FROM gebruiker ORDER BY GebruikerId";

        using var connection = GetConnection();
        var getGebruiker = connection.Query<Gebruiker>(sql);
        return getGebruiker;
    }
    public Gebruiker Add(Gebruiker? gebruiker)
    {
        string sql = @"
                INSERT INTO gebruiker (Naam, Wachtwoord, Email, Budget, Admin)
                VALUES (@Naam, @Wachtwoord, @Email @Budget, @Admin);
                SELECT * FROM gebruiker WHERE GebruikerId = LAST_INSERT_ID()";

        using var connection = GetConnection();
        var addedGebruiker = connection.QuerySingle<Gebruiker>(sql, gebruiker);
        return addedGebruiker;
    }

    public bool Delete(int gebruikerId)
    {
        string sql = @"DELETE FROM gebruiker WHERE GebruikerId = @gebruikerId";

        using var connection = GetConnection();
        int numOfEffectedRows = connection.Execute(sql, new { gebruikerId });
        return numOfEffectedRows == 1;
    }
    public Gebruiker Update(Gebruiker gebruiker)
    {
        string sql = @"
                UPDATE gebruiker SET 
                Naam = @Naam,
                Wachtwoord = @Wachtwoord,
                Email = @Email
                Budget = @Budget
                Adminrole = @Adminrole
                WHERE GebruikerId = @gebruikerId;
                SELECT * FROM gebruiker WHERE gebruikerId = @gebruikerId";

        using var connection = GetConnection();
        var updatedCategory = connection.QuerySingle<Gebruiker>(sql, gebruiker);
        return updatedCategory;
    }
}