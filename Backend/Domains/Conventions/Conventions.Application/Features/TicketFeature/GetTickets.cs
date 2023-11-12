// using Catut.Application.Errors;
// using ConventionDomain.Application.Abstractions;
// using ConventionDomain.Application.Authorization;
// using ConventionDomain.Application.Dtos.Ticket;
// using ConventionDomain.Application.Dtos.TicketTemplate;
// using ConventionDomain.Application.Extensions;
// using ConventionDomain.Application.Services;
// using Conventions.Domain.Repositories;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
//
// namespace ConventionDomain.Application.Features.TicketFeature;
//
// public class GetTicketRequest : IQuery<TicketDto>
// {
//     public required string ConventionId { get; init; }
//     public required Guid AttendeeAccountId { get; init; }
//     public required Guid TicketId { get; init; }
// }
//
// public class GetTicketRequestHandler : IRequestHandler<GetTicketRequest, TicketDto>
// {
//     private readonly IConventionRepository _conventionRepository;
//     private readonly IAuthorizationService _authorizationService;
//     private readonly IUserAccessor _userAccessor;
//
//     public GetTicketRequestHandler(
//         IConventionRepository conventionRepository,
//         IAuthorizationService authorizationService,
//         IUserAccessor userAccessor)
//     {
//         _conventionRepository = conventionRepository;
//         _authorizationService = authorizationService;
//         _userAccessor = userAccessor;
//     }
//
//     public async Task<TicketDto> Handle(GetTicketRequest req, CancellationToken cancellationToken)
//     {
//         var convention = await _conventionRepository.GetConvention(req.ConventionId);
//
//         if (convention is null)
//             throw new NotFoundError($"Convention with id {req.ConventionId} was not found");
//
//         await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention,
//             Policies.);
//         
//         var attendee = convention.Attendees.FirstOrDefault(x => x.Id == req.AttendeeAccountId);
//
//         if (attendee is null)
//             throw new UnauthorizedError();
//
//
//
//         if (Ticket is null)
//             throw new NotFoundError(
//                 $"Ticket template with id {req.TicketId} was not found for a convention ({req.ConventionId})");
//
//         return Ticket.ToDto();
//     }
// }