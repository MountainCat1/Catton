using Catut.Application.Dtos;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Features.ConventionFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conventions.Api.Controllers;

    [ApiController]
    [Authorize]
    [Route("api/conventions")]
    public class ConventionController : Controller
    {
        private readonly ICommandMediator _commandMediator;
        private readonly IQueryMediator _queryMediator;

        public ConventionController(ICommandMediator commandMediator, IQueryMediator queryMediator)
        {
            _commandMediator = commandMediator;
            _queryMediator = queryMediator;
        }

        [HttpPost]
        [ProducesResponseType( typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType( typeof(ConventionDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ConventionCreateDto conventionCreateDto)
        {
            var request = new CreateConventionRequest()
            {
                ConventionCreateDto = conventionCreateDto
            };
            
            var result = await _commandMediator.SendAsync(request);

            return Ok(result);
        }
        
        
        [HttpGet("{id}")]
        [ProducesResponseType( typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType( typeof(ConventionDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var request = new GetConventionRequest()
            {
                Id = id
            };
            
            var result = await _queryMediator.SendAsync(request);

            return Ok(result);
        }
        
        [HttpGet("")]
        [ProducesResponseType( typeof(ErrorResponse),StatusCodes.Status401Unauthorized)]
        [ProducesResponseType( typeof(ICollection<ConventionDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllConventionsRequest()
            {
                AccountId = User.GetUserId()
            };
            
            var result = await _queryMediator.SendAsync(request);

            return Ok(result);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType( typeof(ErrorResponse),StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] ConventionUpdateDto updateDto)
        {
            var request = new UpdateConventionRequest()
            {
                Id = id,
                UpdateDto = updateDto
            };

            await _commandMediator.SendAsync(request);

            return Ok();
        }
    }