using Catton.ApiClient.Extensions;
using OpenApi.Accounts;
using OpenApi.Conventions;

namespace Initializator;

public class Initializer
{
    private readonly InitializationSettings _settings;
    private string _apiUri;

    private List<AccountDto> _accountDtos;

    public Initializer(string apiUri, InitializationSettings appSettingsInitializationSettings)
    {
        _apiUri = apiUri;
        _settings = appSettingsInitializationSettings;
    }

    public async Task Initialize()
    {
        _accountDtos = new List<AccountDto>();
        
        Console.WriteLine("Starting initialization...");
        
        var accountsHttpClient = CreateHttpClient(_apiUri);

        var accountsApi = new AccountsApi(accountsHttpClient);


        // Create admin account
        Console.WriteLine("Creating admin account");
        await accountsApi.AccountsPOSTAsync(_settings.Admin);

        // Create attendee's accounts
        Console.WriteLine("Creating attendee's accounts");
        foreach (var attendee in _settings.Accounts)
        {
            await accountsApi.AccountsPOSTAsync(attendee);

            var loginResponse = accountsApi.LoginAsync(new AuthViaPasswordRequestContract()
            {
                Email = attendee.Email,
                Password = attendee.Password
            }).Result;
            
            accountsApi.AddBearer(loginResponse.AuthToken);

            var accountInfo = await accountsApi.MeAsync();
            _accountDtos.Add(accountInfo);
        }
        
        // Save admin's auth token
        Console.WriteLine("Logging in as admin");
        var adminToken = accountsApi.LoginAsync(new AuthViaPasswordRequestContract()
        {
            Email = _settings.Admin.Email,
            Password = _settings.Admin.Password
        }).Result.AuthToken;
        accountsHttpClient.AddJwt(adminToken);
        
        // Create convention
        var conventionHttpClient = CreateHttpClient(_apiUri);
        conventionHttpClient.AddJwt(adminToken);
        var conventionsApi = new ConventionsApi(conventionHttpClient);
        conventionsApi.AddBearer(adminToken);
        // Create convention
        Console.WriteLine("Creating convention");
        await conventionsApi.ConventionsPOSTAsync(_settings.Convention);
        
        // Add attendees
        Console.WriteLine("Adding attendees");
        foreach (var accountDto in _accountDtos)
        {
            await conventionsApi.AttendeesPOSTAsync(_settings.Convention.Id, new AttendeeCreateDto()
            {
                AccountId = accountDto.Id,
            });
        }
        
        // Add attendees
        Console.WriteLine("Adding ticket templates");
        foreach (var ticketTemplate in _settings.TicketTemplates)
        {
            await conventionsApi.TicketTemplatesPOSTAsync(_settings.Convention.Id, ticketTemplate);
        }
    }

    HttpClient CreateHttpClient(string apiUri)
    {
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;

        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(apiUri),
        };

        return httpClient;
    }
}