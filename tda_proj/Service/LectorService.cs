using Microsoft.EntityFrameworkCore;
using tda_proj.Data;
using tda_proj.Model;

namespace tda_proj.Service
{
    public class LectorService
    {
        public List<Lector> GetAllLectorsWithDetails()
        {
            using (tdaContext context = new tdaContext())
            {
                return context.Lectors
                    .Include(c => c.titlesAfter)
                    .Include(c => c.titlesBefore)
                    .Include(c => c.claims)
                    .Include(l => l.lectorTags)                    
                        .ThenInclude(lt => lt.Tag)
                    .ToList();
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
