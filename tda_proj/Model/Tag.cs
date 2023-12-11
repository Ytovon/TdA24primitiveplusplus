using System.ComponentModel.DataAnnotations;

namespace tda_proj.Model
{
    public class Tag
    {
        [Key]
        public Guid TagUUID { get; set; }
        public string TagName { get; set; }

        public List<LectorTag> Tags { get; set; } = new List<LectorTag>();

        public Tag() { }
    }
}
