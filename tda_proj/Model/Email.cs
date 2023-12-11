using System.ComponentModel.DataAnnotations;
using tda_proj.Model;

namespace tda_proj.Model
{
    public class ContactEmail
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }

        public int ContactID { get; set; }
        public Contact Contact { get; set; }

        public ContactEmail()
        {

        }
    }
}
