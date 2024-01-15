using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using tda_proj.Data;


namespace tda_proj.Service.LectorService
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

        public async Task<List<Lector>> GetSpecificLectorsAsync(double minPrice, double maxPrice, List<string> Locations, List<string> Tagy)
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
                     .Include(l => l.lectorTags)
                     .ThenInclude(lt => lt.Tag)
                     .Select(x => new Lector
                     {

                         UUID = UUID,
                         pictureUrl = x.pictureUrl,
                         Contact = new Contact
                         {
                             Emails = x.Contact.Emails,
                             TelNumbers = x.Contact.TelNumbers,
                             ID = x.Contact.ID,
                         },
                         titlesBefore = x.titlesBefore,
                         firstName = x.firstName,
                         middleName = x.middleName,
                         lastName = x.lastName,
                         titlesAfter = x.titlesAfter,
                         location = x.location,
                         pricePerHour = x.pricePerHour,
                         claims = x.claims,
                         bio = x.bio,
                         lectorTags = x.lectorTags,



                     }).FirstOrDefault(l => l.UUID == UUID);

            }
        }

 
    }
}