using Catut.Application.Errors;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.TicketTemplate;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.TicketTemplates;

public class GetTicketTemplatesRequest : IRequest<ICollection<TicketTemplateDto>>
{
    public required Guid ConventionId { get; init; }
}

public class GetTicketTemplatesRequestHandler : IRequestHandler<GetTicketTemplatesRequest, ICollection<TicketTemplateDto>>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetTicketTemplatesRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<ICollection<TicketTemplateDto>> Handle(GetTicketTemplatesRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetOneWithAsync(req.ConventionId,
            c => c.TicketTemplates,
            c => c.Organizers);

        if (convention is null)
            throw new UnauthorizedError();

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention,
            Policies.ReadTicketTemplates);

        return convention.TicketTemplates.Select(x => x.ToDto()).ToList();
    }
}