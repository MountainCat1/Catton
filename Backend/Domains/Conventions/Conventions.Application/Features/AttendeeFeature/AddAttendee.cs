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

namespace ConventionDomain.Application.Features.AttendeeFeature
{
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
            var currentUserAccountId = _userAccessor.User.GetUserId();

            // Retrieve data asynchronously and in parallel
            var (account, convention) = await GetDataAsync(req.ConventionId, currentUserAccountId, ct);
            
            // Authorize the action based on policy
            await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.AddAttendees);

            // Create the attendee entity
            var attendeeEntity = Attendee.CreateInstance(
                convention: convention,
                accountId: account.Id,
                accountUsername: account.Username,
                accountProfilePicture: null); // TODO: Add account image

            // Add the attendee to the convention
            convention.AddAttendee(attendeeEntity);

            // Return Unit as a successful result
            return attendeeEntity.ToDto();
        }

        private async Task<(AccountDto Account, Convention Convention)> GetDataAsync(string conventionId, Guid accountId, CancellationToken cancellationToken)
        {
            var accountTask = _accountsApi.AccountsGETAsync(accountId, cancellationToken);
            var conventionTask = _conventionRepository.GetOneWithAsync(conventionId, x => x.Attendees, x => x.Organizers);

            await Task.WhenAll(accountTask, conventionTask);
            
            // Check if the convention exists
            if (conventionTask.Result is null)
            {
                throw new NotFoundError($"The convention ({conventionId}) could not be found.");
            }

            return (accountTask.Result, conventionTask.Result);
        }
    }
}
