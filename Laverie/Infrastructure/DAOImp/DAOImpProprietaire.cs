using Laverie.Infrastructure.Data;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laverie.Infrastructure.DAOImp
{
    public class DAOImpProprietaire:IDAOProprietaire
    {
        private readonly ApplicationDBContext _context;

        public DAOImpProprietaire(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool AjouterProp(int CIN, string Surnom)
        {
            try
            {
                Proprietaire p = new Proprietaire();
                p._CIN = CIN;
                p._Surname = Surnom;

                _context.Proprietaires.Add(p);

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

        public List<Proprietaire> GetProprietaires()
        {
            return _context.Proprietaires.ToList();
        }



    }
}
