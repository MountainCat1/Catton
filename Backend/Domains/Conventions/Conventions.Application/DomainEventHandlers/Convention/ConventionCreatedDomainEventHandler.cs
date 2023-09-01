// using Catut.Domain.Abstractions;
// using ConventionDomain.Application.Dtos.Organizer;
// using ConventionDomain.Application.Features.OrganizerFeature;
// using Conventions.Domain.Entities;
// using Conventions.Domain.Events;
// using MediatR;
//
// namespace ConventionDomain.Application.DomainEventHandlers.Convention;
//
// public class ConventionCreatedDomainEventHandler : IDomainEventHandler<ConventionCreatedDomainEvent>
// {
//
//     private IMediator _mediator;
//     
//     public ConventionCreatedDomainEventHandler(IMediator mediator)
//     {
//         _mediator = mediator;
//     }
//
//     public async Task Handle(ConventionCreatedDomainEvent notification, CancellationToken cancellationToken)
//     {
//         // When new convention is created, add the creator as an organizator
//         
//         var request = new CreateOrganizerRequest()
//         {
//             ConventionId = notification.Entity.Id,
//             OrganizerCreateDto = new OrganizerCreateDto()
//             {
//                 AtendeeId = notification.AtendeeId,
//                 Role = OrganizerRole.Administrator
//             }
//         };
//
//         await _mediator.Send(request, cancellationToken);
//     }
// }