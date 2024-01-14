using Microsoft.EntityFrameworkCore;
using System.Linq;
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
                    .Include(l => l.lectorTags)
                        .ThenInclude(lt => lt.Tag)
                    .ToListAsync();
            }
        }

        public async Task<List<Lector>> GetSpecificLectorsAsync(double minPrice, double maxPrice, List<string> Locations, List<string> chosenTags)
        {
            using (tdaContext context = new tdaContext())
            {
                List<Lector> LlocationsList = new List<Lector>();
                List<Lector> LtagList = new List<Lector>();

                // fill of lists if arent empty
                if (Locations != null && Locations.Any())
                {
                    LlocationsList = context.Lectors
                        .Where(p => Locations.Contains(p.location))
                        .ToList();
                }
                if (chosenTags != null && chosenTags.Any())
                {
                    LtagList = context.Lectors
                       .Where(l => l.lectorTags.Any(t => chosenTags.Any(tag => t.Tag.TagName == tag)))
                       .ToList();
                }


                // returning list of lectors based on where
                return await context.Lectors
                    .Include(l => l.lectorTags)
                    .ThenInclude(lt => lt.Tag)
                    .Where(x => LlocationsList.Count == 0 || LlocationsList.Select(l => l.location).Contains(x.location))
                    .Where(y => LtagList.Select(l => l.location).Contains(y.location))
                    .Where(p => p.pricePerHour >= minPrice && p.pricePerHour <= maxPrice)
                    .Select(x => new Lector
                    {
                        UUID = x.UUID,
                        pictureUrl = x.pictureUrl,
                        location = x.location,
                        pricePerHour = x.pricePerHour,
                        lectorTags = x.lectorTags,
                        titlesBefore = x.titlesBefore,
                        firstName = x.firstName,
                        middleName = x.middleName,
                        lastName = x.lastName,
                        titlesAfter = x.titlesAfter,
                    })
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
                         bio = x.bio,
                         lectorTags = x.lectorTags,



                     }).FirstOrDefault(l => l.UUID == UUID);
            }
        }
    }
}
