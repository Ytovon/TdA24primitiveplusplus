using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tda_proj.Model
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public Guid LectorUUID { get; set; }
        public Lector Lector { get; set; }

        public List<ContactTelNumber> TelNumbers { get; set; } = new List<ContactTelNumber>();
        public List<ContactEmail> Emails { get; set; } = new List<ContactEmail>();   
        

        public Contact()
        {

        }
    }
}
