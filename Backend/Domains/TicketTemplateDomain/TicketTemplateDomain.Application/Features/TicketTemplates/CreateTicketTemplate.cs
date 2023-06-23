using MediatR;
using TicketTemplateDomain.Application.Dtos;
using TicketTemplateDomain.Domain.Entities;
using TicketTemplateDomain.Domain.Repositories;

namespace TicketTemplateDomain.Application.Features.TicketTemplates;

public class CreateTicketTemplateRequest : IRequest<TicketTemplateDto>
{
    public required TicketTemplateCreateDto TicketTemplateCreateDto { get; init; }
}

public class CreateTicketTemplateRequestHandler : IRequestHandler<CreateTicketTemplateRequest, TicketTemplateDto>
{
    private readonly ITicketTemplateRepository _ticketTemplateRepository;

    public CreateTicketTemplateRequestHandler(ITicketTemplateRepository ticketTemplateRepository)
    {
        _ticketTemplateRepository = ticketTemplateRepository;
    }

    public async Task<TicketTemplateDto> Handle(CreateTicketTemplateRequest request, CancellationToken cancellationToken)
    {
        var dto = request.TicketTemplateCreateDto;

        var entity = TicketTemplate.Create(
            description: dto.Description,
            price: dto.Price,
            conventionId: dto.ConventionId
        );

        await _ticketTemplateRepository.AddAsync(entity);
        await _ticketTemplateRepository.SaveChangesAsync();

        return entity.ToDto();
    }
}