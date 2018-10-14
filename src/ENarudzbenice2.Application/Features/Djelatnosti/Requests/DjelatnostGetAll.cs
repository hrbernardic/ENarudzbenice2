using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ENarudzbenice2.Application.Infrastructure;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ENarudzbenice2.Application.Features.Djelatnosti.Requests
{
    public abstract class DjelatnostGetAll
    {
        public class Request : IRequest<List<Djelatnost>>
        {
        }

        public class RequestHandler : BaseEfRequestHandler, IRequestHandler<Request, List<Djelatnost>>
        {
            public RequestHandler(ApplicationDbContext context) : base(context)
            {
            }

            public Task<List<Djelatnost>> Handle(Request request, CancellationToken cancellationToken)
            {
                return _context.Djelatnosti.AsNoTracking().ToListAsync(cancellationToken);
            }
        }
    }
}
