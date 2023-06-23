using MediatR;
using PaymentDomain.Application.Dtos;
using PaymentDomain.Domain.Entities;
using PaymentDomain.Domain.Repositories;

namespace PaymentDomain.Application.Features.ConventionTickets;

public class CreateConventionTicketRequest : IRequest<ConventionTicketDto>
{
    public required ConventionTicketCreateDto ConventionTicketCreateDto { get; init; }
}

public class CreateConventionTicketRequestHandler : IRequestHandler<CreateConventionTicketRequest, ConventionTicketDto>
{
    private readonly IConventionTicketRepository _conventionTicketRepository;

    public CreateConventionTicketRequestHandler(IConventionTicketRepository conventionTicketRepository)
    {
        _conventionTicketRepository = conventionTicketRepository;
    }

    public async Task<ConventionTicketDto> Handle(CreateConventionTicketRequest request, CancellationToken cancellationToken)
    {
        var dto = request.ConventionTicketCreateDto;

        var entity = await ConventionTicket.CreateAsync(
            conventionId: dto.ConventionId,
            description: dto.Description
        );

        await _conventionTicketRepository.AddAsync(entity);
        await _conventionTicketRepository.SaveChangesAndThrowAsync();

        return entity.ToDto();
    }
}