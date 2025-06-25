using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
