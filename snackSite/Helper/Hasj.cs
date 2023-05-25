using System.Security.Cryptography;
using System.Text;

namespace WebdevProjectStarterTemplate.Helper;

public static class Hash
{
	/// <summary>
	/// using sha256 for hashing the password.
	/// </summary>
	/// <param name="password"></param>
	/// <returns>hashed password</returns>
	public static string HashPassword(string password)
	{
		using var sha256 = SHA256.Create();
		var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
		return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
	} 
}