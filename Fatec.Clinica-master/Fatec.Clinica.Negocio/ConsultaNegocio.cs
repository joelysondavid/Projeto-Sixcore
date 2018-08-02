using System.Collections.Generic;
using Fatec.Clinica.Dado;
using Fatec.Clinica.Dominio;
using Fatec.Clinica.Dominio.Excecoes;
using Fatec.Clinica.Dominio.Dto;

namespace Fatec.Clinica.Negocio
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsultaNegocio
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ConsultaRepositorio _consultaRepositorio;

        /// <summary>
        /// 
        /// </summary>
        public ConsultaNegocio()
        {
            _consultaRepositorio = new ConsultaRepositorio();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsultaDto> Selecionar()
        {
            return _consultaRepositorio.Selecionar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Consulta SelecionarPorId(int id)
        {
            var obj = _consultaRepositorio.SelecionarPorId(id);

            if (obj == null)
                throw new NaoEncontradoException();

            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Inserir(Consulta entity)
        {
            return _consultaRepositorio.Inserir(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Consulta Alterar(int id, Consulta entity)
        {
            entity.Id = id;
            _consultaRepositorio.Alterar(entity);

            return _consultaRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            var obj = SelecionarPorId(id);

            _consultaRepositorio.Deletar(obj.Id);
        }
    }
}
