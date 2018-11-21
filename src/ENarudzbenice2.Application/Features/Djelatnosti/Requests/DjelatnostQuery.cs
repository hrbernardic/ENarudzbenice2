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
        public class Request : QueryRequest, IRequest<QueryResponse<DjelatnostBrowse>> { }

        public class RequestHandler : BaseEfRequestHandler, IRequestHandler<Request, QueryResponse<DjelatnostBrowse>>
        {
            public RequestHandler(ApplicationDbContext context) : base(context) { }

            public Task<QueryResponse<DjelatnostBrowse>> Handle(Request request, CancellationToken cancellationToken)
            {
                //var test = _context.DjelatnostiBrowse.s



                return _context.DjelatnostiBrowse
                    .AsNoTracking()
                    //.Where(x => x.Naziv.ToString().Contains(request.GlobalFilter) || x.Sifra.ToString().Contains(request.GlobalFilter))

                    .CreateSearchQuery(request.GlobalFilter)
                    //.SearchAllProperties(request.GlobalFilter)
                    .SortByPropertyString(request.SortProperty, request.SortOrder)
                    .GetPagedAsync(request.PageIndex, request.PageSize);
            }

            
        }
    }
}
