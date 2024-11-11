using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Laverie.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

            var laverieData = new LaverieData
            {
                Proprietaires = proprietaires,
                Laveries = laveries,
                Machines = machines,
                Cycles = cycles
            };
            string json = JsonSerializer.Serialize(laverieData, new JsonSerializerOptions { WriteIndented = true });

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "LaverieData.json");

            File.WriteAllText(filePath, json);

            return laverieData;

        }
    }
}
