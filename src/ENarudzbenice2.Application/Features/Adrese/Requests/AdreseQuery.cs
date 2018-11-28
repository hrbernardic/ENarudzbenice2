using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDFramework;
using ENarudzbenice2.Application.Infrastructure;
using ENarudzbenice2.Persistence;
using MediatR;

namespace ENarudzbenice2.Application.Features.Adrese.Requests
{
    public class AdreseQuery
    {
        public class Request : TableQueryRequest, IRequest<TableQueryResponse<AdresaBrowse>> {
            public Request(TableQueryRequest request) : base(request)
            {
            }
        }

        public class RequestHandler : BaseEfRequestHandler, IRequestHandler<Request, TableQueryResponse<AdresaBrowse>>
        {
            public RequestHandler(ApplicationDbContext context) : base(context) { }

            public Task<TableQueryResponse<AdresaBrowse>> Handle(Request request, CancellationToken cancellationToken)
            {
                return _context.AdreseBrowse
                    .Search(request.GlobalFilter)
                    .SortByPropertyString(request.SortProperty, request.SortOrder)
                    .GetPagedAsync(request.PageIndex, request.PageSize);
            }
        }
    }
}
