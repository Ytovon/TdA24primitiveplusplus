using System.ComponentModel.DataAnnotations;

namespace tda_proj.Model
{
    public class ContactTelNumber
    {
        [Key]
        public int ID { get; set; }
        public string TelNumber { get; set; }

        public int ContactID { get; set; }
        public Contact Contact { get; set; }

        public ContactTelNumber()
        {

        }
    }
}
