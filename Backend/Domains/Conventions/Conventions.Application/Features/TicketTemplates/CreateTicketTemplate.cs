using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.TicketTemplate;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ConventionDomain.Application.Features.TicketTemplates;

public class CreateTicketTemplateRequest : IRequest<TicketTemplateDto>
{
    public required TicketTemplateCreateDto TicketCreateDto { get; init; }
    public required Guid ConventionId { get; init; }
}

public class CreateTicketRequestHandler : IRequestHandler<CreateTicketTemplateRequest, TicketTemplateDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public CreateTicketRequestHandler(
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
        var convention = await _conventionRepository.GetOneRequiredAsync(request.ConventionId);

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.UpdateConvention);

        var dto = request.TicketCreateDto;

        var ticketTemplate = TicketTemplate.Create(
            name: dto.Name, 
            description: dto.Description, 
            price: dto.Price,
            conventionId: default, 
            authorId: default);

        convention.AddTicketTemplate(ticketTemplate);

        await _conventionRepository.SaveChangesAsync();

        return ticketTemplate.ToDto();
    }
}