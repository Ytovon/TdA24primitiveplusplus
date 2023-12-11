using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace tda_proj.Model
{
    public class Lector
    {
        [Key]
        public Guid UUID { get; set; }
        public Contact Contact { get; set; }
        public List<LectorTag> lectorTags { get; set; } = new List<LectorTag>();

        public string firstName { get; set; }
        public string? middleName { get; set; }
        public string lastName { get; set; }
        public string? titleBefore { get; set; }
        public string? titleAfter { get; set; }
        public string pictureUrl { get; set; }
        public string location { get; set; }       
        public string bio { get; set; }
        public double pricePerHour { get; set; }
        public List<Claims> claims { get; set; } = new List<Claims>();

        public Lector()
        {

        }
    }
}
