using System.Security.Cryptography;
using KeyGenerator.Models;
using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {
        var keys =  GenerateString();
        
        GenerateJwtConfigurationJson(keys.publicKey, keys.privateKey, keys.publicKeyInfo);
    }

    static (string publicKey, string privateKey, string publicKeyInfo) GenerateString()
    {
        // Create a new instance of RSACryptoServiceProvider
        using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

        // Get the public key and private key
        string publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
        string privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
        string publicKeyInfo = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());

        // Print out the keys
        Console.WriteLine("Public key:");
        Console.WriteLine(publicKey);
        Console.WriteLine();
        Console.WriteLine("Private key:");
        Console.WriteLine(privateKey);
        Console.WriteLine();
        Console.WriteLine("Public key info:");
        Console.WriteLine(publicKeyInfo);

        return (publicKey, privateKey, publicKeyInfo);
    }

    static void GenerateXml()
    {
        var rsa = new RSACryptoServiceProvider();

        // Get the public key and private key
        string publicKey = rsa.ToXmlString(false);
        string privateKey = rsa.ToXmlString(true);

        // Print out the keys
        Console.WriteLine("Public key:");
        Console.WriteLine(publicKey);
        Console.WriteLine();
        Console.WriteLine("Private key:");
        Console.WriteLine(privateKey);
    }

    static void GenerateJwtConfigurationJson(string secretKey, string publicKey, string publicKeyInfo = "")
    {
        var jwtConfig = new JwtConfig()
        {
            SecretKey = secretKey,
            PublicKey = publicKey,
            PublicKeyInfo = publicKeyInfo,
            Audience = "SomeAudience",
            Issuer = "SomeIssuer",
            Expires = 60,
        };

        // Serialize the object to JSON
        string json = JsonConvert.SerializeObject(jwtConfig, Formatting.Indented);

        // Write the JSON string to a file
        string filePath = "jwt.json";
        File.WriteAllText(filePath, json);
    }
}