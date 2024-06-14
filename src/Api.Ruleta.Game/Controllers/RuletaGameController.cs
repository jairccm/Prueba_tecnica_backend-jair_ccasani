using Api.Ruleta.Game.Application.Dtos;
using Api.Ruleta.Game.Application.Enums;
using Api.Ruleta.Game.Application.Services;
using Api.Ruleta.Game.Application.Singletons;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Ruleta.Game.Controllers
{
    [Route("api/ruleta-game")]
    [ApiController]
    public class RuletaGameController : ControllerBase
    {
        private readonly IRuletaGameService _service;
        private readonly ILogger<RuletaGameController> _logger;

        public RuletaGameController(IRuletaGameService service, ILogger<RuletaGameController> logger)
        {
            _service = service;
            _logger = logger;

        }

        [HttpGet]
        [Route("numero-azar")]
        public async Task<IActionResult> GetNumeroAzar()
        {
            var numero = await _service.GetNumeroAzar();
            var resultado = new ResultadoRuletaDto
            {
                color = numero.color.Equals("red") ? Color.RED : Color.BLACK,
                numero = numero.numero,
                tipoNumero = numero.numero % 2 == 0 ? TipoNumero.PAR : TipoNumero.IMPAR
            };
            var premio = await _service.GetPremioResultado(resultado);

            var response = new { numero, premio };

            return Ok(response);
        }

        [HttpGet]
        [Route("usuario-data/{nombre}")]
        public async Task<IActionResult> GetUsuarioData(String nombre)
        {
            try
            {
                var usuario = await _service.GetUsuarioData(nombre);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST api/<RuletaGameController>
        [HttpPost]
        [Route("crear-usuario")]
        public async Task<IActionResult> PostCreateUpdate([FromBody] UsuarioDataDto usuarioData)
        {
            try
            {
                await _service.GrabarUsuarioData(usuarioData);
                return Ok(usuarioData);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("guardar-apuesta")]
        public async Task<IActionResult> GuardarUsuarioApuesta([FromBody] UsuarioApuestaDto apuesta)
        {
            try
            {
                UsuarioApuesta.Instance.tipoNumero = apuesta.tipoNumero;
                UsuarioApuesta.Instance.color = apuesta.color;
                UsuarioApuesta.Instance.numero = apuesta.numero;
                UsuarioApuesta.Instance.montoApuesta = apuesta.montoApuesta;
                UsuarioApuesta.Instance.apuestaAdicional = apuesta.apuestaAdicional;
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
