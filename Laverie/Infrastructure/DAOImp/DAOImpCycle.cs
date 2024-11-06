using Laverie.Infrastructure.Data;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Microsoft.EntityFrameworkCore;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;


namespace Laverie.Infrastructure.DAOImp
{
    public class DAOImpCycle : IDAOCycle
    {
        private readonly ApplicationDBContext _context;
        public DAOImpCycle(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool AjouterCycle(int idCycle, string nomCycle, int dureeCycle, double coutC)
        {
            try
            {
                Cycle c = new Cycle();
                c.IdCycle = idCycle;
                c.NomCycle = nomCycle;
                c.DureeCycleHR = dureeCycle;
                c.coutCycle = coutC;

                _context.Cycles.Add(c);

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
        public List<Cycle> GetCycles()
        {
            return _context.Cycles.ToList();
        }

    }
}
