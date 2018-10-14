using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ENarudzbenice2.Application.Infrastructure;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ENarudzbenice2.Application.Features.Adrese.Requests
{
    public class AdreseGetAll
    {
        public class Request : IRequest<List<Adresa>>
        {
        }

        public class RequestHandler : BaseEfRequestHandler, IRequestHandler<Request, List<Adresa>>
        {
            public RequestHandler(ApplicationDbContext context) : base(context)
            {
            }

            public Task<List<Adresa>> Handle(Request request, CancellationToken cancellationToken)
            {
                return _context.Adrese.AsNoTracking().ToListAsync(cancellationToken);
            }
        }
    }
}
