using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VietClinic.Models
{
    abstract class Pet
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }
    }
}
