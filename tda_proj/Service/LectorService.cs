using Microsoft.EntityFrameworkCore;
using tda_proj.Data;
using tda_proj.Model;

namespace tda_proj.Service
{
    public class LectorService
    {
        public async Task<List<Lector>> GetAllLectorsAsync()
        {
            using (tdaContext context = new tdaContext())
            {
                return await context.Lectors
                    .Include(c => c.titlesAfter)
                    .Include(c => c.titlesBefore)
                    .Include(c => c.claims)
                    .Include(l => l.lectorTags)
                        .ThenInclude(lt => lt.Tag)
                    .ToListAsync();
            }
        }

        public async Task<List<Lector>> GetSpecificLectorsAsync(double minPrice, double maxPrice, List<string> Locations)
        {
            using (tdaContext context = new tdaContext())
            {
                return await context.Lectors
                    .Include(c => c.titlesAfter)
                    .Include(c => c.titlesBefore)
                    .Include(c => c.claims)
                    .Include(l => l.lectorTags)
                        .ThenInclude(lt => lt.Tag)
                    .Where(p => p.pricePerHour >= minPrice && p.pricePerHour <= maxPrice &&
                        Locations.Contains(p.location))
                    .ToListAsync();
            }
        }


        public Lector GetLectorByUUID(Guid UUID)
        {
            using (tdaContext context = new tdaContext())
            {
                return context.Lectors
                     .Include(c => c.Contact)
                        .ThenInclude(c => c.TelNumbers)
                     .Include(c => c.Contact)
                        .ThenInclude(c => c.Emails)
                     .Include(c => c.claims)
                     .Include(c => c.titlesAfter)
                     .Include(c => c.titlesBefore)
                     .Include(l => l.lectorTags)
                        .ThenInclude(lt => lt.Tag)
                        .FirstOrDefault(l => l.UUID == UUID);
            }               
        }


    }
}
