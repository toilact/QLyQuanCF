using BC = BCrypt.Net.BCrypt;

namespace CoffeeShopManagement.Utils;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Mật khẩu không được để trống", nameof(password));

        return BC.HashPassword(password, workFactor: 11);
    }

    public static bool VerifyPassword(string password, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(passwordHash))
            return false;

        try
        {
            return BC.Verify(password, passwordHash);
        }
        catch
        {
            return false;
        }
    }
}

