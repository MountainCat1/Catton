using Catton.ApiClient;
using Catut.Application.Errors;
using MassTransit.Internals;
using MediatR;
using OpenApi.Convention;
using TicketTemplateDomain.Application.Dtos;
using TicketTemplateDomain.Application.Services;
using TicketTemplateDomain.Domain.Entities;
using TicketTemplateDomain.Domain.Repositories;

namespace TicketTemplateDomain.Application.Features.TicketTemplates;

public class CreateTicketTemplateRequest : IRequest<TicketTemplateDto>
{
    public required TicketTemplateCreateDto TicketTemplateCreateDto { get; init; }
    public Guid ConventionId { get; init; }
}

public class CreateTicketTemplateRequestHandler : IRequestHandler<CreateTicketTemplateRequest, TicketTemplateDto>
{
    private readonly ITicketTemplateRepository _ticketTemplateRepository;
    private readonly IConventionApi _conventionApi;
    private readonly IAuthTokenAccessor _tokenAccessor;

    public CreateTicketTemplateRequestHandler(
        ITicketTemplateRepository ticketTemplateRepository,
        IConventionApi conventionApi,
        IAuthTokenAccessor tokenAccessor)
    {
        _ticketTemplateRepository = ticketTemplateRepository;
        _conventionApi = conventionApi;
        _tokenAccessor = tokenAccessor;
    }

    public async Task<TicketTemplateDto> Handle(CreateTicketTemplateRequest request, CancellationToken ct)
    {
        var jwt = _tokenAccessor.GetToken();
        var dto = request.TicketTemplateCreateDto;
        var conventionId = request.ConventionId;
        var convention = await _conventionApi.AddJwt(jwt).ConventionGETAsync(conventionId, ct);

        if (convention is null)
            throw new NotFoundError($"Convnetion with id {conventionId} doesn't exist");
            
        var entity = TicketTemplate.Create(
            description: dto.Description,
            price: dto.Price,
            conventionId: conventionId
        );

        await _ticketTemplateRepository.AddAsync(entity);
        await _ticketTemplateRepository.SaveChangesAsync();

        return entity.ToDto();
    }
}