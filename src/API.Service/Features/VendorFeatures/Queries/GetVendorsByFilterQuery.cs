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
    public class GetVendorsByFilterQuery : IRequest<Response<Vendor>>
    {
        public string? Filter { get; set; }
        public class GetVendorsByFilterQueryHandler : IRequestHandler<GetVendorsByFilterQuery, Response<Vendor>>
        {
            private readonly IApplicationDbContext _context;
            public GetVendorsByFilterQueryHandler(IApplicationDbContext context) { 
                _context = context;
            }
            public async Task<Response<Vendor>> Handle(GetVendorsByFilterQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var vendors = await _context.Vendors!.Where(c => string.IsNullOrEmpty(request.Filter) || c.Name!.ToLower().Contains(request.Filter!.ToLower())).ToListAsync();
                    return Response<Vendor>.Success(vendors.AsReadOnly());
                }
                catch (Exception ex)
                {
                    return Response<Vendor>.Fail(StatusCode.InvalidArgument, ex.Message);
                }                        
            }
        }
    }
}
