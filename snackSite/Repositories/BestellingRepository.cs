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
                INSERT INTO bestelling (totaalprijs)
                VALUES (@totaalprijs);  
                SELECT * FROM bestelling WHERE bestellingId = LAST_INSERT_ID()";
            
        using var connection = GetConnection();
        var addedBestelling = connection.QuerySingle<Bestelling>(sql, bestelling);
        return addedBestelling;
    }

    public bool AddBesteld (int bestellingId, int productId, int optieId)
    {
        string sql = @"
                INSERT INTO heeftbesteld (bestellingId, productId, optieId)
                VALUES (@bid, @pid, @oid)";  
                            
        using var connection = GetConnection();
        var Besteld = connection.Execute(sql, new { bid = bestellingId, pid = productId, oid = optieId});
        return true;
    }

    public IEnumerable<Bestelling> GetBesteld()
    {
        string sql = @"select * FROM bestelling b
                       Left Join heeftbesteld hb on hb.BestellingId = b.BestellingId
                       Where b.BestellingId = hb.BestellingId
                       order by hb.gebruikerId             
                       ";
        
        using var connection = GetConnection();
        var Besteld = connection.Query<Bestelling, Product, Optie, Gebruiker, Bestelling>(sql,
            (bestelling, product, optie, Gebruiker) =>
            {
                bestelling.Products.Add(product);
                bestelling.Opties.Add(optie);
                bestelling.Gebruikers.Add(Gebruiker);
                
                return bestelling;
                
            }, splitOn: "bestellingid");
        
        return Besteld;

    }

}