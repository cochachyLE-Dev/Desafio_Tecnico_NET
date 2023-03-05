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
    public class GetSalesBySellerNameQuery : IRequest<Response<Sale>>
    {
        public string? Serie { get; set; }
        public string? Number { get; set; }
        public class GetSalesBySellerNameQueryHandler : IRequestHandler<GetSalesBySellerNameQuery, Response<Sale>>
        {
            private readonly IApplicationDbContext _context;
            public GetSalesBySellerNameQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response<Sale>> Handle(GetSalesBySellerNameQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var sales = await _context.Sales!.Where(c => c.Serie == request.Serie && c.Number == request.Number).ToListAsync();
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
