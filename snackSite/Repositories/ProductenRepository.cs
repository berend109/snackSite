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
                INSERT INTO product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, AanbiederNaam)
                VALUES (@ProductNaam, @ProductBeschrijving, @ProductPrijs, @ProductCategorie, @AanbiederNaam);  
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
                ProductCategorie = @ProductCategorie,
                AanbiederNaam = @AanbiederNaam
                WHERE ProductId = @productId;
                SELECT * FROM product WHERE ProductId = @productId";

        using var connection = GetConnection();
        var updatedCategory = connection.QuerySingle<Product>(sql, product );
        return updatedCategory;
    }
    /*public bool AddHeeftEenProduct(int aanbiederId, int productId)
    {
        string sql = @"
                INSERT INTO heefteenproduct (aanbiederId, productId)
                VALUES (@aid, @pid)
                ";

        using var connection = GetConnection();
        var maker = connection.Execute(sql, new { aid = aanbiederId, pid = productId});
        return true;
    }*/

    /*public IEnumerable<Product> Get()
    {
        string sql = @"SELECT * FROM product P
                        LEFT JOIN heefteenproduct hep ON hep.productId = P.productId
                        LEFT JOIN aanbieder a ON a.aanbiederId = hep.aanbiederID";
            
       
        using var connection = GetConnection();
        var Producten = connection.Query<Product, Aanbieder, Product>(sql, ((product, aanbieder) => product, Aanbieder)); 
        return Producten;
    }*/

    
}
