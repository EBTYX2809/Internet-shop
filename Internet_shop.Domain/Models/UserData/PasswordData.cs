using System.Security.Cryptography;

namespace Internet_shop.Domain.Models.UserData;

public class PasswordData
{
    public string PasswordHash { get; init; }
    public string Salt { get; init; }
    public PasswordData(string password)
    {
        ValidatePassword(password);

        Salt = GenerateSalt();
        PasswordHash = HashPassword(password, Salt);        
    }
    public PasswordData(string passwordHash, string salt)
    {
        PasswordHash = passwordHash;
        Salt = salt;
    }

    public bool VerifyPassword(string password)
    {
        var hashedInput = HashPassword(password, Salt);
        return PasswordHash == hashedInput;
    }

    private void ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 20)
            throw new ArgumentException("Password length must be between 8 and 64 characters.");
    }

    private string HashPassword(string password, string salt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password.Trim(), Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256))
        {
            return Convert.ToBase64String(pbkdf2.GetBytes(32));
        }
    }

    private string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }
}
