using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Referee : Person
    {
        public Referee(string name, int age) 
            : base(name, age)
        {
        }
        public override string ToString()
        {
            return $"Referee - Name: {Name} Age:{Age}";
        }
    }
}
