using Boundary.Context.Property;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertiesController :
        ControllerBase
    {
        private readonly ISender _mediator;

        public PropertiesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
			return Ok(Environment.GetEnvironmentVariable("CONNECTIONSTRINGS__APPLICATIONDATABASE"));
            var command = new CreatePropertyAdCommand
            {
                Title = "New Title",
                UserId = Guid.NewGuid()
            };
            await _mediator.Send(command, token);
            return Ok(1);
        }
    }
}
