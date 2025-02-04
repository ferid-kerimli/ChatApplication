using System.Security.Cryptography;

namespace ChatApplication.BLL.Utility;

public static class PasswordHasher
{
    public static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    public static string HashPassword(string password, string salt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 100_000, HashAlgorithmName.SHA256))
        {
            return Convert.ToBase64String(pbkdf2.GetBytes(32)); 
        }
    }
    
    public static bool VerifyPassword(string password, string salt, string storedHashedPassword)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 100_000, HashAlgorithmName.SHA256))
        {
            string computedHash = Convert.ToBase64String(pbkdf2.GetBytes(32));
            return computedHash == storedHashedPassword;
        }
    }
}