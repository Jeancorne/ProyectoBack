using DC_Modelo_Arana_Core.CustomEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProyectoBack.Application.DTOs.v1;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.DTOs.v1.PUT;
using ProyectoBack.Application.Helpers;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProyectoBack.Controllers.v1
{
    [Produces("application/json")]
    [Route("api/v1/servicio")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicio _services;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public ServicioController(IServicio a, IConfiguration e, IUnitOfWork t)
        {
            _unitOfWork = t;
            _configuration = e;
            _services = a;
        }
        ///<summary>
        ///Endpoint eliminar aspirante
        ///</summary>

        [HttpGet("eliminar_aspirantes/{id}")]
        [Authorize(Policy = "eliminarServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> eliminarAspirante(int id)
        {
            try
            {
                var data = await _services.eliminarAspirante(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint obtener la lista de aspirante
        ///</summary>

        [HttpGet("obtener_aspirantes")]
        [Authorize(Policy = "obtenerServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> actualizarAspirante()
        {
            try
            { 
                var data = await _services.obtenerAspirantes();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint actualizar aspirante
        ///</summary>

        [HttpPut("actualizar_aspirante")]
        [Authorize(Policy = "actualizarServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> actualizarAspirante([FromBody] clsAspirantePUT aspirante)
        {
            try
            {
                if (aspirante.id == 0) throw new Exception("El ID es obligatorio y diferente de 0"); 
                var data = await _services.actualizarAspirante(aspirante);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint crear aspirante
        ///</summary>

        [HttpPost("crear_aspirante")]
        [Authorize(Policy = "crearServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> crearAspirante([FromBody] clsAspiranteDTO aspirante)
        {
            try
            {
                var data = await _services.crearAspirante(aspirante);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        ///<summary>
        ///Endpoint crear usuario de sistema
        ///</summary>

        [HttpPost("crear_usuario")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> crearUsuario([FromBody] LoginModelDTO login)
        {
            try
            {
                var data = await _services.crearUsuario(login);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint Login al sistema
        ///</summary>

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> obtenerEmpleados([FromBody] LoginModelDTO login)
        {
            try
            {
                var data = await _services.obtenerUsuario(login.usuario, login.password);
                if (data != null)
                {
                    string secret = _configuration.GetValue<string>("KeySecret");
                    var jwtHelper = new JWT(secret);
                    List<string> listaToken = new List<string>() { "crearServicio", "obtenerServicio", "actualizarServicio", "eliminarServicio" };

                    var token = jwtHelper.crearToken(data.usuario, listaToken);
                    return Ok(new
                    {
                        ok = true,
                        mensaje = "logeado",
                        token = token
                    });
                }
                else
                {
                    return BadRequest("Usuario o contraseña incorrecta");
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

    }
}
