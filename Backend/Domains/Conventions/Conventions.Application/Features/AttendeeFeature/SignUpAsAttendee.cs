using Catut.Application.Errors;
using Catut.Domain.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Attendee;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using OpenApi.Accounts;

namespace ConventionDomain.Application.Features.AttendeeFeature;

public class SignUpAsAttendeeCommand : ICommand<AttendeeDto>
{
    public string ConventionId { get; set; }
}

public class SignUpAsAttendeeHandler : IRequestHandler<SignUpAsAttendeeCommand, AttendeeDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAccountsApi _accountsApi;
    private readonly IUserAccessor _userAccessor;
    private readonly IAuthorizationService _authorizationService;

    public SignUpAsAttendeeHandler(
        IConventionRepository conventionRepository,
        IAccountsApi accountsApi,
        IUserAccessor userAccessor,
        IAuthorizationService authorizationService)
    {
        _conventionRepository = conventionRepository;
        _accountsApi = accountsApi;
        _userAccessor = userAccessor;
        _authorizationService = authorizationService;
    }

    public async Task<AttendeeDto> Handle(SignUpAsAttendeeCommand req, CancellationToken ct)
    {
        var currentUserAccountId = _userAccessor.User.GetUserId();

        var (account, convention) = await GetDataAsync(req.ConventionId, currentUserAccountId, ct);
        
        try
        {
            await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.SignUpAsAttendee);

            var attendeeEntity = convention.AddAttendee(currentUserAccountId, account.Username, null);

            return attendeeEntity.ToDto();
        }
        catch (ConflictDomainError invalidOperationException)
        {
            throw new BadRequestError(invalidOperationException.Message);
        }
    }
    
    private async Task<(AccountDto Account, Convention Convention)> GetDataAsync(string conventionId, Guid accountId, CancellationToken cancellationToken)
    {
        var accountTask = _accountsApi.AccountsGETAsync(accountId, cancellationToken);
        var conventionTask = _conventionRepository.GetConvention(conventionId);

        await Task.WhenAll(accountTask, conventionTask);
            
        if (accountTask.Result is null)
            throw new Exception($"The account ({accountId}) could not be found.");
            
        if (conventionTask.Result is null)
            throw new NotFoundError($"The convention ({conventionId}) could not be found.");

        return (accountTask.Result, conventionTask.Result);
    }
}

