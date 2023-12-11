using tda_proj.Model;

namespace tda_proj.Model
{
    public class Claims
    {
        public int ID { get; set; }
        public string Name {  get; set; }

        public Guid LectorUUID { get; set; }
        public Lector Lector {  get; set; }

        public Claims() { 
        
        }
    }
}
