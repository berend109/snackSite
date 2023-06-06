using System.Data;
using Dapper;
using snackSite.Models;

namespace snackSite.Repositories;

public class BestellingRepository
{
    private IDbConnection GetConnection()
    {
        
        return new DbUtils().GetDbConnection();
    }
    
    public Bestelling Get(int bestellingId)
    {
        string sql = "SELECT * FROM bestelling WHERE BestellingId = @bestellingId";

        using var connection = GetConnection();
        var Bestelling = connection.QuerySingle<Bestelling>(sql, new { bestellingId});
        return Bestelling;
    }
    public IEnumerable<Bestelling> GetBestelling()
    {
        string sql = @"SELECT * FROM bestelling ORDER BY BestellingId";
            
        using var connection = GetConnection();
        var getBestelling = connection.Query<Bestelling>(sql);
        return getBestelling;
    }
    public Bestelling Add (Bestelling? bestelling)
    {
        string sql = @"
                INSERT INTO bestelling (productId, optieId, totaal)
                VALUES (@productId, @optieId, @totaal);  
                SELECT * FROM bestelling WHERE bestellingId = LAST_INSERT_ID()";
            
        using var connection = GetConnection();
        var addedBestelling = connection.QuerySingle<Bestelling>(sql, bestelling);
        return addedBestelling;
    }
}