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
                    .Include(l => l.lectorTags)
                        .ThenInclude(lt => lt.Tag)
                    .ToList();
            }
        }
    }
}
