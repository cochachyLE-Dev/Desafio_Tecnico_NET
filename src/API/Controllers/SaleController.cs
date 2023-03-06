using API.Domain.Entities;
using API.Service.Features.SaleFeatures.Commands;
using API.Service.Features.SaleFeatures.Queries;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private IMediator? _mediator;
        public SaleController(IMediator? mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> SalesRegisterAsync([FromBody] Sale request)
        {
            return Ok(await _mediator!.Send(new CreateSaleCommand { 
                Serie = request.Serie,
                Number = request.Number,
                SellerId = request.VendorId,
                Total = request.Total,
                SaleDetails = request.SaleDetails
            }));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(string serie, string number)
        {
            return Ok(await _mediator!.Send(new DeleteSaleByNumberCommand
            {
                Serie = serie,
                Number = number
            }));
        }
        [HttpGet("Search")]
        public async Task<IActionResult> GetByFilterAsync(string filter)
        {
            return Ok(await _mediator!.Send(new GetSalesByFilterQuery(){ Filter = filter }));
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator!.Send(new GetAllSalesQuery()));
        }
        [HttpGet("Single/{serie}/{number}")]
        public async Task<IActionResult> GetDetailByNumberAsync(string serie, string number)
        {
            return Ok(await _mediator!.Send(new GetSaleDetailsByNumberQuery() { Serie = serie, Number = number }));
        }
    }
}
