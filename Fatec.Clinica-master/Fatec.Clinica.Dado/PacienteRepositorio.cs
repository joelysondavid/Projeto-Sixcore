using Fatec.Clinica.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Fatec.Clinica.Dado.Configuracao;
using Fatec.Clinica.Dominio.Dto;

namespace Fatec.Clinica.Dado
{
    /// <summary>
    /// 
    /// </summary>
    public class PacienteRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PacienteDto> Selecionar()
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var lista = connection.Query<PacienteDto>($"SELECT Id, Nome, Cpf, Historico, Nascimento " +
                                                          $"FROM [Paciente]");
                return lista;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public Paciente SelecionarPorCpf(string cpf)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.QueryFirstOrDefault<Paciente>($"SELECT * " +
                                                                 $"FROM [Paciente] " +
                                                                 $"WHERE Cpf = '{cpf}'");
                return obj;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PacienteDto SelecionarPorId(int id)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.QueryFirstOrDefault<PacienteDto>($"SELECT P.Id,  P.Nome, P.Cpf, P.Historico, P.Nascimento " +
                                                                      $"FROM [Paciente] P " +
                                                                      $"WHERE P.Id = {id}");
                return obj;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Inserir(Paciente entity)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                return connection.QuerySingle<int>($"DECLARE @ID int;" +
                                              $"INSERT INTO [Paciente] " +
                                              $"(Nome, Cpf, Historico, Nascimento) " +
                                                    $"VALUES ('{entity.Nome}'," +
                                                            $"'{entity.Cpf}'," +
                                                            $"'{entity.Historico}'," +
                                                            $"'{entity.Nascimento}')" +
                                              $"SET @ID = SCOPE_IDENTITY();" +
                                              $"SELECT @ID");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Alterar(Paciente entity)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                connection.Execute($"UPDATE [Paciente] " +
                                   $"SET Nome = '{entity.Nome}'," +
                                   $"CPF = '{entity.Cpf}'," +
                                   $"Historico = '{entity.Historico}'," +
                                   $"Nascimento = '{entity.Nascimento}' " +
                                   $"WHERE Id = {entity.Id}");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                connection.Execute($"DELETE " +
                                   $"FROM [Paciente] " +
                                   $"WHERE Id = {id}");
            }
        }
    }
}
