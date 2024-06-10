using Api.Ruleta.Game.Domain.Entities;
using Api.Ruleta.Game.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Ruleta.Game.Infraestructure.Repository
{
    public class RuletaGameRepository : IRuletaGameRepository
    {
        private readonly BdtestContext _context;
        public RuletaGameRepository(BdtestContext context) 
        {
            _context = context;
        }

        public async Task<int> ActualizarUsuarioData(RuletaUsuario ruletaUsuario)
        {
            _context.Attach(ruletaUsuario);
            _context.Entry(ruletaUsuario).Property(p => p.Monto).IsModified = true;
            return await _context.SaveChangesAsync();
        }

        public async Task<RuletaUsuario> BuscarUsuarioData(string nombre)
        {
            return await _context.RuletaUsuarios?
                .Where(x => x.Nombre.Trim().ToLower().Equals(nombre.Trim().ToLower()))?
                .FirstOrDefaultAsync();
        }

        public async Task<int> GuardarUsuarioData(RuletaUsuario ruletaUsuario)
        {
             await _context.RuletaUsuarios.AddAsync(ruletaUsuario);
            return await _context.SaveChangesAsync();
        }
    }
}
