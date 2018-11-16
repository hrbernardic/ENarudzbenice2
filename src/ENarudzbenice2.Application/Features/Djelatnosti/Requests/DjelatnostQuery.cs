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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ENarudzbenice2.Application.Features.Djelatnosti.Requests
{
    public abstract class DjelatnostQuery
    {
        public class Request : IRequest<QueryResult<Djelatnost>>
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string SortProperty { get; set; }
            public string SortOrder { get; set; }
        }

        public class RequestHandler : BaseEfRequestHandler, IRequestHandler<Request, QueryResult<Djelatnost>>
        {
            public RequestHandler(ApplicationDbContext context) : base(context)
            {
            }

            public Task<QueryResult<Djelatnost>> Handle(Request request, CancellationToken cancellationToken)
            {
                return _context.Djelatnosti
                    .AsNoTracking()
                    .SortByPropertyString(request.SortProperty, request.SortOrder)
                    .GetPagedAsync(request.PageNumber, request.PageSize);
            }
        }
    }
}
