using System.ComponentModel.DataAnnotations;

namespace snackSite.Models;

public class Optie
{
    [Required]
    public int OptieId { get; set; }

    [Required, MinLength(2), MaxLength(128)]
    public string OptieNaam { get; set; } = null!;
    
    public string OptieBeschrijving { get; set; }
    
    [Required, Range(0, 99.99)]
    public decimal OptiePrijs { get; set; }
    [Required]
    public string OptieCategorie { get; set; }
}