using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDFramework;
using ENarudzbenice2.Application.Infrastructure;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Persistence;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ENarudzbenice2.Application.Features.Djelatnosti.Requests
{
    public abstract class DjelatnostQuery
    {
        public class Request : TableQueryRequest, IRequest<TableQueryResponse<DjelatnostBrowse>> {
            public Request(TableQueryRequest request) : base(request)
            {
            }
        }

        public class RequestHandler : BaseEfRequestHandler, IRequestHandler<Request, TableQueryResponse<DjelatnostBrowse>>
        {
            public RequestHandler(ApplicationDbContext context) : base(context) { }

            public Task<TableQueryResponse<DjelatnostBrowse>> Handle(Request request, CancellationToken cancellationToken)
            {
                return _context.DjelatnostiBrowse
                    .Search(request.GlobalFilter)
                    .SortByPropertyString(request.SortProperty, request.SortOrder)
                    .GetPagedAsync(request.PageIndex, request.PageSize);
            }
        }
    }
}
