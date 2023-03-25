using System.Security.Cryptography;
using System.Text;

namespace User.Application.Services;

public interface IPasswordService
{
    string CreateHash(string s);
    CheckHashResult CheckHash(string hash, string password);
}

public class PasswordService : IPasswordService
{
    public string CreateHash(string s)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(s);

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedPasswordBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashedPasswordBytes);
        } 
    }

    public CheckHashResult CheckHash(string hash, string password)
    {
        var result = new CheckHashResult()
        {
            Success = false
        };
        
        byte[] hashBytes = Convert.FromBase64String(hash);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedPasswordBytes = sha256.ComputeHash(passwordBytes);

            if (hashBytes.Length != hashedPasswordBytes.Length)
            {
                return result;
            }

            for (int i = 0; i < hashBytes.Length; i++)
            {
                if (hashBytes[i] != hashedPasswordBytes[i])
                {
                    return result;
                }
            }

            result.Success = true;
            
            return result;
        }
    }
}

public class CheckHashResult
{
    public bool Success { get; set; }
}