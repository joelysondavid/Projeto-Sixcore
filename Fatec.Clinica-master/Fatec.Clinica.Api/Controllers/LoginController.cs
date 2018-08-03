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
    [Route("api/Login")]
    public class LoginController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private LoginNegocio _loginNegocio;

        /// <summary>
        /// 
        /// </summary>
        public LoginController()
        {
            _loginNegocio= new LoginNegocio();
        }

        /// <summary>
        /// Método que obtem uma lista de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(LoginDto), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult Get()
        {
            return Ok(_loginNegocio.Selecionar());
        }

        /// <summary>
        /// Método que seleciona um usuario..
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(LoginDto), nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public IActionResult GetId(int id)
        {
            return Ok(_loginNegocio.SelecionarPorId(id));
        }

     

        /// <summary>
        /// Método que insere um novo usuario..
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created, typeof(Login), nameof(HttpStatusCode.Created))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody]LoginInput input)
        {
            var objLogin = new Login()
            {
                Nome = input.Nome,
                Email = input.Email,
                Senha = input.Senha,
                Tipo_Acesso = input.Tipo_Acesso                
            };

            var idLogin = _loginNegocio.Inserir(objLogin);
            objLogin.Id = idLogin;
            return CreatedAtRoute(nameof(GetId), new { id = idLogin }, objLogin);
        }

        /// <summary>
        /// Método que altera um login
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.Accepted, typeof(Login), nameof(HttpStatusCode.Accepted))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody]LoginInput input)
        {
            var objLogin = new Login()
            {
                Tipo_Acesso = input.Tipo_Acesso,
                Senha = input.Senha,
                Email = input.Email,
                Nome = input.Nome
            };

            var obj = _loginNegocio.Alterar(id, objLogin);
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
            _loginNegocio.Deletar(id);
            return Ok();
        }
    }

}
