using System.Net;
using Fatec.Clinica.Api.Model;
using Fatec.Clinica.Dominio;
using Fatec.Clinica.Dominio.Dto;
using Fatec.Clinica.Negocio;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Fatec.Clinica.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Consulta")]
    public class ConsultaController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private ConsultaNegocio _consultaNegocio;

        /// <summary>
        /// 
        /// </summary>
        public ConsultaController()
        {
            _consultaNegocio = new ConsultaNegocio();
        }

        /// <summary>
        /// Método que obtem uma lista de Consultas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(ConsultaDto), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult Get()
        {
            return Ok(_consultaNegocio.Selecionar());
        }

        /// <summary>
        /// Método que seleciona uma consulta..
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(ConsultaDto), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult GetId(int id)
        {
            return Ok(_consultaNegocio.SelecionarPorId(id));
        }

        /// <summary>
        /// Método que seleciona uma consulta por medico..
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Medico/{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(ConsultaDto), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult GetEspecialidadeId(int id)
        {
            return Ok(_consultaNegocio.SelecionarPorId(id));
        }

        /// <summary>
        /// Método que insere uma consulta..
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created, typeof(Consulta), nameof(HttpStatusCode.Created))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody]ConsultaInput input)
        {
            var objConsulta = new Consulta()
            {
                IdPaciente = input.idPaciente,
                IdMedico = input.idMedico,
                IdEspecialidade = input.idEspecialidade
            };

            var idConsulta = _consultaNegocio.Inserir(objConsulta);
            objConsulta.Id = idConsulta;
            return CreatedAtRoute(nameof(GetId), new { id = idConsulta}, objConsulta);
        }

        /// <summary>
        /// Método que altera uma consulta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.Accepted, typeof(Consulta), nameof(HttpStatusCode.Accepted))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody]ConsultaInput input)
        {
            var objConsulta = new Consulta()
            {
                IdMedico = input.idMedico,
                IdEspecialidade = input.idEspecialidade
            };

            var obj = _consultaNegocio.Alterar(id, objConsulta);
            return Accepted(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult Delete([FromRoute]int id)
        {
            _consultaNegocio.Deletar(id);
            return Ok();
        }
    }
}