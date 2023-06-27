using Catton.ApiClient;
using Catut.Application.Errors;
using MediatR;
using OpenApi.Conventions;
using TicketTemplateDomain.Application.Dtos;
using TicketTemplateDomain.Application.Services;
using TicketTemplateDomain.Domain.Entities;
using TicketTemplateDomain.Domain.Repositories;
using ApiException = OpenApi.Account.ApiException;

namespace TicketTemplateDomain.Application.Features.TicketTemplates;

public class CreateTicketTemplateRequest : IRequest<TicketTemplateDto>
{
    public required TicketTemplateCreateDto TicketTemplateCreateDto { get; init; }
    public Guid ConventionId { get; init; }
}

public class CreateTicketTemplateRequestHandler : IRequestHandler<CreateTicketTemplateRequest, TicketTemplateDto>
{
    private readonly ITicketTemplateRepository _ticketTemplateRepository;
    private readonly IConventionsApi _conventionsApi;
    private readonly IAuthTokenAccessor _tokenAccessor;

    public CreateTicketTemplateRequestHandler(
        ITicketTemplateRepository ticketTemplateRepository,
        IConventionsApi conventionsApi,
        IAuthTokenAccessor tokenAccessor)
    {
        _ticketTemplateRepository = ticketTemplateRepository;
        _conventionsApi = conventionsApi;
        _tokenAccessor = tokenAccessor;
    }

    public async Task<TicketTemplateDto> Handle(CreateTicketTemplateRequest request, CancellationToken ct)
    {
        var jwt = _tokenAccessor.GetToken();
        var dto = request.TicketTemplateCreateDto;
        var conventionId = request.ConventionId;
        var conventions = await _conventionsApi.AddJwt(jwt).ConventionsGETAsync(conventionId, ct);
        
        if (conventions is null)
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