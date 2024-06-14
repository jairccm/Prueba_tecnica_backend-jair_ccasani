using Api.Ruleta.Game.Application.Enums;

namespace Api.Ruleta.Game.Application.Singletons;
public class UsuarioApuesta
{

    public Color color { get; set; }
    public TipoNumero tipoNumero { get; set; }
    public int? numero { get; set; }
    public decimal montoApuesta { get; set; }
    public decimal montoSaldo { get; set; }
    public string apuestaAdicional {  get; set; }

    private static UsuarioApuesta instance = null;
    protected UsuarioApuesta() { }
    public static UsuarioApuesta Instance
    {
        get
        {
            if (instance == null) instance = new UsuarioApuesta();
            return instance;
        }
    }


}
