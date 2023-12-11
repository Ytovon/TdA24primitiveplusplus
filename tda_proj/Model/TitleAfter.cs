namespace tda_proj.Model
{
    public class TitleAfter
    {
        public int ID { get; set; }
        
        public string Title { get; set; }

        public Guid LectorUUID { get; set; }   
        public Lector lector { get; set; }
    }
}
