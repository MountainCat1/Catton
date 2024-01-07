


using System.Threading.Channels;
using Initializator;
using Initializator.Extensions;
using Microsoft.Extensions.Configuration;
using OpenApi.Accounts;
using OpenApi.Conventions;

// Create a new configuration builder
IConfigurationBuilder builder = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path to your application's root directory
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // Add JSON configuration
    .AddEnvironmentVariables() // Add environment variables
    .AddCommandLine(args); // Add command-line arguments
    
var configuration = builder.Build();

var appSettings = configuration.GetConfiguration<AppSettings>("InitializationSettings");

foreach (var initializer in appSettings.Initializers)
{
    var initializor = new Initializer(appSettings.Uri, initializer);

    await initializor.Initialize();

}


Console.WriteLine("Initialization completed successfully");





