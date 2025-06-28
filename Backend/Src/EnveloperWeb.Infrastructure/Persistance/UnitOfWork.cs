using EnveloperWeb.Domain.Shared.Contracts;
using EnveloperWeb.Infrastructure.Persistance.Context;
using System.Threading.Tasks;

namespace EnveloperWeb.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
