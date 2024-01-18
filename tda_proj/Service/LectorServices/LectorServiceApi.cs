using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using tda_proj.Data;


namespace tda_proj.Service.LectorServiceApi
{
    public class LectorServiceApi : ILectorServiceApi
    {
        private static List<Lector> lectorsapi = new List<Lector>
        {
        };
        private readonly tdaContext _context;

        public LectorServiceApi(tdaContext context)
        {
            _context = context;
        }

        //Vyporadat se s nullability


        public async Task<List<Lector>> GetAllLectorsapi()
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


        public async Task<List<Lector>> AddLectorapi(Lector lector)
        {
            _context.Lectors.Add(lector);
            await _context.SaveChangesAsync();
            return lectorsapi;
        }

        public async Task<Lector> UpdateLectorByUUIDapi(Guid UUID, Lector request)
        {
            var lector = await _context.Lectors.FindAsync(UUID);
            if (lector is null)
                return null;


            //Předělat podle původní metody v LectorServicu
            //lector.titlesBefore = request.titlesBefore;
            lector.firstName = request.firstName;
            lector.middleName = request.middleName;
            lector.lastName = request.lastName;
            //lector.titlesAfter = request.titlesAfter;
            lector.pictureUrl = request.pictureUrl;
            lector.location = request.location;
            //lector.claims = request.claims;
            lector.bio = request.bio;
            //lector.lectorTags = request.lectorTags;
            lector.pricePerHour = request.pricePerHour;
            lector.Contact = request.Contact;
            //lector.Contact (email)
            //lector.Contact (Telnumber)

            await _context.SaveChangesAsync();

            return lector;

        }

        //metody add, delete a update metody styl zápisu: await _context.Lectors.ToListAsync;?
        public async Task<Lector> DeleteLectorByUUIDapi(Guid UUID, Lector request)
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