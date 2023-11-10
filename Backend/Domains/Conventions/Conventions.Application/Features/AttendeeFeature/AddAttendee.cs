using Catut.Application.Errors;
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

public class AddAttendeeRequest : ICommand<AttendeeDto>
{
    public required AttendeeCreateDto AttendeeCreateDto { get; init; }
    public required string ConventionId { get; init; }
}

public class AddAttendeeRequestHandler : IRequestHandler<AddAttendeeRequest, AttendeeDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAccountsApi _accountsApi;
    private readonly IUserAccessor _userAccessor;
    private readonly IAuthorizationService _authorizationService;

    public AddAttendeeRequestHandler(
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

    public async Task<AttendeeDto> Handle(AddAttendeeRequest req, CancellationToken ct)
    {
        // Retrieve data asynchronously and in parallel
        var (account, convention) = await GetDataAsync(req.ConventionId, req.AttendeeCreateDto.AccountId, ct);
            
        // Authorize the action based on policy
        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.AddAttendees);

        try
        {
            // Add the attendee to the convention
            var attendeeEntity = convention.AddAttendee(account.Id, account.Username, null);
            // Return dto as a successful result
            return attendeeEntity.ToDto();
        }
        catch (InvalidOperationException invalidOperationException)
        {
            throw new BadRequestError(invalidOperationException.Message);
        }
    }

    private async Task<(AccountDto Account, Convention Convention)> GetDataAsync(string conventionId, Guid accountId, CancellationToken cancellationToken)
    {
        var accountTask = _accountsApi.AccountsGETAsync(accountId, cancellationToken);
        var conventionTask = _conventionRepository.GetConvention(conventionId);

        await Task.WhenAll(accountTask, conventionTask);
            
        // Check if the account exists
        if (conventionTask.Result is null)
        {
            throw new NotFoundError($"The account ({accountId}) could not be found.");
        }
            
        // Check if the convention exists
        if (conventionTask.Result is null)
        {
            throw new NotFoundError($"The convention ({conventionId}) could not be found.");
        }

        return (accountTask.Result, conventionTask.Result);
    }
}