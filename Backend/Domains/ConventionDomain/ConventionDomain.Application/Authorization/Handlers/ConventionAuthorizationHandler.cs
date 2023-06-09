using System.Security.Claims;
using ConventionDomain.Application.Authorization.Requirements;
using ConventionDomain.Domain.Entities;
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
        // TODO: only admins or something can do it!

        _logger.LogWarning("Creation of convetions doesnt have a authorization!");


        return Succeed();
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