using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Shared.Contracts
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
