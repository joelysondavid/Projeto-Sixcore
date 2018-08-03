using System.Collections.Generic;
using Fatec.Clinica.Dado;
using Fatec.Clinica.Dominio;
using Fatec.Clinica.Dominio.Dto;
using Fatec.Clinica.Dominio.Excecoes;

namespace Fatec.Clinica.Negocio
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginNegocio
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly LoginRepositorio _loginRepositorio;

        /// <summary>
        /// 
        /// </summary>
        public LoginNegocio()
        {
            _loginRepositorio = new LoginRepositorio();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LoginDto> Selecionar()
        {
            return _loginRepositorio.Selecionar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LoginDto SelecionarPorId(int id)
        {
            var obj = _loginRepositorio.SelecionarPorId(id);

            if (obj == null)
                throw new NaoEncontradoException();

            return obj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Inserir(Login entity)
        {
            var emailExistente = _loginRepositorio.SelecionarPorEmail(entity.Email);

            if (emailExistente != null)
                throw new ConflitoException($"Já existe cadastrado o Email {emailExistente.Email}!");

            


            return _loginRepositorio.Inserir(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public LoginDto Alterar(int id, Login entity)
        {
            var emailExistente = _loginRepositorio.SelecionarPorEmail(entity.Email);

            if (emailExistente != null)
            {
                if (emailExistente.Id != id)
                    throw new ConflitoException($"Já existe cadastrado o Email {emailExistente.Email}, para outro usuario!");
            }

          

            entity.Id = id;
            _loginRepositorio.Alterar(entity);

            return _loginRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            var obj = SelecionarPorId(id);

            _loginRepositorio.Deletar(obj.Id);
        }
    }
}
