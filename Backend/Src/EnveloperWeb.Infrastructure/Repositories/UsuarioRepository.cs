using EnveloperWeb.Domain.Usuarios.Contracts;
using EnveloperWeb.Domain.Usuarios.Entities;
using EnveloperWeb.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace EnveloperWeb.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> ObterPorLoginAsync(string login)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public Task AtualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return Task.CompletedTask;
        }

        public Task RemoverAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            return Task.CompletedTask;
        }
    }
}
