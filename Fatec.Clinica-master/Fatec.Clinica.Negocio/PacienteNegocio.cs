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
    public class PacienteNegocio
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly PacienteRepositorio _pacienteRepositorio;

        /// <summary>
        /// 
        /// </summary>
        public PacienteNegocio()
        {
            _pacienteRepositorio = new PacienteRepositorio();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PacienteDto> Selecionar()
        {
            return _pacienteRepositorio.Selecionar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PacienteDto SelecionarPorId(int id)
        {
            var obj = _pacienteRepositorio.SelecionarPorId(id);

            if (obj == null)
                throw new NaoEncontradoException();

            return obj;
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Inserir(Paciente entity)
        {


            var cpfExistente = _pacienteRepositorio.SelecionarPorCpf(entity.Cpf);

            if (cpfExistente != null)
                throw new ConflitoException($"Já existe cadastrado o CPF {cpfExistente.Cpf}!");


            return _pacienteRepositorio.Inserir(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public PacienteDto Alterar(int id, Paciente entity)
        {

            var cpfExistente = _pacienteRepositorio.SelecionarPorCpf(entity.Cpf);

            if (cpfExistente != null)
            {
                if (cpfExistente.Id != id)
                    throw new ConflitoException($"Já existe cadastrado o CPF {cpfExistente.Cpf}, para outro médico!");
            }

            entity.Id = id;
            _pacienteRepositorio.Alterar(entity);

            return _pacienteRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            var obj = SelecionarPorId(id);

            _pacienteRepositorio.Deletar(obj.Id);
        }
    }
}
