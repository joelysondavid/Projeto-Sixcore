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
                var lista = connection.Query<LoginDto>($"SELECT L.Id, M.Nome, L.Email, L.TipoAcesso" +
                                                        $"FROM [LOGIN_TB] M ");
                return lista;
            }
        }

        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Inserir(Login entity)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                return connection.QuerySingle<int>($"DECLARE @ID int;" +
                                              $"INSERT INTO [LOGIN_TB] " +
                                              $"(NOME,EMAIL,TIPO_ACESSO) " +
                                                    $"VALUES ({entity.Nome}," +
                                                            $"'{entity.Email}'," +
                                                            $"'{entity.TipoAcesso}'" +
                                              $"SET @ID = SCOPE_IDENTITY();" +
                                              $"SELECT @ID");
            }
        }

        /// <summary>
        /// 
    }
}
}