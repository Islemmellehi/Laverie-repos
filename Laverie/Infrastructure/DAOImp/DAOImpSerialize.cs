using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Laverie.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Laverie.Infrastructure.DAOImp
{
    public class DAOImpSerialize : IDAOSerialize
    {
        private readonly ApplicationDBContext _context;

        public DAOImpSerialize(ApplicationDBContext context)
        {
            _context = context;
        }

        public LaverieData GetAllData()
        {
            var proprietaires = _context.Proprietaires
                .Include(p => p.propLaverie)
                .ThenInclude(l => l.machinesLaverie)
                .ThenInclude(m => m.cyclesMachine)
                .ToList();

            var laveries = _context.Laveries
                .Include(l => l.machinesLaverie)
                .ThenInclude(m => m.cyclesMachine)
                .ToList();

            var machines = _context.Machines
                .Include(m => m.cyclesMachine)
                .ToList();

            var cycles = _context.Cycles.ToList();

            return new LaverieData
            {
                Proprietaires = proprietaires,
                Laveries = laveries,
                Machines = machines,
                Cycles = cycles
            };
        }
    }
}
