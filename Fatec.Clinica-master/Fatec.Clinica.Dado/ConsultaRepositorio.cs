using Fatec.Clinica.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Fatec.Clinica.Dado.Configuracao;
using Fatec.Clinica.Dominio.Dto;

namespace Fatec.Clinica.Dado
{
    public class ConsultaRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsultaDto> Selecionar()
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var lista = connection.Query<ConsultaDto>($"SELECT C.Id, C.Data, C.Hora, P.Nome As Paciente, " +
                                                          $"M.Nome As Medico, E.Nome As Especialidade "+
                                                          $"FROM[Consulta] C " +
                                                          $"INNER JOIN[Paciente] P ON C.IdPaciente = P.Id "+
                                                          $"INNER JOIN[Medico] M ON C.IdMedico = M.Id "+
                                                          $"INNER JOIN[Especialidade] E ON C.TipoEspecialista = E.Id");
                return lista;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Consulta SelecionarPorId(int id)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.QueryFirstOrDefault<Consulta>($"SELECT * " +
                                                                  $"FROM [Consulta] " +
                                                                  $"WHERE Id = {id}");
                return obj;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMedico"></param>
        /// <returns></returns>
        public Consulta SelecionarPorIdMedico(int idMedico)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.QueryFirstOrDefault<Consulta>($"SELECT * " +
                                                                  $"FROM [Consulta] " +
                                                                  $"WHERE IdMedico = {idMedico}");
                return obj;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        public Consulta SelecionarPorIdPaciente(int idPaciente)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.QueryFirstOrDefault<Consulta>($"SELECT * " +
                                                                  $"FROM [Consulta] " +
                                                                  $"WHERE IdMedico = {idPaciente}");
                return obj;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Inserir(Consulta entity)
        {
            

            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                return connection.QuerySingle<int>($"DECLARE @ID int;" +
                                              $"INSERT INTO [Consulta] " +
                                              $"(Data, Hora, IdPaciente, IdMedico, TipoEspecialista) " +
                                              $"VALUES ('{entity.Data.Date}'," +
                                              $"'{entity.Hora}'," +
                                              $"{entity.IdPaciente}," +
                                              $"{entity.IdMedico}," +
                                              $"{entity.TipoEspecialista})"+ 
                                              $"SET @ID = SCOPE_IDENTITY();" +
                                              $"SELECT @ID");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Alterar(Consulta entity)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                connection.Execute($"UPDATE [Consulta] " +
                                   $"SET  IdMedico = '{entity.IdMedico}' " +
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
                                   $"FROM [Consulta] " +
                                   $"WHERE Id = {id}");
            }
        }
    }
}
