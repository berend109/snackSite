using System.ComponentModel.DataAnnotations;

namespace snackSite.Models;

public class Bestelling
{
    [Required]
    public int BestellingId { get; set; } 
    public int ProductId { get; set; }
    public int OptieId { get; set; }
    [Required, Range(0, 99.99)]
    public decimal Totaal { get; set; }
    [Range(0, 99.99)]
    public decimal Prijs { get; set; }
    
    
}