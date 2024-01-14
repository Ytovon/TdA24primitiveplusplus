using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using tda_proj.Data;


namespace tda_proj.Service.LectorService
{
    public class LectorService : ILectorService
    {
        private static List<Lector> lectorsapi = new List<Lector>
        {
        };
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

        private readonly tdaContext _context;

        public LectorService(tdaContext context)
        {
            _context = context;
        }

        //Vyporadat se s nullability

        public async Task<List<Lector>> GetAllLectors()
        {
            var lectors = await _context.Lectors.ToListAsync();
            return lectors;
        }
        

        public async Task<Lector> GetLectorByUUIDapi(Guid UUID)
        {
            var lector = await _context.Lectors.FindAsync(UUID);
            if (lector is null)
                return null;

            return lector;
        }

        public async Task<List<Lector>> AddLector(Lector lector)
        {
            _context.Lectors.Add(lector);
            await _context.SaveChangesAsync();
            return lectorsapi;
        }

        public async Task<Lector> UpdateLectorByUUID(Guid UUID, Lector request)
        {
            var lector = await _context.Lectors.FindAsync(UUID);
            if (lector is null)
                return null;


            //Předělat podle původní metody v LectorServicu
            lector.titlesBefore = request.titlesBefore;
            lector.firstName = request.firstName;
            lector.middleName = request.middleName;
            lector.lastName = request.lastName;
            lector.titlesAfter = request.titlesAfter;
            lector.pictureUrl = request.pictureUrl;
            lector.location = request.location;
            lector.claims = request.claims;
            lector.bio = request.bio;
            lector.lectorTags = request.lectorTags;
            lector.pricePerHour = request.pricePerHour;
            lector.Contact = request.Contact;
            //lector.Contact (email)
            //lector.Contact (Telnumber)

            await _context.SaveChangesAsync();

            return lector;


        }
        //metody add, delete a update metody styl zápisu: await _context.Lectors.ToListAsync;?
        public async Task<Lector> DeleteLectorByUUID(Guid UUID, Lector request)
        {
            var lector = await _context.Lectors.FindAsync(UUID);    
            if (lector is null)
                return null;

            _context.Lectors.Remove(lector);
            await _context.SaveChangesAsync();
            return lector;
            
        }
    }
}