using Api.Ruleta.Game.Domain.Entities;

namespace Api.Ruleta.Game.Infraestructure.Repository
{
    public interface IRuletaGameRepository
    {
        Task<int> GuardarUsuarioData(RuletaUsuario ruletaUsuario);
        Task<int> ActualizarUsuarioData(RuletaUsuario ruletaUsuario);
        Task<RuletaUsuario> BuscarUsuarioData(string nombre);
    }
}
