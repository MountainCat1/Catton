using MediatR;
using TicketTemplateDomain.Application.Dtos;
using TicketTemplateDomain.Domain.Repositories;

namespace TicketTemplateDomain.Application.Features.TicketTemplates;

public class DeleteTicketTemplateRequest : IRequest<TicketTemplateDto>
{
    public required Guid Id { get; init; }
}

public class DeleteTicketTemplateRequestHandler : IRequestHandler<DeleteTicketTemplateRequest, TicketTemplateDto>
{
    private readonly ITicketTemplateRepository _repository;

    public DeleteTicketTemplateRequestHandler(ITicketTemplateRepository repository)
    {
        _repository = repository;
    }

    public async Task<TicketTemplateDto> Handle(DeleteTicketTemplateRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetOneRequiredAsync(request.Id);

        await _repository.DeleteAsync(entity);

        await _repository.SaveChangesAsync();
        
        return entity.ToDto();
    }
}