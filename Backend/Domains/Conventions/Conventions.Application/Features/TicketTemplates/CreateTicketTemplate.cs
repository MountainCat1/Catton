using Catut.Application.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.TicketTemplate;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.TicketTemplates;

public class CreateTicketTemplateRequest : ICommand<TicketTemplateDto>
{
    public required TicketTemplateCreateDto TicketCreateDto { get; init; }
    public required string ConventionId { get; init; }
}

public class CreateTicketTemplateRequestHandler : IRequestHandler<CreateTicketTemplateRequest, TicketTemplateDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public CreateTicketTemplateRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<TicketTemplateDto> Handle(CreateTicketTemplateRequest request, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetConvention(request.ConventionId);

        if (convention is null)
            throw new NotFoundError($"Convention with an id ({request.ConventionId}) was not found");

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.ManageTicketTemplates);

        var dto = request.TicketCreateDto;
        var authoriId = _userAccessor.User.GetUserId();
        
        var ticketTemplate = convention.AddTicketTemplate(
            name: dto.Name, 
            description: dto.Description, 
            price: dto.Price, 
            authoriId: authoriId);

        return ticketTemplate.ToDto();
    }
}