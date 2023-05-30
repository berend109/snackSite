using snackSite.Models;
using System.Data;
using Dapper;

namespace snackSite.Repositories;

public class ProductenRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
    
    public Product Get(int ProductId)
    {
        string sql = "SELECT * FROM product WHERE ProductId = @ProductId";

        using var connection = GetConnection();
        var Producten = connection.QuerySingle<Product>(sql, new { ProductId});
        return Producten;
    }
    public IEnumerable<Product> GetProduct()
    {
        string sql = @"SELECT * FROM product ORDER BY ProductId";
            
        using var connection = GetConnection();
        var getProduct = connection.Query<Product>(sql);
        return getProduct;
    }
    public Product Add (Product? product)
    {
        string sql = @"
                INSERT INTO product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, Vegan, Vega)
                VALUES (@ProductNaam, @ProductBeschrijving, @ProductPrijs, @ProductCategorie, @Vegatarisch, @Vegetarier);  
                SELECT * FROM product WHERE ProductId = LAST_INSERT_ID()";
            
        using var connection = GetConnection();
        var addedProduct = connection.QuerySingle<Product>(sql, product);
        return addedProduct;
    }

    public bool Delete(int ProductId)
    {
        string sql = @"DELETE FROM product WHERE ProductId = @ProductId";

        using var connection = GetConnection();
        int numOfEffectedRows = connection.Execute(sql, new { ProductId });
        return numOfEffectedRows == 1;
    }
    public Product Update(Product product)
    {
        string sql = @"
                UPDATE product SET 
                ProductNaam = @ProductNaam,
                ProductBeschrijving = @ProductBeschrijving,
                ProductPrijs = @ProductPrijs,
                ProductCategorie = @ProductCategorie,
                Vega = @Vegetarier,
                Vegan = @Veganistisch
                WHERE ProductId = @ProductId;
                SELECT * FROM product WHERE ProductId = @ProductId";

        using var connection = GetConnection();
        var updatedCategory = connection.QuerySingle<Product>(sql, product);
        return updatedCategory;
    }
}