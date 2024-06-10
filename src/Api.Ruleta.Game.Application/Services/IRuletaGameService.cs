using Api.Ruleta.Game.Application.Dtos;

namespace Api.Ruleta.Game.Application.Services
{
    public interface IRuletaGameService
    {
        Task<NumeroRuletaDto> GetNumeroAzar();
        Task<UsuarioDataDto> GetUsuarioData(String nombre);
        Task GrabarUsuarioData(UsuarioDataDto usuarioData);
        Task<PremioDto> GetPremioResultado(ResultadoRuletaDto resultado);
    }
}
