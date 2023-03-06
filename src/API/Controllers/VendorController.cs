using API.Service.Features.SellerFeatures.Queries;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase    
    {
        private IMediator? _mediator;
        public VendorController(IMediator? mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Search")]
        public async Task<IActionResult> GetSearchAsync(string filter)
        {
            return Ok(await _mediator!.Send(new GetVendorsByFilterQuery() { Filter = filter }));
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator!.Send(new GetVendorsByFilterQuery()));
        }
    }
}
