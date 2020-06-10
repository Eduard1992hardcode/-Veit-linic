namespace VietClinic.Models
{
    public class Pet : DictionaryBase
    {
        public int Age { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }

        public long OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
