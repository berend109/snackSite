using System.ComponentModel.DataAnnotations;

namespace snackSite.Models;

public class Bestelling
{
    [Required]
    public int BestellingId { get; set; } 
    public int ProductId { get; set; }
    
    [Required, Range(0, 99.99)]
    public decimal Totaal { get; set; }
    [Range(0, 99.99)]
    public decimal Prijs { get; set; }
    
    public List<Gebruiker> Gebruikers { get; set; } = new List<Gebruiker>();
    public List<Product> Products { get; set; } = new List<Product>();
    public List<Optie> Opties { get; set; } = new List<Optie>();
    
}