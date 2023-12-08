using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tda_proj.Moodels
{
    public class Contact
    {
        public int Id { get; set; }
        public List<string> telNumbers { get; set; }
        public List<string> emails { get; set; }
        
        // issue with one-to-one relationship

        [ForeignKey("Lector")]
        public Guid? LectorUUID { get; set; }
        public Lector lector { get; set; }
    }
}
