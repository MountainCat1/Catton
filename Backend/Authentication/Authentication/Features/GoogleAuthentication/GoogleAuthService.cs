using Authentication.Services.Abstractions;
using Authentication.Settings;
using Google.Apis.Auth;

namespace Authentication.Features.GoogleAuthentication;

public interface IGoogleAuthProviderService : IAuthProviderService<GoogleAccount, GoogleAuthenticationData>
{
    /// <summary>
    /// Validates google JWT and its return payload
    /// </summary>
    /// <param name="jwt"></param>
    /// <returns></returns>
    Task<GoogleJsonWebSignature.Payload> ValidateGoogleJwt(string jwt);
}

public class GoogleAuthProviderService : IGoogleAuthProviderService
{
    private readonly AuthenticationSettings _authenticationSettings;
    private readonly ILogger<IGoogleAuthProviderService> _logger;

    public GoogleAuthProviderService(
        AuthenticationSettings authenticationSettings, 
        ILogger<IGoogleAuthProviderService> logger)
    {
        _authenticationSettings = authenticationSettings;
        _logger = logger;
    }

    /// <summary>
    /// Validated google JWT token and return associated account
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<GoogleAccount> AuthenticateAsync(HttpRequest request)
    {
        throw new NotImplementedException();
        // _logger.LogInformation($"Authenticating http request with google...");
        //
        // request.Headers.TryGetValue("Authorization", out var googleJwt);
        //
        // var jwtPayload = await ValidateGoogleJwt(googleJwt);
        //
        // var account = await _databaseContext.Accounts
        //     .OfType<GoogleAccount>()
        //     .FirstAsync(x => x.GoogleId == jwtPayload.Subject);
        //
        // _logger.LogInformation($"Google Authentication successful!");
        //
        // return account;
    }
    
    public async Task<GoogleAuthenticationData> RegisterAsync(GoogleAuthenticationData authenticationData)
    {
        throw new NotImplementedException();
        // _logger.LogInformation($"Registering account... {authenticationData.Jwt}");
        //
        // var googleId = (await ValidateGoogleJwt(authenticationData.Jwt)).Subject;
        //
        //
        // // If account with associated google ID exists, don't create a new one
        // if (await _databaseContext.Accounts
        //         .OfType<GoogleAccount>()
        //         .AnyAsync(x => x.GoogleId == googleId))
        // {
        //     return null;
        // }
        //
        // var newAccount = new GoogleAccount()
        // {
        //     GoogleId = googleId
        // };
        //
        // await _databaseContext.Accounts.AddAsync(newAccount);
        // await _databaseContext.SaveChangesAsync();
        //
        // _logger.LogInformation($"Account registered!");
        // return authenticationData;
    }

    /// <summary>
    /// Validates google JWT and its return payload
    /// </summary>
    /// <param name="jwt"></param>
    /// <returns></returns>
    public async Task<GoogleJsonWebSignature.Payload> ValidateGoogleJwt(string jwt)
    {
        if (jwt.Contains(' '))
            jwt = jwt.Split(' ').Last();

        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(
                jwt, 
                new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience =  new[] { _authenticationSettings.Google.ClientId }
                }
            );
            return payload;
        }
        catch (Exception e)
        {
            throw;
        }
    }
    
}