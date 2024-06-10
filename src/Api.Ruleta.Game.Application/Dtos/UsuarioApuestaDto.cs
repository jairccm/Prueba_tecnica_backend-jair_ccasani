using Api.Ruleta.Game.Application.Enums;

namespace Api.Ruleta.Game.Application.Dtos
{
    public class UsuarioApuestaDto
    {
        public Color color { get; set; }
        public TipoNumero tipoNumero { get; set; }
        public int? numero { get; set; }
        public decimal montoApuesta { get; set; }
        public decimal montoSaldo { get; set; }
    }
}
