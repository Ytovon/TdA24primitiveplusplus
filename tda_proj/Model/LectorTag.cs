using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tda_proj.Model
{
    public class LectorTag
    {
        public Guid LectorUUID { get; set; }
        public Lector Lector { get; set; }

        public Guid LectorTagUUID { get; set; }
        public Tag Tag { get; set; }
    }
}
