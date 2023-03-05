using API.Service.Features.ServiceFeatures.Queries;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase    
    {
        private IMediator? _mediator;
        public ServiceController(IMediator? mediator) {
            _mediator = mediator;
        }        

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync(string filter)
        {
            return Ok(await _mediator!.Send(new GetServicesByFilterQuery() { Filter = filter }));
        }
    }
}
