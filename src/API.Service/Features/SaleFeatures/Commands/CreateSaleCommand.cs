using API.Domain.Entities;
using API.Domain.Shared;
using API.Persistence;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Service.Features.SaleFeatures.Commands
{
    public class CreateSaleCommand: IRequest<Response>
    {
        public string? Serie { get; set; }
        public string? Number { get; set; }
        public int SellerId { get; set; }
        public double Total { get; set; }
        
        public List<SaleDetail>? SaleDetails { get; set; }

        public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Response>
        {
            private readonly IApplicationDbContext _context;
            public CreateSaleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
            {
                Response response = new Response();
                try
                {
                    var sale = new Sale();
                    sale.Number = request.Number;
                    sale.Serie = request.Serie;
                    sale.SellerId = request.SellerId;
                    sale.Total = request.Total;
                    _context.Sales?.Add(sale);

                    if (request.SaleDetails!.Any())
                        _context.SaleDetails!.AddRange(request.SaleDetails!);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    response = Response.Fail(StatusCode.InvalidArgument, ex.Message);
                }
                return response;
            }
        }
    }
}
