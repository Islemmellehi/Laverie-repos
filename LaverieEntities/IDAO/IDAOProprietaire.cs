using LaverieEntities.Entities;

namespace LaverieEntities.IDAO
{
    public interface IDAOProprietaire
    {
        bool AjouterProp(int CIN, string Surnom);
        List<Proprietaire> GetProprietaires();

    }
}
