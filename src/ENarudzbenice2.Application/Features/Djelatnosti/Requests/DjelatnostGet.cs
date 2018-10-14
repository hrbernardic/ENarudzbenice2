using System;
using System.Threading;
using System.Threading.Tasks;
using ENarudzbenice2.Application.Exceptions;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Persistence;
using MediatR;

namespace ENarudzbenice2.Application.Features.Djelatnosti.Requests
{
    public abstract class DjelatnostGet
    {
        public class Request : IRequest<Djelatnost>
        {
            public Guid Id { get; set; }
        }

        public class RequestHandler : IRequestHandler<Request, Djelatnost>
        {
            private readonly ApplicationDbContext _context;

            public RequestHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Djelatnost> Handle(Request request, CancellationToken cancellationToken)
            {
                var entity = await _context.Djelatnosti.FindAsync(request.Id);

                if (entity is null)
                {
                    throw new NotFoundException(nameof(Djelatnost), request.Id);
                }

                return entity;
            }
        }
    }
}
