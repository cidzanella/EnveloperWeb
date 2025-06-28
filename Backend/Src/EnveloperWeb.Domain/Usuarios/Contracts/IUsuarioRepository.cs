using EnveloperWeb.Domain.Usuarios.Entities;

namespace EnveloperWeb.Domain.Usuarios.Contracts
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorIdAsync(int id);
        Task<Usuario> ObterPorLoginAsync(string login);
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
    }
}
