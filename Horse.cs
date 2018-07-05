using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPractices
{
    class Horse
    {
        public String sound { get; set; }
        public String name { get; set; }
        public Owner owner { get; set; }

        public Horse(String name, String sound, Owner owner) {
            this.name = name;
            this.sound = sound;
            this.owner = owner; 
        }
    }
}
