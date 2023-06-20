using System.ComponentModel.DataAnnotations;

namespace snackSite.Models;

public class Gebruiker
{
	[Required]
	public int GebruikerId { get; set; }
	[Required, MinLength(2), MaxLength(128)]
	public string Naam { get; set; } = null!;
	[Required, MinLength(5), MaxLength(128)]
	public string? Wachtwoord { get; set; }
	[Compare(nameof(Wachtwoord))] 
	public string? PasswordConfirm { get; set; }

	[Required (ErrorMessage = "Email is verplicht"), EmailAddress]
	public string Email { get; set; } = null!;

	[Required, Range(0, 99999.99)]
	public decimal Budget { get; set; }
	// 0 = user, 1 = admin
	[Required]
	public bool Adminrole { get; set; }
}