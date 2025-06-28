using EnveloperWeb.Domain.Turnos.Entities;

namespace EnveloperWeb.Domain.Turnos.Contracts
{
    public interface ITurnoRepository
    {
        Task<Turno> ObterPorIdAsync(int id);
        Task<IEnumerable<Turno>> ObterTodosAsync();
        Task AdicionarAsync(Turno turno);
    }
}
