using System.Security.Claims;
using ConventionDomain.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace ConventionDomain.Application.Authorization.Handlers;

public class ConventionAuthorizationHandler : OperationAuthorizationHandler<Convention>
{
    private ILogger<ConventionAuthorizationHandler> _logger;

    public ConventionAuthorizationHandler(ILogger<ConventionAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<AuthorizationResult> HandleCreateRequirement()
    {
        // TODO: only admins or something can do it!
        
        _logger.LogWarning("Creation of convetions doesnt have a authorization!");
        
        
        return Succeed();
    }
    

    protected override async Task<AuthorizationResult> HandleReadRequirement()
    {
        var accountIdString = User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value;
        var accountId = new Guid(accountIdString);

        
        
        if (!Resource.Organizers.Any(x => x.AccountId == accountId))
        {
            return Fail();
        }
        
        return Succeed();
    }

    protected override Task<AuthorizationResult> HandleUpdateRequirement()
    {
        throw new NotImplementedException();
    }

    protected override Task<AuthorizationResult> HandleDeleteRequirement()
    {
        throw new NotImplementedException();
    }
}