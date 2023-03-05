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

namespace API.Service.Features.ServiceFeatures.Queries
{
    public class GetServicesByFilterQuery : IRequest<Response<API.Domain.Entities.Service>>
    {
        public string? Filter { get; set; }
        public class GetServicesByFilterQueryHandler : IRequestHandler<GetServicesByFilterQuery, Response<API.Domain.Entities.Service>>
        {
            private readonly IApplicationDbContext _context;
            public GetServicesByFilterQueryHandler(IApplicationDbContext contenxt) {
                _context = contenxt;
            }
            public async Task<Response<Domain.Entities.Service>> Handle(GetServicesByFilterQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var services = await _context.Services!.Where(c=> string.IsNullOrEmpty(request.Filter) || c.Name!.ToLower().Contains(request.Filter!.ToLower())).ToListAsync();
                    return Response<Domain.Entities.Service>.Success(services);
                }
                catch (Exception ex)
                {
                    return Response<Domain.Entities.Service>.Fail(StatusCode.InvalidArgument,ex.Message);
                }
            }
        }
    }
}
