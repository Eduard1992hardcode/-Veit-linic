using System.Collections.Generic;

namespace VietClinic.Models
{
    public class Owner: DictionaryBase
    {
        public string Adress { get; set; }
        public string TelNumber { get; set; }

        public List<Pet> Pets{ get; set; }
    }
}
