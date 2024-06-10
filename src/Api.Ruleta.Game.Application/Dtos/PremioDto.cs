namespace Api.Ruleta.Game.Application.Dtos;

    public class PremioDto
    {
        public bool ganaPremio { get; set; }
        public decimal montoApostado { get; set; }
        public decimal montoPremio { get; set; } = 0;
    }

