using EnveloperWeb.Domain.Entities;
using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByLoginAsync(string login);
    }
}
