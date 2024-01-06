using Catut.Application.Abstractions;
using Catut.Application.Errors;
using Catut.Application.Services;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.TicketTemplate;
using ConventionDomain.Application.Extensions;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.TicketTemplates;

public class GetTicketTemplateRequest : IQuery<TicketTemplateDto>
{
    public required Guid TicketTemplateId { get; init; }
    public required string ConventionId { get; init; }
}

public class GetTicketTemplateRequestHandler : IRequestHandler<GetTicketTemplateRequest, TicketTemplateDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetTicketTemplateRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<TicketTemplateDto> Handle(GetTicketTemplateRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        var ticketTemplate = convention?.TicketTemplates.FirstOrDefault(x => x.Id == req.TicketTemplateId);

        if (convention is null)
            throw new UnauthorizedError();

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention,
            Policies.ReadTicketTemplates);

        if (ticketTemplate is null)
            throw new NotFoundError(
                $"Ticket template with id {req.TicketTemplateId} was not found for a convention ({req.ConventionId})");

        return ticketTemplate.ToDto();
    }
}