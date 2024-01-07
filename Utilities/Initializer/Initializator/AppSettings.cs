using OpenApi.Accounts;
using OpenApi.Conventions;

namespace Initializator;

public class AppSettings
{
    public string Uri { get; set; }

    public ICollection<InitializationSettings> Initializers { get; set; }
}