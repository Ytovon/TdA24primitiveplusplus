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
        public List<LectorTag>? lectorTags { get; set; } = new List<LectorTag>();

        [Required]
        public string firstName { get; set; }
        public string? middleName { get; set; }
        
        [Required]
        public string lastName { get; set; }
        public List<TitleBefore>? titlesBefore { get; set; } = new List<TitleBefore>();
        public List<TitleAfter>? titlesAfter { get; set; } = new List<TitleAfter>();
        public string claims { get; set; }
        
        [Required]
        public string pictureUrl { get; set; }
        public string location { get; set; }       
        public string bio { get; set; }
       
        [Required]
        public double pricePerHour { get; set; }
    }
}
