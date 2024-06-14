using Api.Ruleta.Game.Application.Constantes;
using Api.Ruleta.Game.Application.Dtos;
using Api.Ruleta.Game.Application.Enums;
using Api.Ruleta.Game.Application.Singletons;
using Api.Ruleta.Game.Domain.Entities;
using Api.Ruleta.Game.Infraestructure.Repository;
using System.Linq.Expressions;

namespace Api.Ruleta.Game.Application.Services
{
    public class RuletaGameService : IRuletaGameService
    {
        private readonly IRuletaGameRepository _repository;
        public RuletaGameService(IRuletaGameRepository repository) 
        { 
            _repository = repository;
        }
        public async Task<NumeroRuletaDto> GetNumeroAzar()
        {
            return await Task.Run<NumeroRuletaDto>(() =>
            {
                var random = new Random();

                var numero = Enumerable.Range(0, 36).OrderBy(num => random.Next()).FirstOrDefault();
                var color = new List<String> {"red", "black" }.OrderBy(num => random.Next()).FirstOrDefault();

                return new NumeroRuletaDto { color=color,numero=numero};
            });
        }

        public async Task<PremioDto> GetPremioResultado(ResultadoRuletaDto resultado)
        {
            return await Task<PremioDto>.Run(() =>
            {
                var usuarioApuesta = UsuarioApuesta.Instance;

                var premio = new PremioDto();


                switch (usuarioApuesta.apuestaAdicional)
                {
                    case ApuestaAdicional.NUMERO:
                        if (resultado.color == usuarioApuesta.color && resultado.numero == usuarioApuesta.numero)
                        {
                            premio.ganaPremio = true;
                            premio.montoPremio = usuarioApuesta.montoApuesta * 3;
                            premio.montoApostado = usuarioApuesta.montoApuesta;
                            return premio;
                        }
                        break;
                    case ApuestaAdicional.TIPO_NUMERO:
                        if (resultado.color == usuarioApuesta.color && resultado.tipoNumero == usuarioApuesta.tipoNumero)
                        {
                            premio.ganaPremio = true;
                            premio.montoPremio = usuarioApuesta.montoApuesta;
                            premio.montoApostado = usuarioApuesta.montoApuesta;
                            return premio;
                        }
                        break;
                    case ApuestaAdicional.NINGUNO:
                        if (resultado.color == usuarioApuesta.color)
                        {
                            premio.ganaPremio = true;
                            premio.montoPremio = usuarioApuesta.montoApuesta / 2;
                            premio.montoApostado = usuarioApuesta.montoApuesta;
                            return premio;
                        }
                        break;

                }

                premio.ganaPremio = false;
                premio.montoPremio = usuarioApuesta.montoApuesta * -1;
                premio.montoApostado = usuarioApuesta.montoApuesta;

                return premio;

            });

        }

        public async Task<UsuarioDataDto> GetUsuarioData(string nombre)
        {
            var data = await _repository.BuscarUsuarioData(nombre);

            if (data == null) throw new Exception("No existe usuario");

            return new UsuarioDataDto { existeUsuario=true,monto = data.Monto ?? 0, nombre = data.Nombre};
        }

        public async Task GrabarUsuarioData(UsuarioDataDto usuarioData)
        {
            var usuario = await _repository.BuscarUsuarioData(usuarioData.nombre);

            if (usuario != null)
            {
                if (usuarioData.existeUsuario)
                {
                    usuario.Monto += usuarioData.monto;
                }
                else
                {
                    usuario.Monto = usuarioData.monto;
                }

                var result = await _repository.ActualizarUsuarioData(usuario);
                if (result <= 0) throw new Exception("Error al Actualizar usuario");
                usuarioData.existeUsuario = true;
            }
            else
            {
                var usurioNuevo = new RuletaUsuario { Monto = usuarioData.monto, Nombre = usuarioData.nombre };
                var result = await _repository.GuardarUsuarioData(usurioNuevo);
                if (result <= 0) throw new Exception("Error al grabar usuario");
                usuarioData.existeUsuario = true;
            }

        }
    }
}
