using System.Threading;
using System.Threading.Tasks;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Persistence;
using MediatR;

namespace ENarudzbenice2.Application.Features.Djelatnosti.Requests
{
    public abstract class DjelatnostCreate
    {
        public class Request : IRequest<Djelatnost>
        {
            public string Naziv { get; set; }
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
                var djelatnost = new Djelatnost
                {
                    Naziv = request.Naziv
                };

                _context.Djelatnosti.Add(djelatnost);

                await _context.SaveChangesAsync(cancellationToken);

                return djelatnost;
            }
        }
    }
}
