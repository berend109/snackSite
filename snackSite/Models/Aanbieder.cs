using System.ComponentModel.DataAnnotations;

namespace snackSite.Models;

public class Aanbieder
{
    [Required]
    public int AanbiederId { get; set; }
    [Required, MinLength(2), MaxLength(128)]
    public string Naam { get; set; } = null!;

}
