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

    public string Adminrole { get; set; } = null!;

    public bool Budget { get; set; }

    public bool Budgetlimit { get; set; }
}