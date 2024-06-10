namespace Api.Ruleta.Game.Domain.Entities;

public partial class RuletaUsuario
{
    public string Nombre { get; set; } = null!;

    public decimal? Monto { get; set; }
}
