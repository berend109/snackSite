using System.Security.Cryptography;
using System.Text;

namespace snackSite.Helpers;

public static class Hash
{
    /// <summary>
    /// using sha256 for hashing the password.
    /// </summary>
    /// <param name="password"></param>
    /// <returns>hashed password</returns>
    public static string HashedPassword(string? password)
    {
        if (password == null) return "";
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    }
}