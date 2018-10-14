using System.Threading;
using System.Threading.Tasks;
using DDFramework;
using ENarudzbenice2.Application.Exceptions;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Persistence;
using MediatR;

namespace ENarudzbenice2.Application.Features.Djelatnosti.Requests
{
    public abstract class DjelatnostDelete
    {
        public class Request : BaseEntity, IRequest<Djelatnost>
        {
            
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
                var entity = _context.Djelatnosti.Find(request.Id);

                if (entity is null)
                {
                    throw new NotFoundException(nameof(Djelatnost), request.Id);
                }

                _context.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
        }
    }
}
