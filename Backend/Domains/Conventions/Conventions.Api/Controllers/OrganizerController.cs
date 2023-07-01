using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conventions.Api.Controllers;

[ApiController]
[Route("api/conventions/{conventionId:guid}/organizer")]
public class OrganizerController : Controller
{
    private readonly IMediator _mediator;
    private readonly IAuthorizationService _authorizationService;
}