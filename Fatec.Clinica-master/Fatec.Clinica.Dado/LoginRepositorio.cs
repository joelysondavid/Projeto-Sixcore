using Fatec.Clinica.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Fatec.Clinica.Dado.Configuracao;
using Fatec.Clinica.Dominio.Dto;

namespace Fatec.Clinica.Dado
{
    public class LoginRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LoginDto> Selecionar()
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var lista = connection.Query<LoginDto>($"SELECT L.ID, L.NOME, L.EMAIL, L.SENHA,L.TIPO_ACESSO" +
                                                        $"FROM [LOGIN_TB] L ");
                return lista;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LoginDto SelecionarPorId(int id)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.QueryFirstOrDefault<LoginDto>($"SELECT L.ID, L.NOME, L.EMAIL, L.SENHA,L.TIPO_ACESSO" +
                                                                 $"FROM [LOGIN_TB] L " +
                                                                 $"WHERE L.ID = {id}");
                return obj;
            }
        }

        /// <summary>
        /// 
        /// </summary>
       
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Login SelecionarPorEmail(string email)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.QueryFirstOrDefault<Login>($"SELECT * " +
                                                                  $"FROM [LOGIN_TB] " +
                                                                  $"WHERE EMAIL = {email}");
                return obj;
            }
        }

      

        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <summary>
        /// 
        /// <param name="entity"></param>
        /// <returns></returns>
        /// </summary>
        public int Inserir(Login entity)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                return connection.QuerySingle<int>($"DECLARE @ID int;" +
                                              $"INSERT INTO [LOGIN_TB] " +
                                              $"(NOME,EMAIL,TIPO_ACESSO) " +
                                                    $"VALUES ({entity.Nome}," +
                                                            $"'{entity.Email}'," +
                                                            $"'{entity.Senha}',"+
                                                            $"'{entity.TipoAcesso}'" +
                                              $"SET @ID = SCOPE_IDENTITY();" +
                                              $"SELECT @ID");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <summary>
        /// 
        /// <param name="entity"></param>
        ///    /// </summary>
        public void Alterar(Login entity)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                connection.Execute($"UPDATE [LOGIN_TB] " +
                                   $"SET Nome = '{entity.Nome}', "  +
                                   $"EMAIL = '{entity.Email}'," +
                                   $"SENHA = '{entity.Senha}', " +
                                   $"TIPO_ACESSO = '{entity.TipoAcesso}'"+
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
                                   $"FROM [LOGIN_TB] " +
                                   $"WHERE ID = {id}");
            }
        }
    }
}