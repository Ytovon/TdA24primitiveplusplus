namespace tda_proj.Moodels
{
    public class Tag
    {
        public Guid Guid1 { get; }
        public string tagName { get; set; }

        public Tag()
        {
            Guid1 = Guid.NewGuid();
        }
        public List<LectorTag> Tags { get; set; }
    }
}
