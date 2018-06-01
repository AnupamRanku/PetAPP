using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp.Common
{
    public class Person
    {
        public String Name { get; set; }
        public String Gender { get; set; }
        public Int32 Age { get; set; }

        public Pet[] Pets;
    }
}
