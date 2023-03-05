using API.Service.Features.SellerFeatures.Queries;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase    
    {
        private IMediator? _mediator;
        public SellerController(IMediator? mediator)
        {
            _mediator = mediator;
        }        

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync(string filter)
        {
            return Ok(await _mediator!.Send(new GetSellersByFilterQuery() { Filter = filter }));
        }
    }
}
