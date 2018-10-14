using ENarudzbenice2.Persistence;

namespace ENarudzbenice2.Application.Infrastructure
{
    public class BaseEfRequestHandler
    {
        protected readonly ApplicationDbContext _context;

        public BaseEfRequestHandler(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
