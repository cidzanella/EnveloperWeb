using EnveloperWeb.Domain.Entities;
using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByLoginAsync(string login);
    }
}
