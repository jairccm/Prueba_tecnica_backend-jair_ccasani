using Api.Ruleta.Game.Application.Enums;

namespace Api.Ruleta.Game.Application.Dtos;

    public class ResultadoRuletaDto
    {
        public Color color { get; set; }
        public TipoNumero tipoNumero { get; set; }
        public int numero { get; set; }
    }

