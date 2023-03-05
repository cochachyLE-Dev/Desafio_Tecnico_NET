using API.Domain.Entities;
using API.Domain.Shared;
using API.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Service.Features.SaleFeatures.Queries
{
    public class GetAllSalesQuery : IRequest<Response<Sale>>
    {
        public class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQuery, Response<Sale>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllSalesQueryHandler(IApplicationDbContext context) {
                _context = context;
            }
            public async Task<Response<Sale>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
            {                
                try
                {
                    var sales = await _context.Sales!.ToListAsync();
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
