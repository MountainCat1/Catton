using ConventionDomain.Application.Authorization.Requirements;
using Conventions.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ConventionDomain.Application.Authorization.Handlers;

public class ConventionAuthorizationHandler : OperationAuthorizationHandler<Convention>
{
    private ILogger<ConventionAuthorizationHandler> _logger;
    private IAuthorizationService _authorizationService;

    public ConventionAuthorizationHandler(
        ILogger<ConventionAuthorizationHandler> logger,
        IAuthorizationService authorizationService)
    {
        _logger = logger;
        _authorizationService = authorizationService;
    }

    protected override async Task<AuthorizationResult> HandleCreateRequirement()
    {
        var requirement = new IsOrganizerOfRequirement();

        return await _authorizationService.AuthorizeAsync(User, Resource, requirement);
    }


    protected override async Task<AuthorizationResult> HandleReadRequirement()
    {
        var requirement = new IsOrganizerOfRequirement();

        return await _authorizationService.AuthorizeAsync(User, Resource, requirement);
    }

    protected override async Task<AuthorizationResult> HandleUpdateRequirement()
    {
        var requirement = new IsOrganizerOfRequirement();

        return await _authorizationService.AuthorizeAsync(User, Resource, requirement);
    }

    protected override async Task<AuthorizationResult> HandleDeleteRequirement()
    {
        var requirement = new IsOrganizerOfRequirement();

        return await _authorizationService.AuthorizeAsync(User, Resource, requirement);
    }
}