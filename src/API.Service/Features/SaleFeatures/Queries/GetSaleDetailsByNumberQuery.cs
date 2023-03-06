using API.Domain.Entities;
using API.Domain.Shared;
using API.Persistence;
using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Service.Features.SaleFeatures.Queries
{
    public class GetSaleDetailsByNumberQuery : IRequest<Response<Sale>>
    {
        public string? Serie { get; set; }
        public string? Number { get; set; }
        public class GetSaleDetailsByNumberQueryHandler : IRequestHandler<GetSaleDetailsByNumberQuery, Response<Sale>>
        {
            private readonly IApplicationDbContext _context;
            public GetSaleDetailsByNumberQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response<Sale>> Handle(GetSaleDetailsByNumberQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var saleDetail = await _context.Sales.Where(c => c.Serie == request.Serie && c.Number == request.Number).Include(i => i.SaleDetails)!.ThenInclude(i => i.Service).Include(i => i.Vendor).ToListAsync();
                    return Response<Sale>.Success(saleDetail.AsReadOnly());
                }
                catch (Exception ex)
                {
                    return Response<Sale>.Fail(StatusCode.InvalidArgument, ex.Message);
                }
            }
        }
    }
}
