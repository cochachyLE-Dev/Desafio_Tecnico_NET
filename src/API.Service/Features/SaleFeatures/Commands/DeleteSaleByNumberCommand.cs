using API.Domain.Shared;
using API.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Service.Features.SaleFeatures.Commands
{
    public class DeleteSaleByNumberCommand : IRequest<Response>
    {
        public string? Serie { get; set; }
        public string? Number { get; set; }
        public class DeleteSaleByNumberCommandHandler : IRequestHandler<DeleteSaleByNumberCommand, Response>
        {
            private readonly IApplicationDbContext _context;
            public DeleteSaleByNumberCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(DeleteSaleByNumberCommand request, CancellationToken cancellationToken)
            {                
                try
                {
                    var sale = await _context.Sales!.FirstOrDefaultAsync(c => c.Serie == request.Serie && c.Number == request.Number);
                    if(sale == null) return Response.Fail(StatusCode.InvalidArgument, "sale not found");
                    _context.Sales!.Remove(sale);
                    await _context.SaveChangesAsync();

                    return Response.Success("Successfull");
                }
                catch (Exception ex)
                {
                    return Response.Fail(StatusCode.InvalidArgument,ex.Message);
                }
            }
        }
    }
}
