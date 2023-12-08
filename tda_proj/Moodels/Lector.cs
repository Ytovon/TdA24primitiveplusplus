using Microsoft.EntityFrameworkCore;

namespace tda_proj.Moodels
{
    public class Lector
    {
        public Guid UUID { get; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string titleBefore {  get; set; }
        public string titleAfter {  get; set; }
        public string pictureUrl {  get; }
        public string location {  get; set; }
        public List<string> claim {  get; set; }
        public string bio {  get; set; }
        public double pricePerHour { get; set; }
        public List<LectorTag> lectorTags { get; set; }
        public Contact contact { get; set; }

        public Lector()
        {
            UUID = Guid.NewGuid();
        }

    }
}
