using System.ComponentModel.DataAnnotations;

namespace snackSite.Models;

public class Gebruiker
{
    [Required]
    public int GebruikerId { get; set; }
    [Required, MinLength(2), MaxLength(128)]
    public string Naam { get; set; } = null!;

    public string Wachtwoord { get; set; } = null!;

    public string Email { get; set; } = null!;

    [Required, Range(0, 99.99)]
    public decimal Budget { get; set; }

    public bool Adminrole { get; set; } 

}