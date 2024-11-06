using Npgsql;
using System.Data;

namespace Laverie.Infrastructure.DAO.Connexion
{
    public class ConnexionPostgres:IConnexion
    {
 

            private readonly string _connectionString;
            public IDbConnection _connection;


            public ConnexionPostgres(string connectionString)
            {
                _connectionString = connectionString;
            }
            public IDbConnection GetConnection()
            {
                if (_connection == null)
                {
                    _connection = new NpgsqlConnection(_connectionString);
                    _connection.Open();
                }
                return _connection;
            }

            public void CloseConnection()
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                }
            }
        }
    }

