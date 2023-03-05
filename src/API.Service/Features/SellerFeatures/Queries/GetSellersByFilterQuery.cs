using API.Domain.Entities;
using API.Domain.Shared;
using API.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Service.Features.SellerFeatures.Queries
{
    public class GetSellersByFilterQuery : IRequest<Response<Seller>>
    {
        public string? Filter { get; set; }
        public class GetSellersByFilterQueryHandler : IRequestHandler<GetSellersByFilterQuery, Response<Seller>>
        {
            private readonly IApplicationDbContext _context;
            public GetSellersByFilterQueryHandler(IApplicationDbContext context) { 
                _context = context;
            }
            public async Task<Response<Seller>> Handle(GetSellersByFilterQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var sellers = await _context.Sellers!.Where(c => string.IsNullOrEmpty(request.Filter) || c.Name!.ToLower().Contains(request.Filter!.ToLower())).ToListAsync();
                    return Response<Seller>.Success(sellers.AsReadOnly());
                }
                catch (Exception ex)
                {
                    return Response<Seller>.Fail(StatusCode.InvalidArgument, ex.Message);
                }                        
            }
        }
    }
}
