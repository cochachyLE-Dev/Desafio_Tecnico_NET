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
    public class GetSalesByFilterQuery : IRequest<Response<Sale>>
    {
        public string? Filter { get; set; }
        public class GetSalesBySellerNameQueryHandler : IRequestHandler<GetSalesByFilterQuery, Response<Sale>>
        {
            private readonly IApplicationDbContext _context;
            public GetSalesBySellerNameQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response<Sale>> Handle(GetSalesByFilterQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var sales = await _context.Sales.Where(c => string.IsNullOrEmpty(request.Filter) || c.Vendor!.Name!.ToLower().Contains(request.Filter!.ToLower())).Include(i => i.SaleDetails)!.ThenInclude(i => i.Service).Include(i => i.Vendor).ToListAsync();                    
                    return Response<Sale>.Success(sales.AsReadOnly());
                }
                catch (Exception ex)
                {
                    return Response<Sale>.Fail(StatusCode.InvalidArgument, ex.Message);
                }
            }
        }
    }
}
