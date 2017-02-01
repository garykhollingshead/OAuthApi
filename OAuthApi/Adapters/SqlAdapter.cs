using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using OAuthApi.Models;

namespace OAuthApi.Controllers
{
    public class SqlAdapter
    {
        private static string ConnectionString;

        public SqlAdapter()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Auth"].ConnectionString;
        }

        private IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<SignInCredentials> GetClientCredentailsAsync(SignInRequest signInRequest)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ClientName", dbType: DbType.String, value: signInRequest.ClientId);

                var credentials = await connection.QueryAsync<SignInCredentials>(
                    "dbo.GetClientCredential", parameters, commandType: CommandType.StoredProcedure);
                return credentials.FirstOrDefault();
            }
        }
    }
}