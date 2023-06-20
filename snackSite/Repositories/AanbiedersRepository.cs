using snackSite.Models;
using System.Data;
using Dapper;


namespace snackSite.Repositories
{
    public class AanbiedersRepository
    {

        private IDbConnection GetConnection()
        {

            return new DbUtils().GetDbConnection();
        }

        public Aanbieder Get(int aanbiederId)
        {
            string sql = "SELECT * FROM aanbieder WHERE AanbiederId = @AanbiederId";

            using var connection = GetConnection();
            var Aanbieders = connection.QuerySingle<Aanbieder>(sql, new { aanbiederId });
            return Aanbieders;
        }

        public IEnumerable<Aanbieder> GetAanbieder()
        {
            string sql = @"SELECT * FROM aanbieder ORDER BY AanbiederId";

            using var connection = GetConnection();
            var getAanbieder = connection.Query<Aanbieder>(sql);
            return getAanbieder;
        }

        public Aanbieder Add(Aanbieder? aanbieder)
        {
            string sql = @"
                INSERT INTO aanbieder (Naam)
                VALUES (@Naam);  
                SELECT * FROM aanbieder WHERE AanbiederId = LAST_INSERT_ID()";

            using var connection = GetConnection();
            var addedAanbieder = connection.QuerySingle<Aanbieder>(sql, aanbieder);
            return addedAanbieder;
        }

        public bool Delete(int aanbiederId)
        {
            string sql = @"DELETE FROM aanbieder WHERE AanbiederId = @aanbiederId";

            using var connection = GetConnection();
            int numOfEffectedRows = connection.Execute(sql, new { aanbiederId });
            return numOfEffectedRows == 1;
        }

        public Aanbieder Update(Aanbieder aanbieder)
        {
            string sql = @"
                UPDATE aanbieder SET 
                Naam = @Naam
                WHERE AanbiederId = @aanbiederId;
                SELECT * FROM aanbieder WHERE aanbiederId = @aanbiederId";

            using var connection = GetConnection();
            var updatedCategory = connection.QuerySingle<Aanbieder>(sql, aanbieder);
            return updatedCategory;
        }

        public IEnumerable<Aanbieder> GetHeeftEenProduct(int id)
        {
            string sql = @"SELECT a.aanbiederid, a.naam FROM aanbieder a
                        LEFT JOIN heefteenproduct HEP ON HEP.aanbiederId = a.aanbiederId
                        LEFT JOIN product p ON p.productId = HEP.productId
                        WHERE p.productId = @pid";
            using var connection = GetConnection();

            var aanbieders = connection.Query<Aanbieder>(sql, new { pid = id, });

            return aanbieders;

        }
    }
}
