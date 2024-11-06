using Laverie.Infrastructure.Data;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laverie.Infrastructure.DAOImp
{
    public class DAOImpMachine : IDAOMachine
    {
        private readonly ApplicationDBContext _context;
        public DAOImpMachine(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool AjouterMachine(int IdMachine, string marque, string etat)
        {
            try
            {
                Machine m = new Machine();
                m.IdMachine = IdMachine;
                m.MarqueMachine = marque;
                m.EtatMachine = etat;

                _context.Machines.Add(m);

                _context.SaveChanges();

                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database update exception during add operation: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during add operation: {ex.Message}");
                return false;
            }
        }

        public List<Machine> GetMachines()
        {
            return _context.Machines.ToList();
        }

        public bool AffecterMachineLav(int machineId, int lavierId)
        {
            var machines = _context.Machines.Find(machineId);

            var laviers = _context.Laveries.Find(lavierId);

            if (machines == null || laviers == null)
            {
                return false;
            }

            machines.IDLaverie = laviers.IdLaverie;

            _context.SaveChanges();

            return true;
        }
    }
}
