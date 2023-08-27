using Catut.Application.Errors;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Ticket;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using OpenApi.Accounts;

namespace ConventionDomain.Application.Features.TicketFeature;

public class CreateOwnTicketRequest : IRequest<TicketDto>
{
    public required TicketCreateDto Dto { get; init; }
    public required string ConventionId { get; set; }
}

public class CreateOwnTicketRequestHandler : IRequestHandler<CreateOwnTicketRequest, TicketDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAccountsApi _accountsApi;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public CreateOwnTicketRequestHandler(IConventionRepository conventionRepository, IAccountsApi accountsApi, IAuthorizationService authorizationService, IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _accountsApi = accountsApi;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<TicketDto> Handle(CreateOwnTicketRequest req, CancellationToken ct)
    {
        var dto = req.Dto;
        
        var convention = await _conventionRepository.GetOneWithAsync(req.ConventionId, c => c.Tickets);

        if (convention is null)
            throw new NotFoundError($"The convention ({req.ConventionId}) could not be found.");

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.CreateOwnTicket);

        if (convention.Organizers.Any(x => x.AccountId == dto.AtendeeId))
            throw new BadRequestError(
                $"Account ({dto.AtendeeId}) is already an organizer of the convention ({req.ConventionId})");

        var entity = Ticket.Create(
            conventionId: req.Dto.ConventionId,
            atendeeId: req.Dto.AtendeeId,
            ticketTemplateId: req.Dto.TicketTemplateId
        );
        
        convention.AddTicket(entity);

        return entity.ToDto();
    }
}