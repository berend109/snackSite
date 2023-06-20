using snackSite.Models;
using System.Data;
using Dapper;

namespace snackSite.Repositories;

public class OptieRepository
{
    private IDbConnection GetConnection()
    {
        
        return new DbUtils().GetDbConnection();
    }
    
    public Optie Get(int optieId)
    {
        string sql = "SELECT * FROM opties WHERE OptieId = @optieId";

        using var connection = GetConnection();
        var Opties = connection.QuerySingle<Optie>(sql, new { optieId});
        return Opties;
    }
    public IEnumerable<Optie> GetOptie()
    {
        string sql = @"SELECT * FROM opties ORDER BY OptieId";
            
        using var connection = GetConnection();
        var getOptie = connection.Query<Optie>(sql);
        return getOptie;
    }
    public Optie Add (Optie? opties)
    {
        string sql = @"
                INSERT INTO opties (OptieNaam, Optiebeschrijving, OptiePrijs)
                VALUES (@OptieNaam, @OptieBeschrijving, @OptiePrijs);  
                SELECT * FROM opties WHERE OptieId = LAST_INSERT_ID()";
            
        using var connection = GetConnection();
        var addedOptie = connection.QuerySingle<Optie>(sql, opties);
        return addedOptie;
    }

    public bool Delete(int optieId)
    {
        string sql = @"DELETE FROM opties WHERE OptieId = @optieId";

        using var connection = GetConnection();
        int numOfEffectedRows = connection.Execute(sql, new { optieId });
        return numOfEffectedRows == 1;
    }
    public Optie Update(Optie optie)
    {
        string sql = @"
                UPDATE opties SET 
                OptieNaam = @OptieNaam,
                OptieBeschrijving = @OptieBeschrijving,
                OptiePrijs = @OptiePrijs
                WHERE OptieId = @optieId;
                SELECT * FROM opties WHERE OptieId = @optieId";

        using var connection = GetConnection();
        var updatedOptie = connection.QuerySingle<Optie>(sql, optie);
        return updatedOptie;
    }
}