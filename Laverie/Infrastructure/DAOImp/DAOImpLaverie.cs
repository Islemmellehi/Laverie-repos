using Laverie.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;

namespace Laverie.Infrastructure.DAOImp
{
    public class DAOImpLaverie : IDAOLaverie
    {
        private readonly ApplicationDBContext _context;
        public DAOImpLaverie(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool AjouterLaverie(int IdLaverie)
        {
                try
                {
                    Laveries l = new Laveries();
                    l.IdLaverie = IdLaverie;
                    l.CapaciteLaverie = "Default Capacity";
                    l.AddresseLaverie = "default location";

                    _context.Laveries.Add(l);

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

        public List<Laveries> GetLaveries()
        {
            return _context.Laveries.ToList();
        }

        public bool AffecterLavierProp(int lavierId, int propId)
        {
            var laviers = _context.Laveries.Find(lavierId);
            var proprietaire = _context.Proprietaires.Find(propId);

            if (laviers == null || laviers == null)
            {
                return false;
            }

            laviers.ProprietaireCIN = proprietaire._CIN;
            _context.SaveChanges();

            return true;
        }
    }
}
