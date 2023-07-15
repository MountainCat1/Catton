using Catut.Application.Errors;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.TicketTemplate;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.TicketTemplates;

public class DeleteTicketTemplateRequest : IRequest<TicketTemplateDto>
{
    public required Guid TicketTemplateId { get; init; }
    public required Guid ConventionId { get; init; }
}

public class DeleteTicketRequestHandler : IRequestHandler<DeleteTicketTemplateRequest, TicketTemplateDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public DeleteTicketRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<TicketTemplateDto> Handle(DeleteTicketTemplateRequest req, CancellationToken cancellationToken)
    {
        var (convention, ticketTemplate) =
            await _conventionRepository.GetOneWithTicketTemplateAsync(req.ConventionId, req.TicketTemplateId);

        if (convention is null)
            throw new UnauthorizedError();

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention,
            Policies.ReadTicketTemplates);

        if (ticketTemplate is null)
            throw new NotFoundError(
                $"Ticket template with id {req.TicketTemplateId} was not found for a convention ({req.ConventionId})");

        convention.RemoveTicketTemplate(ticketTemplate);
        
        await _conventionRepository.SaveChangesAsync();

        return ticketTemplate.ToDto();
    }
}