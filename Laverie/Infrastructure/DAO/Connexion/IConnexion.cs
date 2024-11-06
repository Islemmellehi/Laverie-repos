using System.Data;

namespace Laverie.Infrastructure.DAO.Connexion
{
    public interface IConnexion
    {
        IDbConnection GetConnection();
        void CloseConnection();
    }
}
