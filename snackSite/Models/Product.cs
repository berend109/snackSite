using System.ComponentModel.DataAnnotations;

namespace snackSite.Models;

public class Product
{
    [Required]
    public int ProductId { get; set; }
    [Required, MinLength(2), MaxLength(128)]
    public string ProductNaam { get; set; } = null!;

    public string Productbeschrijving { get; set; }
    
    [Required, Range(0, 99.99)]
    public decimal ProductPrijs { get; set; }
    [Required]
    public string ProductCategorie { get; set; }
    
    [Required, MinLength(2), MaxLength(128)]
    public string AanbiederNaam { get; set; } = null!;

    
    public List<Optie> Opties { get; set; } = new List<Optie>();

}