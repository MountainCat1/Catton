using Catut.Application.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.TicketTemplate;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.TicketTemplates;

public class UpdateTicketTemplateRequest : ICommand<TicketTemplateDto>
{
    public required TicketTemplateUpdateDto TicketUpdateDto { get; init; }
    public required string ConventionId { get; init; }
    public required Guid TicketTemplateId { get; init; }
}

public class UpdateTicketTemplateRequestHandler : IRequestHandler<UpdateTicketTemplateRequest, TicketTemplateDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public UpdateTicketTemplateRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<TicketTemplateDto> Handle(UpdateTicketTemplateRequest req, CancellationToken cancellationToken)
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

        var dto = req.TicketUpdateDto;
        var authoriId = _userAccessor.User.GetUserId();

        var update = new TicketTemplateUpdate()
        {
            Description = dto.Description,
            Price = dto.Price,
            Name = dto.Name,
            Avaliable = dto.Avaliable,
        };

        ticketTemplate.Update(update, authoriId);

        await _conventionRepository.SaveChangesAsync();

        return ticketTemplate.ToDto();
    }
}