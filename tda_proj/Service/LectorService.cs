using tda_proj.Data;
using tda_proj.Model;

namespace tda_proj.Service
{
    public class LectorService
    {
        public List<Lector> GetAllLectors()
        {
            using (tdaContext context = new tdaContext())
            {
                return context.Lectors.ToList();
            }
        }
    }
}
