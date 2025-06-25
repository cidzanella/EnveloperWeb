using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
