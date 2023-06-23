using MediatR;
using TicketTemplateDomain.Application.Dtos;
using TicketTemplateDomain.Domain.Repositories;

namespace TicketTemplateDomain.Application.Features.TicketTemplates;

public class GetTicketTemplateRequest : IRequest<TicketTemplateDto>
{
    public required Guid Id { get; init; }
}

public class GetTicketTemplateRequestHandler : IRequestHandler<GetTicketTemplateRequest, TicketTemplateDto>
{
    private readonly ITicketTemplateRepository _ticketTemplateRepository;

    public GetTicketTemplateRequestHandler(ITicketTemplateRepository ticketTemplateRepository)
    {
        _ticketTemplateRepository = ticketTemplateRepository;
    }

    public async Task<TicketTemplateDto> Handle(GetTicketTemplateRequest request, CancellationToken cancellationToken)
    {
        var entityId = request.Id;

        var entity = await _ticketTemplateRepository.GetOneRequiredAsync(entityId);

        return entity.ToDto();
    }
}