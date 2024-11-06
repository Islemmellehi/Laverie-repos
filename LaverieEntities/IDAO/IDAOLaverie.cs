using LaverieEntities.Entities;

namespace LaverieEntities.IDAO
{
    public interface IDAOLaverie
    {
        bool AjouterLaverie(int IdLaverie);
        List<Laveries> GetLaveries();
        bool AffecterLavierProp(int lavierID, int proprietaireId);


    }
}
