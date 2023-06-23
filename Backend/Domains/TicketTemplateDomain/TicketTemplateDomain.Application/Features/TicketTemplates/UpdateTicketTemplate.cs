using MediatR;
using TicketTemplateDomain.Application.Dtos;
using TicketTemplateDomain.Domain.Entities;
using TicketTemplateDomain.Domain.Repositories;

namespace TicketTemplateDomain.Application.Features.TicketTemplates;

public class UpdateTicketTemplateRequest : IRequest<TicketTemplateDto>
{
    public required Guid Id { get; init; }
    public required TicketTemplateUpdateDto UpdateDto { get; init; }
}

public class UpdateTicketTemplateRequestHandler : IRequestHandler<UpdateTicketTemplateRequest, TicketTemplateDto>
{
    private readonly ITicketTemplateRepository _repository;

    public UpdateTicketTemplateRequestHandler(ITicketTemplateRepository repository)
    {
        _repository = repository;
    }

    public async Task<TicketTemplateDto> Handle(UpdateTicketTemplateRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetOneRequiredAsync(request.Id);

        var updateDto = request.UpdateDto;

        var update = new TicketTemplateUpdate(updateDto.Description, updateDto.Price);

        entity.Update(update);

        await _repository.SaveChangesAsync();
        
        return entity.ToDto();
    }
}