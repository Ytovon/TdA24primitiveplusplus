using Microsoft.EntityFrameworkCore;
using tda_proj.Data;
using tda_proj.Model;


namespace tda_proj.Service
{
    public class ContactService
    {
        public List<Contact> GetAllContactsWithDetails()
        {
            using (tdaContext context = new tdaContext())
            {
                return context.Contacts
                    .Include(c => c.Emails)
                    .Include(c => c.TelNumbers)
                    .ToList();
            }
        }
    }
}
