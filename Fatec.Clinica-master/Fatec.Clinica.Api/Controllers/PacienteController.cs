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
    [Route("api/Paciente")]
    public class PacienteController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private PacienteNegocio _pacienteNegocio;

        /// <summary>
        /// 
        /// </summary>
        public PacienteController()
        {
            _pacienteNegocio = new PacienteNegocio();
        }

        /// <summary>
        /// Método que obtem uma lista de pacientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(PacienteDto), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult Get()
        {
            return Ok(_pacienteNegocio.Selecionar());
        }

        /// <summary>
        /// Método que seleciona um paciente..
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(PacienteDto), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult GetId(int id)
        {
            return Ok(_pacienteNegocio.SelecionarPorId(id));
        }

        /// <summary>
        /// Método que insere um paciente..
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created, typeof(Paciente), nameof(HttpStatusCode.Created))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] PacienteInput input)
        {
            var objPaciente = new Paciente()
            {
                Cpf = input.Cpf,
                Nome = input.Nome,
                Historico = input.Historico,
                Nascimento = input.Nascimento
            };

            var idPaciente = _pacienteNegocio.Inserir(objPaciente);
            objPaciente.Id = idPaciente;
            return CreatedAtRoute(nameof(GetId), new { id = idPaciente }, objPaciente);
        }

        /// <summary>
        /// Método que altera um paciente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.Accepted, typeof(Paciente), nameof(HttpStatusCode.Accepted))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody]PacienteInput input)
        {
            var objPaciente = new Paciente()
            {
                Cpf = input.Cpf,
                Nome = input.Nome,
                Historico = input.Historico,
                Nascimento = input.Nascimento
            };

            var obj = _pacienteNegocio.Alterar(id, objPaciente);
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
            _pacienteNegocio.Deletar(id);
            return Ok();
        }
    }
}