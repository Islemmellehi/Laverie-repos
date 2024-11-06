using LaverieEntities.Entities;

namespace LaverieEntities.IDAO
{
    public interface IDAOCycle
    {
        bool AjouterCycle(int idCycle, string nomCycle, int dureeCycle, double coutC);
        List<Cycle> GetCycles();

    }
}
