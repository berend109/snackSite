using snackSite.Models;
using System.Data;
using Dapper;


namespace snackSite.Pages.Repositories;

public class ProductenRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
    
    public Producten Get(int ProductId)
    {
        string sql = "SELECT * FROM Producten WHERE ProductId = @ProductId";

        using var connection = GetConnection();
        var Producten = connection.QuerySingle<Producten>(sql, new { ProductId});
        return Producten;
    }
    public IEnumerable<Producten> GetProducten()
    {
        string sql = @"SELECT * FROM Producten ORDER BY ProductId";
            
        using var connection = GetConnection();
        var GetProducten = connection.Query<Producten>(sql);
        return GetProducten;
    }
}