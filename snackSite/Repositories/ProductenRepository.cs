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
    
    public Product Get(int productId)
    {
        string sql = "SELECT * FROM product WHERE ProductId = @productId";

        using var connection = GetConnection();
        var Producten = connection.QuerySingle<Product>(sql, new { productId});
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
                INSERT INTO product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie)
                VALUES (@ProductNaam, @ProductBeschrijving, @ProductPrijs, @ProductCategorie);  
                SELECT * FROM product WHERE ProductId = LAST_INSERT_ID()";
            
        using var connection = GetConnection();
        var addedProduct = connection.QuerySingle<Product>(sql, product);
        return addedProduct;
    }

    public bool Delete(int productId)
    {
        string sql = @"DELETE FROM product WHERE ProductId = @productId";

        using var connection = GetConnection();
        int numOfEffectedRows = connection.Execute(sql, new { productId });
        return numOfEffectedRows == 1;
    }
    public Product Update(Product product)
    {
        string sql = @"
                UPDATE product SET 
                ProductNaam = @ProductNaam,
                ProductBeschrijving = @ProductBeschrijving,
                ProductPrijs = @ProductPrijs,
                ProductCategorie = @ProductCategorie
                WHERE ProductId = @productId;
                SELECT * FROM product WHERE ProductId = @productId";

        using var connection = GetConnection();
        var updatedCategory = connection.QuerySingle<Product>(sql, product);
        return updatedCategory;
    }
}