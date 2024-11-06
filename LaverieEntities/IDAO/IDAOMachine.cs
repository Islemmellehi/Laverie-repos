
using LaverieEntities.Entities;

namespace LaverieEntities.IDAO
{
    public interface IDAOMachine
    {
        bool AjouterMachine(int IdMachine, string marque, string etat);
        List<Machine> GetMachines();

        bool AffecterMachineLav(int idMachine, int lavierID);

    }
}
